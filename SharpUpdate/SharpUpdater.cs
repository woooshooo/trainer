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
            if (!this.bgWorker.IsBusy)
            {
                this.bgWorker.RunWorkerAsync(this.applicationInfo);
            }
            else {
                MessageBox.Show("Trainer up to date.");
            }
        }
        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ISharpUpdateable application = (ISharpUpdateable)e.Argument;

            if (!SharpUpdateXml.ExistsOnServer(application.UpdateXmlLocation))
                e.Cancel = true;
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
            Console.WriteLine("Inside Download Update");
            SharpUpdateDownloadForm form = new SharpUpdateDownloadForm(update.Uri, update.MD5, this.applicationInfo.ApplicationIcon);
            DialogResult result = form.ShowDialog(this.applicationInfo.Context);
            Console.WriteLine("Dialog result: " + result);
            if (result == DialogResult.OK) {
                string currentPath = this.applicationInfo.ApplicationAssembly.Location;
                string newPath = Path.GetDirectoryName(currentPath) + "\\" + update.FileName;
                UpdateApplication(form.TempFilePath, currentPath, newPath, update.Version.ToString());
                MessageBox.Show("Download Complete.\nYou can delete this old version.\nApp will now close.");
                Application.Exit();
            } else if (result == DialogResult.Abort) {
                MessageBox.Show("The update download was cancelled. \nThis program has not been modified.", "Update Download Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("There was a problem downloading the update. \nPlease try again later.", "Update Download Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateApplication(string tempFilePath, string currentPath, string newPath, string version)
        {
            string currname = Path.GetFileName(newPath);
            string[] splitText = currname.Split('.');
            string newFileName = splitText[0] + " v" + version + "." + splitText[1];
            string updatedPath = Path.GetDirectoryName(newPath) + "\\" + newFileName;
            //string s = String.Format("Copy-Item \"{0}\" -Destination \"{1}\"", tempFilePath, newPath);

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
