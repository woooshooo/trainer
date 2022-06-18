using Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace RanOnlineTrainer
{
    public partial class MainForm : Form
    {

        public static Mem m = new Mem();
        public Process[] pname;
        public static int psSistemaID;
        bool ProcOpen = false;

        private readonly string connectionString = "Data Source=sql.bsite.net\\MSSQL2016;Initial Catalog=woooshooo_randb;Persist Security Info=True;User ID=woooshooo_randb;Password=qweqwe123";
        SqlCommand command;
        SqlConnection connection;
        public static string miniapath = null;

        //Q AP

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);



        //FOR MOVE FORM 
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        /* ------------ ADDRESS ----------- */
        //RZ Ran Online
        private readonly string gameclient = "minia";
        private readonly string droneAddress = "02F23440";
        private readonly string atkspeedAddress = "00D5B038";
        private readonly string hpfAddress = "00BAC5D4";  //fHP_INC
        private readonly string pierceThruWalls1 = "004BFA58";
        private readonly string pierceThruWalls2 = "004BFA74";
        private readonly string qAutoPots = "0075D0D8";
        private readonly string qweAutoPots = "02F22DCC";
        //private readonly string dwRange = "009BF62C";
        private readonly string dwDD1 = "004D0BE1";
        private readonly string dwDD2 = "004D0BFF";
        private readonly string dwNOTAR1 = "004BF8FA";
        private readonly string dwNOTAR2 = "004BF90D";
        private readonly string dw5b = "004D0BC3";
        private readonly string dw1up = "004D08E9";
        private readonly string dw2up = "004D04B8";
        private readonly string dw3up = "004D0265";
        private readonly string dw4up = "004CFFE9";
        private readonly string dw5up = "004CFBD7";
        private readonly string dw6up = "004CF939";
        private readonly string dw1down = "004D1686";
        private readonly string dw2down = "004D1D09";
        private readonly string dw2eaxeax = "005DFBB1";
        private readonly string dwItemMallDelay = "00705893";
        private readonly string dwBankDelay = "00705903";
        private readonly string dwBoardDelay = "0070F9ED";
        private readonly string dwUnliChat = "007CED00";
        private readonly string dwFastTeleport = "00718A4F";
        private readonly string dwStartPointTW = "0047C936";
        private readonly string dwDropDisabledCT = "0047D651";
        private readonly string dwNameWallHack = "005E1A21"; //DRAW_ALPHA_MAP

        //One Classic
        //private readonly string gameclient = "gameclient";
        //private readonly string droneAddress = "0090E77C";
        //private readonly string atkspeedAddress = "00D5B038";
        //private readonly string hpfAddress = "00B663A4";  //fHP_INC
        //private readonly string pierceThruWalls1 = "004BC40C";
        //private readonly string pierceThruWalls2 = "004BC42F";
        //private readonly string qAutoPots = "0075BA5E";
        //private readonly string qweAutoPots = "02ECBA6C";
        //private readonly string dwRange = "009BF62C";
        //private readonly string dwDD1 = "004D03E1";
        //private readonly string dwDD2 = "004D03FF";
        //private readonly string dwNOTAR1 = "004BC2B8";
        //private readonly string dwNOTAR2 = "004BC2CB";
        //private readonly string dw5b = "004CDF7F";
        //private readonly string dw1up = "004CDCA3";
        //private readonly string dw2up = "004CD871";
        //private readonly string dw3up = "004CD615";
        //private readonly string dw4up = "004CD3A3";
        //private readonly string dw5up = "004CCF92";
        //private readonly string dw6up = "004CCCF1";
        //private readonly string dw1down = "004CEA54";
        //private readonly string dw2down = "004CF0F3";
        //private readonly string dw2eaxeax = "005E0972";
        //private readonly string dwItemMallDelay = "00707EC0";
        //private readonly string dwBankDelay = "007079D3";
        //private readonly string dwBoardDelay = "00711830";
        //private readonly string dwUnliChat = "00799140";
        //private readonly string dwFastTeleport = "0071B86B";
        //private readonly string dwStartPointTW = "00475E66";
        //private readonly string dwDropDisabledCT = "0047CD66";
        //private readonly string dwNameWallHack = "005E27D1"; //DRAW_ALPHA_MAP
        //private readonly string freeAddress = "00D02D08"; //Free Address 
        //private readonly string bodyRadWalkBypass = "0042482C"; 
        //private readonly string bodyRadDropBypass = "004251AA";
        //private readonly string bodyRadAOE = "004BE390";


        /* ------------ END of ADDRESS ----------- */


        //CHAT PAPERING_MODE -> UNLI CHAT JMP
        //waitserver_message , 3rd, 412 to 399
        //MAP_MOVE_BLOCK_RECALL, 2ND JE AT TOP-> JMP
        //MAP_MOVE_BLOCK_TELEPORT, 2ND JE AT TOP-> JMP

        //CertUtil -hashfile RanOnlineTrainer.exe MD5 ->> to get MD5sum


        bool AttackSpeed = false;
        bool HPF = false;
        bool AoeLR = false;
        bool AP = false;
        bool isPierce = false;

        public MainForm()
        {
            InitializeComponent();
            //INIT FORM
            ProcessExeLabel.Text = "Not Found";
            StatusValueLabel.Text = "WAITING";
            StatusValueLabel.ForeColor = Color.FromArgb(255, 0, 0); //RED
            if (admin.ADMIN_LOGIN == 0) {
                accounts_btn.Hide();
            }
        }

        private void BGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int pID = m.GetProcIdFromName(gameclient);
            pname = Process.GetProcessesByName(gameclient);
            if (pID > 0)
            {
                ProcOpen = m.OpenProcess(gameclient); // open process
                if (miniapath == null) {
                    //ps_sistema_bypass();
                }
                
            }
         
            if (!ProcOpen)
            {

                Thread.Sleep(1000);
                return;
            }

            Thread.Sleep(1000);
            BGWorker.ReportProgress(0);
        } 

        private void BGWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            if (m.GetProcIdFromName(gameclient) > 0)
            {
                ProcessExeLabel.Text = gameclient+".exe";
                StatusValueLabel.Text = "CONNECTED";            
                StatusValueLabel.ForeColor = Color.FromArgb(34, 139, 34); //GREEN      
                m.WriteMemory(dwItemMallDelay, "byte", "0"); //itemmall
                m.WriteMemory(dwBankDelay, "byte", "0"); //bankk
                m.WriteMemory(dwUnliChat, "byte", "EB"); //unli_chat
                m.WriteMemory(dwFastTeleport, "bytes", "68 00 00 90 39 6A 02"); //fast tele
                m.WriteMemory(dwBoardDelay, "byte", "0"); //board delay               
                m.WriteMemory(dwStartPointTW, "byte", "EB"); //sp in tw
                m.WriteMemory(dwDropDisabledCT, "byte", "EB"); //drop disabled ct
                m.WriteMemory(dwNameWallHack, "byte", "EB"); //wallhack
            }
            else
            {
                ProcessExeLabel.Text = "Not Found";
                StatusValueLabel.Text = "WAITING";
                StatusValueLabel.ForeColor = Color.FromArgb(255, 0, 0); //RED
            }

            PIDValueLabel.Text = Convert.ToString(m.GetProcIdFromName(gameclient));
        }

        private void BGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BGWorker.RunWorkerAsync();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            BGWorker.RunWorkerAsync();
            FormTime.Start();
            connection = new SqlConnection(connectionString);
            command = new SqlCommand("* FROM account WHERE username='" + login.username + "'", connection);
            connection.Open();
            guid_label.Text = guid_label.Text + " " + login.id;
            account_label.Text = account_label.Text + " " + login.username;
            lastlogin_label.Text = lastlogin_label.Text + " " + login.lastlogin;
            // FOR DRONE VALUES
            //Init Data
            List<DroneLevels> listDroneLevels = new List<DroneLevels>
            {
                new DroneLevels() { DroneLevel = "Default", DroneLevelVal = "200" },
                new DroneLevels() { DroneLevel = "Level 2", DroneLevelVal = "250" },
                new DroneLevels() { DroneLevel = "Level 3", DroneLevelVal = "300" },
                new DroneLevels() { DroneLevel = "Level 4", DroneLevelVal = "350" },
                new DroneLevels() { DroneLevel = "Level 5", DroneLevelVal = "450" }
            };
            //Set display member and value member
            DroneComboBox.DataSource = listDroneLevels;
            DroneComboBox.DisplayMember = "droneLevel";
            DroneComboBox.ValueMember = "droneLevelVal";
            DroneComboBox.SelectedIndex = 0;
        }

        //FOR MOVING THE FORM 
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        //FORM TIMER
        private void FormTime_Tick(object sender, EventArgs e)
        {
            FormTimeLabel.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        //MINIMIZE THE FORM
        private void MinimizeLabel_Click(object sender, EventArgs e)
        {
            Console.WriteLine("WindowState: " + this.WindowState);
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        //CLOSE THE FORM
        private void CloseLabel_Click(object sender, EventArgs e)
        {
            Console.WriteLine("WindowState: Closed");
            if (this.WindowState == FormWindowState.Normal)
            {
                BGWorker.ReportProgress(100);
                SqlCommand update = new SqlCommand("UPDATE account SET active = active - 1,lastlogin = @date WHERE username = @user;", connection);
                update.Parameters.AddWithValue("@date", Convert.ToDateTime(DateTime.Now));
                update.Parameters.AddWithValue("@user", login.username);
                update.ExecuteNonQuery();
                connection.Close();
                this.Close();
                Application.Exit();
            }
        }

        private void accounts_btn_Click(object sender, EventArgs e)
        {
            admin adminfrm = new admin();
            adminfrm.Show();
        }

        public static void ps_sistema_bypass() {
            ProcessStartInfo psi = new ProcessStartInfo("wmic", "process where \"name like '%MINIA%'\" get ExecutablePath /value");
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = true;
            var proc = Process.Start(psi);
            
            string exepath = proc.StandardOutput.ReadToEnd();
            string[] path = exepath.Split('=');
            string result = path[1].TrimEnd();

            miniapath = result.Substring(0, result.Length - 9);
            var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string filePath = Path.Combine(projectPath, "Resources");
            string fileName = "BugTrap.dll";
            string sourcePath = @""+filePath+"\\";
            string targetPath = @"" + miniapath + "";
            Console.WriteLine(fileName);
            Console.WriteLine(sourcePath);
            Console.WriteLine(targetPath);
            // Use Path class to manipulate file and directory paths.
            string sourceFile = Path.Combine(sourcePath, fileName);
            string destFile = Path.Combine(targetPath, fileName);
            File.Copy(sourceFile, destFile, true);
            Console.WriteLine("Copying BugTrap.dll_test to " + miniapath);
            proc.WaitForExit(100);
            proc.Close();
        }



        // ------------------ CHEATS BELOW HERE -------------------------------------------------//


        private void DroneComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DroneLevels droneLevelsObj = DroneComboBox.SelectedItem as DroneLevels;
            if (droneLevelsObj != null)
                m.FreezeValue(droneAddress, "float", droneLevelsObj.DroneLevelVal);
            Console.WriteLine("Drone Level: " + droneLevelsObj.DroneLevelVal);
            float curDroneLevel = m.ReadFloat(droneAddress);
            Console.WriteLine("Current Drone Level: " + curDroneLevel);

        }


        private void HPFButton_Click(object sender, EventArgs e)
        {
            if (!HPF)
            {
                Console.WriteLine("HPF Turned ON");
                HPFButton.Text = "ON";
                m.WriteMemory(hpfAddress, "float", "9999999");
                
                HPF = true;
            }
            else
            {
                Console.WriteLine("HPF Turned OFF");
                HPFButton.Text = "OFF";
                m.WriteMemory(hpfAddress, "float", "0.3000000119");
                HPF = false;
            }
               
        }

        private void AOELRButton_Click(object sender, EventArgs e)
        {
            if (!AoeLR)
            {
                AOELRButton.Text = "ON";
                //m.WriteMemory(dwRange, "byte", "4"); //ADD RANGE
                //m.WriteMemory(freeAddress, "byte", "4"); //Free Address AOE
                //m.WriteMemory(bodyRadWalkBypass, "bytes", "90 90 90 90 90 90 90");
                //m.WriteMemory(bodyRadDropBypass, "bytes", "90 90 90 90 90 90 90");
                //m.WriteMemory(bodyRadAOE, "bytes", "66 8B 15 08 2D D0");
                m.WriteMemory(dwDD1, "byte", "75"); //For DD1
                m.WriteMemory(dwDD2, "byte", "75"); //For DD2
                m.WriteMemory(dwNOTAR1, "bytes", "E9 1B 01 00 00"); //notar lr 1
                m.WriteMemory(dwNOTAR2, "bytes", "E9 F4 00 00 00"); //notar lr 2
                m.WriteMemory(dw5b, "bytes", "8D 44 11 5B"); //eax,[ecx+edx+5B]
                m.WriteMemory(dw1up, "bytes", "90 90 90 90 90 90 90"); //1-6 up 1-2 down
                m.WriteMemory(dw2up, "bytes", "90 90 90 90 90 90 90");
                m.WriteMemory(dw3up, "bytes", "90 90 90 90 90 90 90");
                m.WriteMemory(dw4up, "bytes", "90 90 90 90 90 90 90");
                m.WriteMemory(dw5up, "bytes", "90 90 90 90 90 90 90");
                m.WriteMemory(dw6up, "bytes", "90 90 90 90 90 90 90");
                m.WriteMemory(dw1down, "bytes", "90 90 90 90 90 90 90");
                m.WriteMemory(dw2down, "bytes", "90 90 90 90 90 90 90");
                m.WriteMemory(dw2eaxeax, "bytes", "31 D0"); //push 45 69, below mov call enter,  scroll down call edx+30, push eax, call enter, scroll down xor eax,eax
                AoeLR = true;
            }
            else
            {
                AOELRButton.Text = "OFF";
                //m.WriteMemory(dwRange, "byte", "4"); //ADD RANGE
                //m.WriteMemory(freeAddress, "byte", "4"); //Free Address AOE
                //m.WriteMemory(bodyRadWalkBypass, "bytes", "66 8B 0D CC F7 9B");
                //m.WriteMemory(bodyRadDropBypass, "bytes", "0F B7 05 CC F7 9B");
                //m.WriteMemory(bodyRadAOE, "bytes", "66 8B 15 CC F7 9B");
                m.WriteMemory(dwDD1, "byte", "74"); //For DD1
                m.WriteMemory(dwDD2, "byte", "74"); //For DD2
                m.WriteMemory(dwNOTAR1, "bytes", "0F 85 1A 01 00"); //notar lr 1
                m.WriteMemory(dwNOTAR2, "bytes", "0F 85 F3 00 00"); //notar lr 2
                m.WriteMemory(dw5b, "bytes", "8D 44 11 02"); //eax,[ecx+edx+5B]
                m.WriteMemory(dw1up, "bytes", "0F B7 05 2C F6 9B 00"); //1-6 up 1-2 down
                m.WriteMemory(dw2up, "bytes", "0F B7 05 2C F6 9B 00");
                m.WriteMemory(dw3up, "bytes", "0F B7 0D 2C F6 9B 00");
                m.WriteMemory(dw4up, "bytes", "0F B7 05 2C F6 9B 00");
                m.WriteMemory(dw5up, "bytes", "0F B7 0D 2C F6 9B 00");
                m.WriteMemory(dw6up, "bytes", "0F B7 0D 2C F6 9B 00");
                m.WriteMemory(dw1down, "bytes", "0F B7 05 2C F6 9B 00");
                m.WriteMemory(dw2down, "bytes", "0F B7 05 2C F6 9B 00");
                m.WriteMemory(dw2eaxeax, "bytes", "33 C0"); //push 45 69, below mov call enter,  scroll down call edx+30, push eax, call enter, scroll down xor eax,eax
                AoeLR = false;
            }

        }

        private void QAPButton_Click(object sender, EventArgs e)
        {
            if (!AP)
            {
                QAPButton.Text = "ON";
                Console.WriteLine("Q AP ON");
                m.WriteMemory(qAutoPots, "byte", "75");
                m.FreezeValue(qweAutoPots, "bytes", "03 03 03");
                AP = true;



            }
            else
            {
                QAPButton.Text = "OFF";
                Console.WriteLine("Q AP OFF");
                m.WriteMemory(qAutoPots, "byte", "74");
                m.UnfreezeValue(qweAutoPots);
                AP = false;
            }
        }

        private void piercethruwallsButton_Click(object sender, EventArgs e)
        {


            if (!isPierce)
            {
                piercethruwallsButton.Text = "ON";
                m.WriteMemory(pierceThruWalls1, "bytes", "90 90 90 90");
                m.WriteMemory(pierceThruWalls2, "bytes", "90 90 90 90");
                isPierce = true;

            }
            else
            {
                piercethruwallsButton.Text = "OFF";
                m.WriteMemory(pierceThruWalls1, "bytes", "D9 44 24 40");
                m.WriteMemory(pierceThruWalls2, "bytes", "D9 44 24 20");
                isPierce = false;
            }
            
            

        }

        private void attkspd_btn_Click(object sender, EventArgs e)
        {
            if (!AttackSpeed)
            {
                attkspd_btn.Text = "ON";
                m.FreezeValue(atkspeedAddress, "float", "0.2700000107"); //AttackSpeed
                AttackSpeed = true;

            }
            else
            {
                attkspd_btn.Text = "OFF";
                m.FreezeValue(atkspeedAddress, "float", "0"); //AttackSpeed
                AttackSpeed = false;
            }
            
        }

        
    }
}
