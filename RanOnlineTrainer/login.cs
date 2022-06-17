using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RanOnlineTrainer
{
    public partial class login : Form
    {
        /* SETUP */

        private readonly string connectionString = "Data Source=sql.bsite.net\\MSSQL2016;Initial Catalog=woooshooo_randb;Persist Security Info=True;User ID=woooshooo_randb;Password=qweqwe123";
        
        SqlConnection connection;
        public static SqlCommand command;
        public static Guid id;
        public static string username;       
        public static int allowedactive;
        public static int active;
        public static DateTime lastlogin;
        public static string ranserver;
        public static DataTable dt;
        public static SqlDataAdapter da;
        private Boolean isValid = false;
        public login()
        {
            InitializeComponent();
        }

        //FOR MOVE FORM 
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        //FOR MOVING THE FORM 
        private void login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void MinimizeLabel_Click(object sender, EventArgs e)
        {
            Console.WriteLine("WindowState: " + this.WindowState);
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
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

        private void useraccount_tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login_btn.PerformClick();
            }
        }

        private void useraccount_tb_MouseHover(object sender, EventArgs e)
        {
            username_tooltip.SetToolTip(useraccount_tb, "Enter Account given here.");
        }

        private void login_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            invalidaccess_label.Hide();
        }
        private void adminlogin_btn_Click(object sender, EventArgs e)
        {
            String user_input = useraccount_tb.Text;
            checkAdminLogin(user_input);
            setResultToDataTable();
            invalidaccess_label.Hide();
            if (isValid)
            {
                if (updateCurrentActive())
                {
                    MainForm mainfrm = new MainForm();
                    admin adminfrm = new admin();
                    mainfrm.Show();
                    adminfrm.Show();
                    this.Hide();
                }
                else
                {
                    invalidaccess_label.Show();
                    connection.Close();
                }
            }
            else
            {
                invalidaccess_label.Show();
                connection.Close();
            }
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            String user_input = useraccount_tb.Text;
            checkLogin(user_input);
            setResultToDataTable();
            admin.ADMIN_LOGIN = 0;
            invalidaccess_label.Hide();
            if (isValid)
            {
                if (updateCurrentActive()) {
                    MainForm frm = new MainForm();
                    frm.Show();
                    connection.Close();
                    this.Hide();
                } else
                {
                    invalidaccess_label.Show();
                    connection.Close();
                }
            } else {
                invalidaccess_label.Show();
                connection.Close();
            }
        }
        private Boolean checkLogin(string user_input) {
            command = new SqlCommand("SELECT username,* FROM account WHERE username='" + user_input + "'", connection);
            connection.Open();
            if ((String)command.ExecuteScalar() != null) {
                isValid = true;
            }
            return isValid;
        }

        private Boolean checkAdminLogin(string user_input)
        {
            command = new SqlCommand("SELECT username,* FROM account WHERE username='" + user_input + "' AND ranserver = 'admin'", connection);
            connection.Open();
            if ((String)command.ExecuteScalar() != null)
            {
                isValid = true;
            }
            return isValid;
        }
        private void setResultToDataTable() {
            //Put data to DataTable
            dt = new DataTable();
            da = new SqlDataAdapter(command);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("ID: " + dr.Field<Guid>("id"));
                id = dr.Field<Guid>("id");
                Console.WriteLine("Username: " + dr.Field<string>("username"));
                username = dr.Field<string>("username");
                Console.WriteLine("Allowed Active: " + dr.Field<int>("allowedactive"));
                allowedactive = dr.Field<int>("allowedactive");
                Console.WriteLine("Current Active: " + dr.Field<int>("active"));
                active = dr.Field<int>("active");
                Console.WriteLine("Last Login: " + dr.Field<DateTime>("lastlogin"));
                lastlogin = dr.Field<DateTime>("lastlogin");
                Console.WriteLine("Ran Server: " + dr.Field<string>("ranserver"));
                ranserver = dr.Field<string>("ranserver");
            }
        }

        private Boolean updateCurrentActive() {
            Boolean isAllowed = false;
            if (active < allowedactive) {
                SqlCommand update = new SqlCommand("UPDATE account SET active = active + 1,lastlogin = @date WHERE username = @user;", connection);
                update.Parameters.AddWithValue("@date", Convert.ToDateTime(DateTime.Now));
                update.Parameters.AddWithValue("@user", username);
                update.ExecuteNonQuery();
                isAllowed = true;
            }
            return isAllowed;
        }

        
    }
}
