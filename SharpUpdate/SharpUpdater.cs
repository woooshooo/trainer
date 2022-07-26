using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SharpUpdate
{
    public class SharpUpdater
    {
        private ISharpUpdateable applicationInfo;
        private BackgroundWorker bgWorker;
        private PowerShell ps;

        public SharpUpdater (ISharpUpdateable applicationInfo)
        {
            this.applicationInfo = applicationInfo;
            this.bgWorker = new BackgroundWorker();
            this.bgWorker.DoWork += BgWorker_DoWork;
            this.bgWorker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;
        }
        public void DoUpdate() {
            Console.WriteLine("Doing Update...");
            try
            {
                if (!this.bgWorker.IsBusy)
                {
                    this.bgWorker.RunWorkerAsync(this.applicationInfo);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            
        }
        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ISharpUpdateable application = (ISharpUpdateable)e.Argument;

            if (!SharpUpdateXml.ExistsOnServer(application.UpdateXmlLocation)) {
                MessageBox.Show("Trainer is up to date.");
                e.Cancel = true;
            }
            else
                e.Result = SharpUpdateXml.Parse(application.UpdateXmlLocation, application.ApplicationID);
        }

        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled) {
                SharpUpdateXml update = (SharpUpdateXml)e.Result;
                if (update != null && update.IsNewerThan(this.applicationInfo.ApplicationAssembly.GetName().Version)) { 
                    if (new SharpUpdateAcceptForm(this.applicationInfo, update).ShowDialog(this.applicationInfo.Context) == DialogResult.Yes){
                        Console.WriteLine("DownloadUpdate from SharpUpdater");
                        this.DownloadUpdate(update);
                    }
                }
            }
                
        }

        private void DownloadUpdate(SharpUpdateXml update)
        {
            Console.WriteLine("Verifying Download Update");
            SharpUpdateDownloadForm form = new SharpUpdateDownloadForm(update.Uri, update.MD5, this.applicationInfo.ApplicationIcon);
            DialogResult result = form.ShowDialog(this.applicationInfo.Context);
            string currentPath = this.applicationInfo.ApplicationAssembly.Location;
            string newPath = Path.GetDirectoryName(currentPath) + "\\" + update.FileName;
            string currAppName = Path.GetFileName(newPath);
            string[] splitText = currAppName.Split('.');
            string newFileName = splitText[0] + " v" + update.Version.ToString() + "." + splitText[1];
            string updatedPath = Path.GetDirectoryName(newPath) + "\\" + newFileName;

            if (result == DialogResult.OK) {
                UpdateApplication(form.TempFilePath, updatedPath);
                ps = PowerShell.Create();
                MessageBox.Show("Trainer Verified.\nYou can delete this old version.\nApp will now close.", "", MessageBoxButtons.OK);                
                ps.AddCommand("Start-Process").AddParameter("FilePath", updatedPath).AddParameter("verb", "runas").Invoke();
                ps.Stop();
                Application.Exit();
            } else if (result == DialogResult.Abort) {
                MessageBox.Show("The update download was cancelled. \nThis program has not been modified.", "Update Download Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show("There was a problem downloading the update. \nPlease try again later.", "Update Download Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateApplication(string tempFilePath, string updatedPath)
        {
            //MessageBox.Show("Running Script...");
            ps = PowerShell.Create();            
            ps.AddCommand("Copy-Item").AddParameter("Path", tempFilePath).AddParameter("Destination", updatedPath).Invoke();
            ps = PowerShell.Create();
            ps.AddCommand("Remove-Item").AddParameter("Path", tempFilePath).Invoke();
            ps.Stop();

            //CertUtil -hashfile RanOnlineTrainer.exe MD5 ->> to get MD5sum
        }


    }
}
