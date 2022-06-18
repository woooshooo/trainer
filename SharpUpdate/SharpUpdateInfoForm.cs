using System;
using System.Windows.Forms;

namespace SharpUpdate
{
    public partial class SharpUpdateInfoForm : Form
    {

        //FOR MOVE FORM 
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public SharpUpdateInfoForm(ISharpUpdateable applicationInfo, SharpUpdateXml updateInfo)
        {
            InitializeComponent();
            this.Text = applicationInfo.ApplicationName + " - Update Info";
            this.lblVersions.Text = String.Format("Current Version: {0}\nUpdate Version: {1}", applicationInfo.ApplicationAssembly.GetName().Version.ToString(), updateInfo.Version.ToString());
            this.txtDescription.Text = updateInfo.Description;
        }

        private void SharpUpdateInfoForm_MouseDown(object sender, MouseEventArgs e)
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

        private void back_btn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("WindowState: Closed");
            if (this.WindowState == FormWindowState.Normal)
            {
                this.Close();
            }
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.Control && e.KeyCode == Keys.C)) {
                e.SuppressKeyPress = true;
            }
        }
    }
}
