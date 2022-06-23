using AltoHttp;
using AltoHttp.Exceptions;
using AltoHttp.NativeMessages;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace SharpUpdate
{
    internal partial class SharpUpdateDownloadForm : Form
    {

        public static DownloadMessage MSG = null;
        
        //FOR MOVE FORM 
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        //For update

        private BackgroundWorker bgWorker;
        private string tempFile;
        private string md5;

        HttpDownloader httpDownloader;
        

        internal string TempFilePath { get { return this.tempFile; } }

        internal SharpUpdateDownloadForm(Uri location, string md5, Icon programIcon) {
            InitializeComponent();
            
            ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;

            if (programIcon != null) this.Icon = programIcon;
            tempFile = Path.GetTempFileName();
            this.md5 = md5;
            
            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += BgWorker_DoWork;
            bgWorker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;
            try
            {
                Console.WriteLine("trying");
                Console.WriteLine("location: " + location);
                Console.WriteLine("tempFile: " + this.tempFile);

                httpDownloader = new HttpDownloader(location.ToString(), this.tempFile);
                httpDownloader.DownloadCompleted += HttpDownloader_DownloadCompleted;
                httpDownloader.ProgressChanged += HttpDownloader_ProgressChanged;
                httpDownloader.ErrorOccured += HttpDownloader_ErrorOccured;
                httpDownloader.BeforeSendingRequest += HttpDownloader_BeforeSendingRequest;
                httpDownloader.Start();
                
            }
            catch (Exception e)
            {
                Console.WriteLine("This is the exception error: " + e.Message);
                this.DialogResult = DialogResult.No;
                this.Close();
            }
        }

        private void HttpDownloader_BeforeSendingRequest(object sender, BeforeSendingRequestEventArgs e)
        {
            MSG = Receiver.ReadDownloadMessage();
            if (MSG != null)
            {
                var request = (HttpWebRequest)e.Request;
                request.SetHeaders(MSG.Headers);
                Console.WriteLine("MSG.Headers: " + MSG.Headers);
            }
        }

        private void HttpDownloader_ErrorOccured(object sender, ErrorEventArgs e)
        {
            var ex = e.GetException();
            if (ex is FileValidationFailedException)
            {
                httpDownloader.Pause();
            }
            this.DialogResult = DialogResult.No;
            Console.WriteLine("Error: " + e.GetException().Message + " " + e.GetException().StackTrace);
            this.Close();
        }

        private void HttpDownloader_ProgressChanged(object sender, AltoHttp.ProgressChangedEventArgs e)
        {
            this.progressBar.Value = (int)e.Progress;
            this.progress_label.Text = String.Format("Downloaded {0}", FormatBytes(httpDownloader.TotalBytesReceived, 1, true));
        }

        private void HttpDownloader_DownloadCompleted(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                downloading_label.Text = "Download Complete";
                progressBar.Style = ProgressBarStyle.Marquee;
                bgWorker.RunWorkerAsync(new string[] { this.tempFile, this.md5 });
                bgWorker.Dispose();
                MessageBox.Show("Download Complete.");
            });            
        }

        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //MessageBox.Show("Download Complete.");
            string file = ((string[])e.Argument)[0];
            string updateMd5 = ((string[])e.Argument)[1];
            if (Hasher.HashFile(file, HashType.MD5) != updateMd5)
            {
                Console.WriteLine("File: " + file + " is not equal to updateMd5: " + updateMd5);
                this.DialogResult = DialogResult.No;
            }
            else { this.DialogResult = DialogResult.OK; }
        }
        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.DialogResult = (DialogResult)e.Result;
            }
            catch (Exception)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void SharpUpdateDownloadForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            Console.WriteLine("WindowState: Closed");
            if (this.WindowState == FormWindowState.Normal)
            {
                this.Close();
            }
        }

        private void SharpUpdateDownloadForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (bgWorker.IsBusy)
            {
                bgWorker.CancelAsync();
                this.DialogResult = DialogResult.Abort;
            }
            this.Close();
        }


        private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            // If the certificate is a valid, signed certificate, return true.
            if (error == System.Net.Security.SslPolicyErrors.None)
            {
                return true;
            }

            Console.WriteLine("X509Certificate [{0}] Policy Error: '{1}'",
                cert.Subject,
                error.ToString());

            return false;
        }
        private string FormatBytes(long bytes, int decimalPlaces, bool showByteType)
        {
            double newBytes = bytes;
            string formatString = "{0";
            string byteType = "B";

            if (newBytes > 1024 && newBytes < 1048576)
            {
                newBytes /= 1024;
                byteType = "KB";
            }
            else if (newBytes > 1048576 && newBytes < 1073741824)
            {
                newBytes /= 1048576;
                byteType = "MB";
            }
            else
            {
                newBytes /= 1073741824;
                byteType = "GB";
            }

            if (decimalPlaces > 0)
                formatString += ":0.";

            for (int i = 0; i < decimalPlaces; i++)
                formatString += "0";

            formatString += "}";

            if (showByteType)
                formatString += byteType;
            return string.Format(formatString, newBytes);
        }
    }
}
