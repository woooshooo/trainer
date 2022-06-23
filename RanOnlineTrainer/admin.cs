using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RanOnlineTrainer
{
    public partial class admin : Form
    {

        private static Random _random = new Random();
        public int RandomReuse() => _random.Next(1, 1000000);
        //private readonly string connectionString = "Data Source=sql.bsite.net\\MSSQL2016;Initial Catalog=woooshooo_randb;Persist Security Info=True;User ID=woooshooo_randb;Password=qweqwe123";
        private readonly string connectionString = "Server=sql598.main-hosting.eu;User ID=u687082794_wkbg;Password=Qweqwe123;Database=u687082794_randatabase;Allow User Variables=true";
        public admin()
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
        private void admin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void admin_Load(object sender, EventArgs e)
        {
            populateDataGridView();            
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            populateDataGridView();
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

        private void populateDataGridView() {
            using (MySqlConnection connection = new MySqlConnection(connectionString)) {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM u687082794_randatabase.accounts", connection);
                command.ExecuteScalar();              
                login.da = new MySqlDataAdapter(command);
                login.dt = new DataTable();
                login.da.Fill(login.dt);
                dataGridView.DataSource = login.dt;     
            }
            Console.WriteLine("Repopulating Grid Views...");
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dataGridView.CurrentRow != null) {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    DataGridViewRow dgvrow = dataGridView.CurrentRow;
                    dataGridView.MultiSelect = false;
                    MySqlCommand sqlCommand = new MySqlCommand("INSERT INTO u687082794_randatabase.accounts(id, username, allowedactive, active, lastlogin, ranserver, ipaddress) VALUES(@id, @username, @allowedactive, @active, @lastlogin, @ranserver, @ipaddress)", connection);
                    MySqlCommand sqlCommand2 = new MySqlCommand("UPDATE u687082794_randatabase.accounts SET id = @id, username = @username, allowedactive = @allowedactive, active = @active, lastlogin = @lastlogin,ranserver = @ranserver, ipaddress = @ipaddress WHERE id = @id", connection);
                    if (dgvrow.Cells["id"].Value == DBNull.Value) {
                        sqlCommand.Parameters.AddWithValue("@id", RandomReuse());
                        sqlCommand.Parameters.AddWithValue("@username", dgvrow.Cells["username"].Value.ToString());
                        sqlCommand.Parameters.AddWithValue("@allowedactive", dgvrow.Cells["allowedactive"].Value.ToString());
                        sqlCommand.Parameters.AddWithValue("@active", dgvrow.Cells["active"].Value.ToString());
                        sqlCommand.Parameters.AddWithValue("@lastlogin", Convert.ToDateTime(DateTime.Now));
                        sqlCommand.Parameters.AddWithValue("@ranserver", dgvrow.Cells["ranserver"].Value.ToString());
                        sqlCommand.Parameters.AddWithValue("@ipaddress", dgvrow.Cells["ipaddress"].Value.ToString());
                        Console.WriteLine("Inserting...");
                        sqlCommand.ExecuteNonQuery();
                        Console.WriteLine("Executing Non Query...");
                    } else {
                        sqlCommand2.Parameters.AddWithValue("@id", dgvrow.Cells["id"].Value);
                        sqlCommand2.Parameters.AddWithValue("@username", dgvrow.Cells["username"].Value.ToString());
                        sqlCommand2.Parameters.AddWithValue("@allowedactive", dgvrow.Cells["allowedactive"].Value.ToString());
                        sqlCommand2.Parameters.AddWithValue("@active", dgvrow.Cells["active"].Value.ToString());
                        sqlCommand2.Parameters.AddWithValue("@lastlogin", Convert.ToDateTime(DateTime.Now));
                        sqlCommand2.Parameters.AddWithValue("@ranserver", dgvrow.Cells["ranserver"].Value.ToString());
                        sqlCommand2.Parameters.AddWithValue("@ipaddress", dgvrow.Cells["ipaddress"].Value.ToString());
                        Console.WriteLine("Updating");
                        sqlCommand2.ExecuteNonQuery();
                        Console.WriteLine("Executing Non Query...");
                    }     
                }
                populateDataGridView();
            }            
        }

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dataGridView.CurrentRow.Cells["id"].Value != DBNull.Value)
            {
                if (MessageBox.Show("U SURE?", "DataGridView", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        MySqlCommand sqlcommand = new MySqlCommand("DELETE FROM `u687082794_randatabase`.`accounts` WHERE username = @username; ", connection);
                        sqlcommand.Parameters.AddWithValue("@username", dataGridView.CurrentRow.Cells["username"].Value);
                        Console.WriteLine("deleting..");
                        sqlcommand.ExecuteNonQuery();

                    }
                }      
            }
        }
    }
}
