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
    public partial class admin : Form
    {

        public static int ADMIN_LOGIN = 1;
        private readonly string connectionString = "Data Source=sql.bsite.net\\MSSQL2016;Initial Catalog=woooshooo_randb;Persist Security Info=True;User ID=woooshooo_randb;Password=qweqwe123";

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
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM account", connection);
                command.ExecuteScalar();              
                login.da = new SqlDataAdapter(command);
                login.dt = new DataTable();
                login.da.Fill(login.dt);
                dataGridView.DataSource = login.dt;     
            }
            Console.WriteLine("Repopulating Grid Views...");
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.CurrentRow != null) {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    DataGridViewRow dgvrow = dataGridView.CurrentRow;
                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO account(id, username, allowedactive, active, lastlogin, ranserver) VALUES(@id, @username, @allowedactive, @active, @lastlogin, @ranserver)", connection);
                    SqlCommand sqlCommand2 = new SqlCommand("UPDATE account SET id = @id, username = @username, allowedactive = @allowedactive, active = @active, lastlogin = @lastlogin,ranserver = @ranserver WHERE id = @id", connection);
                    if (dgvrow.Cells["id"].Value == DBNull.Value) {
                        sqlCommand.Parameters.AddWithValue("@id", Guid.NewGuid());
                        sqlCommand.Parameters.AddWithValue("@username", dgvrow.Cells["username"].Value.ToString());
                        sqlCommand.Parameters.AddWithValue("@allowedactive", dgvrow.Cells["allowedactive"].Value.ToString());
                        sqlCommand.Parameters.AddWithValue("@active", dgvrow.Cells["active"].Value.ToString());
                        sqlCommand.Parameters.AddWithValue("@lastlogin", Convert.ToDateTime(DateTime.Now));
                        sqlCommand.Parameters.AddWithValue("@ranserver", dgvrow.Cells["ranserver"].Value.ToString());
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
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand sqlcommand = new SqlCommand("accountdeletebyusername", connection);
                        sqlcommand.CommandType = CommandType.StoredProcedure;
                        sqlcommand.Parameters.AddWithValue("@username", dataGridView.CurrentRow.Cells["username"].Value);
                        Console.WriteLine("deleting..");
                        sqlcommand.ExecuteNonQuery();

                    }
                }      
            }
        }
    }
}
