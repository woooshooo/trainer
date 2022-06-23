using MySqlConnector;
using SharpUpdate;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Management.Automation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RanOnlineTrainer
{
    public partial class login : Form, ISharpUpdateable
    {
        /* SETUP */

        //rivate readonly string connectionString = "Data Source=sql.bsite.net\\MSSQL2016;Initial Catalog=woooshooo_randb;Persist Security Info=True;User ID=woooshooo_randb;Password=qweqwe123";
        private readonly string connectionString = "Server=sql598.main-hosting.eu;User ID=u687082794_wkbg;Password=Qweqwe123;Database=u687082794_randatabase;Allow User Variables=true";

        MySqlConnection connection;
        public static MySqlCommand command;
        public static int id;
        public static string username;
        public static int allowedactive;
        public static int active;
        public static DateTime lastlogin;
        public static string ranserver;
        public static DataTable dt;
        public static MySqlDataAdapter da;
        private Boolean isValid = false;
        private SharpUpdater updater;
        internal MainForm frm;


        public login()
        {
            InitializeComponent();
            this.version_label.Text = "Current Version: " + this.ApplicationAssembly.GetName().Version.ToString();
            updater = new SharpUpdater(this);
            connection = new MySqlConnection(connectionString);
            invalidaccess_label.Hide();
        }

        /* For Auto Update */
        public string ApplicationName {
            get {
                return "RanOnlineTrainer";
            }
        }
        public string ApplicationID
        {
            get
            {
                return "RanOnlineTrainer";
            }
        }

        public Assembly ApplicationAssembly
        {
            get
            {
                return Assembly.GetExecutingAssembly();
            }
        }

        public Icon ApplicationIcon
        {
            get
            {
                return this.Icon;
            }
        }

        public Uri UpdateXmlLocation
        {
            get
            {
                return new Uri("http://webstergenise.com/trainer/updatebalikran.xml");
            }
        }

        public Form Context
        {
            get
            {
                return this;
            }
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

        internal void testConnection() {
            try
            {
                using (var connection = new MySqlConnection("Server=sql598.main-hosting.eu;User ID=u687082794_wkbg;Password=Qweqwe123;Database=u687082794_randatabase"))
                {
                    connection.Open();
                    MessageBox.Show("Connection OK.");
                    using (var command = new MySqlCommand("SELECT * FROM accounts", connection))
                    using (var reader = command.ExecuteReader())
                        while (reader.Read())
                            Console.WriteLine("Testing Connection: " + reader.GetInt32(0).ToString() + " " + reader.GetString(1));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Connection Not OK.");
            }

        }

        private void login_Load(object sender, EventArgs e)
        {
            frm = new MainForm(); //preloads main form.
            //Test Connection
            //testConnection();         

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
                    mainfrm.Show();
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
            invalidaccess_label.Hide();
            if (isValid)
            {
                updateCurrentActive();
                MessageBox.Show("Logging in...", "", MessageBoxButtons.OK);
                frm.Show();
                connection.Close();
                this.Hide();
            } else {
                invalidaccess_label.Show();
                connection.Close();
            }
        }
        private Boolean checkLogin(string user_input) {
            Console.WriteLine("Checking if user is admin");
            string commandText = "SELECT * FROM u687082794_randatabase.accounts WHERE username = @user AND ranserver = 'admin'";
            command = new MySqlCommand(commandText, connection);
            command.Parameters.AddWithValue("@user", user_input);
            connection.Open();
            if (Convert.ToString(command.ExecuteScalar()) != "") {
                isValid = true;
                MainForm.ADMIN_LOGIN = 1;
                Console.WriteLine("user is admin");
            } else {
                Console.WriteLine("Checking if user is valid");
                string commandText2 = "SELECT * FROM u687082794_randatabase.accounts WHERE username=@user";
                MySqlCommand command = new MySqlCommand(commandText2, connection);
                command.Parameters.AddWithValue("@user", user_input);
                if (Convert.ToString(command.ExecuteScalar()) != "") {
                    isValid = true;
                    MainForm.ADMIN_LOGIN = 0;
                    Console.WriteLine("user is valid");
                }
            }
            return isValid;
        }

        private Boolean checkAdminLogin(string user_input)
        {
            string commandText = "SELECT * FROM u687082794_randatabase.accounts WHERE username = @user AND ranserver = 'admin'";
            command = new MySqlCommand(commandText, connection);
            command.Parameters.AddWithValue("@user", user_input);
            connection.Open();
            if (Convert.ToString(command.ExecuteScalar()) != null)
            {
                isValid = true;
            }
            return isValid;
        }
        private void setResultToDataTable() {
            //Put data to DataTable
            dt = new DataTable();
            da = new MySqlDataAdapter(command);
            da.Fill(dt);
            
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("ID: " + dr.Field<int>("id"));
                id = dr.Field<int>("id");
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
                MySqlCommand update = new MySqlCommand("UPDATE u687082794_randatabase.accounts SET active = active + 1,lastlogin = @date WHERE username = @user;", connection);
                update.Parameters.AddWithValue("@date", Convert.ToDateTime(DateTime.Now));
                update.Parameters.AddWithValue("@user", username);
                update.ExecuteNonQueryAsync();
                isAllowed = true;                
            }
            return isAllowed;
        }

        private void checkUpdate_btn_Click(object sender, EventArgs e)
        {
            updater.DoUpdate();
            Console.WriteLine("clicking the check update button...");
        }
    }
}
