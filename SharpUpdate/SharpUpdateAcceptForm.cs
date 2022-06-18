using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpUpdate
{
    internal partial class SharpUpdateAcceptForm : Form
    {
        //FOR MOVE FORM 
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        private ISharpUpdateable applicationInfo;
        private SharpUpdateXml updateInfo;
        private SharpUpdateInfoForm updateInfoForm;
        public SharpUpdateAcceptForm(ISharpUpdateable applicationInfo, SharpUpdateXml updateinfo)
        {
            InitializeComponent();
            this.applicationInfo = applicationInfo;
            this.updateInfo = updateinfo;

            //this.Text = this.applicationInfo.ApplicationName + " - Update Available";

            if (this.applicationInfo.ApplicationIcon != null)
                this.Icon = this.applicationInfo.ApplicationIcon;

            newVersion_label.Text = string.Format("New Version: " + this.updateInfo.Version.ToString());
        }

        private void yes_btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void no_btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void details_btn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("i am in the details btn");
            Console.WriteLine("applicationInfo: " + this.applicationInfo.ToString());
            Console.WriteLine("updateInfo: " + this.updateInfo.ToString());
            if (this.updateInfoForm == null)
                this.updateInfoForm = new SharpUpdateInfoForm(this.applicationInfo, this.updateInfo);

            this.updateInfoForm.ShowDialog(this);
        }

        private void SharpUpdateAcceptForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
