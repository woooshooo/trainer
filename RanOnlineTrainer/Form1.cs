using Memory;
using MySqlConnector;
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

        private readonly string connectionString = "Server=sql598.main-hosting.eu;User ID=u687082794_wkbg;Password=Qweqwe123;Database=u687082794_randatabase;Allow User Variables=true";
        MySqlCommand command;
        MySqlConnection connection;
        public static string miniapath = null;
        public string ipaddr;
        public static int ADMIN_LOGIN = 0;


        //FOR MOVE FORM 
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        /* ------------ ADDRESS ----------- */
        //Balik Ran Online
        private readonly string gameclient = "minia";
        private readonly string droneAddress = "02F61108";
        private readonly string atkspeedAddress = "00B2C554";
        private readonly string hpfAddress = "00B24DD8", hpfAddress2 = "00B24DDA";
        private readonly string pierceThruWalls1 = "004DCAD3";
        //private readonly string pierceThruWalls2 = "004BFA74";
        private readonly string qAutoPots = "007347AE";
        private readonly string qAutoPots2 = "007347C2";
        private readonly string dwRange = "0098D268";
        private readonly string dwRangeFree = "05E2295C";
        private readonly string dwRangeLR = "004DC905", dwRangeLROnValue = "66 8B 15 5C 29 E2 05", dwRangeLROffValue = "66 8B 15 68 D2 98 00";
        private readonly string dwRangeWalkBypass = "00430A27";
        private readonly string dwRangeDropBypass = "00432062";
        //private readonly string dwNOTAR1 = "004BF8FA";
        //private readonly string dwNOTAR2 = "004BF90D";
        private readonly string dw5b = "0055E074";
        private readonly string dw1up = "0055DD52";
        private readonly string dw2up = "0055D8F1";
        private readonly string dw3up = "0055D689";
        private readonly string dw4up = "0055D3E5";
        private readonly string dw5up = "0055CF87";
        private readonly string dw6up = "0055CC97";
        private readonly string dw1down = "0055EB9D";
        private readonly string dw2down = "0055F28D";
        private readonly string dw2eaxeax = "005BF70C", dw2eaxeaxOnValue = "31 D0", dw2eaxeaxOffValue = "33 C0";
        private readonly string dwPlayerRanking = "008D4CF4"; //float
        private readonly string dwItemMallDelay = "008D5688";
        private readonly string dwBankDelay = "008D5688";
        private readonly string dwBoardDelay = "006F4B3A"; //EB
        private readonly string dwUnliChat = "0079EC14";
        private readonly string dwFastTeleport = "008D4CF4"; //float
        private readonly string dwStartPointTW = "004A606F";
        private readonly string dwNameWallHack = "005BC16F"; //DRAW_ALPHA_MAP

        //One Classic
        //private readonly string gameclient = "gameclient";
        //private readonly string droneAddress = "0090E77C", droneAddressActive = "02ECC1A8";
        //private readonly string hpfAddress = "00D04DE8", hpfAddress2 = "00D04DEA";
        //private readonly string qAutoPots = "0075BC0B";
        //private readonly string qAutoPots2 = "0075BC1F";
        //private readonly string dwRange = "009BF7CC";
        //private readonly string dwRangeFree = "05E2295C";
        //private readonly string dwRangeLR = "004BC36B", dwRangeLROnValue = "66 8B 0D 5C 29 E2 05", dwRangeLROffValue = "66 8B 0D CC F7 9B 00";
        //private readonly string dw2eaxeax = "005E0C71", dw2eaxeaxOnValue = "31 D0", dw2eaxeaxOffValue = "33 C0";
        //private readonly string dwItemMallDelay = "007081E0";
        //private readonly string dwBankDelay = "00707CE3";
        //private readonly string dwBoardDelay = "00711B40";
        //private readonly string dwUnliChat = "007992B0";
        //private readonly string dwNameWallHack = "005E2AF1"; 


        /* ------------ END of ADDRESS ----------- */


        //CHAT PAPERING_MODE -> UNLI CHAT JMP
        //waitserver_message , 3rd, 412 to 399
        //MAP_MOVE_BLOCK_RECALL, 2ND JE AT TOP-> JMP
        //MAP_MOVE_BLOCK_TELEPORT, 2ND JE AT TOP-> JMP

        //CertUtil -hashfile RanOnlineTrainer.exe MD5 ->> to get MD5sum

        /** AOE / LR
         *above push(5 codes)
         *lakad aoe = mov cx
         *dikit drop = movzx eax (below cx)
         *below push(2 codes)
         *byte aoe = mov dx    
        **/


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
            PIDValueLabel.Text = "WAITING";
            StatusValueLabel.ForeColor = Color.FromArgb(255, 0, 0); //RED           
            ipaddr = getPublicIpAddress();
            
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
                ProcessExeLabel.Text = gameclient + ".exe";
                StatusValueLabel.Text = "CONNECTED";
                StatusValueLabel.ForeColor = Color.FromArgb(34, 139, 34); //GREEN      
                //m.WriteMemory(dwPlayerRanking, "float", "0"); //player ranking
                //m.WriteMemory(dwItemMallDelay, "float", "0"); //itemmall
                //m.WriteMemory(dwBankDelay, "float", "0"); //bankk
                m.WriteMemory(dwUnliChat, "byte", "EB"); //unli_chat
                m.WriteMemory(dwFastTeleport, "float", "0"); //fast tele
                m.WriteMemory(dwBoardDelay, "byte", "EB"); //board delay               
                m.WriteMemory(dwStartPointTW, "byte", "EB"); //sp in tw
                

                MySqlCommand update = new MySqlCommand("UPDATE u687082794_randatabase.accounts SET ipaddress = @ipaddress WHERE username = @user;", connection);
                update.Parameters.AddWithValue("@user", login.username);
                update.Parameters.AddWithValue("@ipaddress", ipaddr);
                update.ExecuteNonQueryAsync();
            }
            else
            {
                ProcessExeLabel.Text = "Not Found";
                StatusValueLabel.Text = "WAITING";
                StatusValueLabel.ForeColor = Color.FromArgb(255, 0, 0); //RED
                PIDValueLabel.Text = "WAITING";
            }  
            PIDValueLabel.Text = Convert.ToString(m.GetProcIdFromName(gameclient));
        }

        private void BGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BGWorker.RunWorkerAsync();
        }

        private string getPublicIpAddress()
        {
            try
            {
                string url = "http://checkip.dyndns.org";
                System.Net.WebRequest req = System.Net.WebRequest.Create(url);
                System.Net.WebResponse resp = req.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                string response = sr.ReadToEnd().Trim();
                string[] ipAddressWithText = response.Split(':');
                string ipAddressWithHTMLEnd = ipAddressWithText[1].Substring(1);
                string[] ipAddress = ipAddressWithHTMLEnd.Split('<');
                string mainIP = ipAddress[0];
                Console.WriteLine(mainIP);
                sr.Close();
                resp.Close();
                return mainIP;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Could not get IP";
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            BGWorker.RunWorkerAsync();
            FormTime.Start();
            connection = new MySqlConnection(connectionString);
            connection.Open();
            command = new MySqlCommand("SELECT * FROM u687082794_randatabase.accounts WHERE username = @user", connection);
            command.Parameters.AddWithValue("@user", login.username);
            command.ExecuteNonQuery();
            account_label.Text = account_label.Text + " " + login.username;
            lastlogin_label.Text = lastlogin_label.Text + " " + login.lastlogin;
            if (ADMIN_LOGIN == 0)
            {
                accounts_btn.Hide();
            }
            if (ADMIN_LOGIN == 1)
            {
                accounts_btn.Show();
            }
            INITComboBoxFunc();

        }

        private void INITComboBoxFunc() { 
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

        // FOR LR VALUES
            //Init Data
            List<LRLevels> listLRLevels = new List<LRLevels>
            {
                new LRLevels() { LRLevel = "Default", LRLevelVal = "4" },
                new LRLevels() { LRLevel = "Level 2", LRLevelVal = "8" },
                new LRLevels() { LRLevel = "Level 3", LRLevelVal = "10" },
                new LRLevels() { LRLevel = "Level 4", LRLevelVal = "12" },
                new LRLevels() { LRLevel = "Level 5", LRLevelVal = "14" }
            };
            //Set display member and value member
            LRComboBox.DataSource = listLRLevels;
            LRComboBox.DisplayMember = "LRLevel";
            LRComboBox.ValueMember = "LRLevelVal";
            LRComboBox.SelectedIndex = 0;
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
                MySqlCommand update = new MySqlCommand("UPDATE accounts SET active = active - 1,lastlogin = @date WHERE username = @user;", connection);
                update.Parameters.AddWithValue("@date", Convert.ToDateTime(DateTime.Now));
                update.Parameters.AddWithValue("@user", login.username);
                update.ExecuteNonQueryAsync();
                Application.Exit();
            }
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MySqlCommand update = new MySqlCommand("UPDATE accounts SET active = active - 1,lastlogin = @date WHERE username = @user;", connection);
            update.Parameters.AddWithValue("@date", Convert.ToDateTime(DateTime.Now));
            update.Parameters.AddWithValue("@user", login.username);
            update.ExecuteNonQueryAsync();
            Application.Exit();
        }

        private void accounts_btn_Click(object sender, EventArgs e)
        {
            admin adminfrm;
            bool formOpened = false;
            if (!formOpened) {
                adminfrm = new admin();
                adminfrm.Show();
                formOpened = true;
            }
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
        private void HPFButton_Click(object sender, EventArgs e)
        {
            if (!HPF)
            {
                Console.WriteLine("HPF Turned ON");
                HPFButton.Text = "ON";
                m.FreezeValue(hpfAddress, "bytes", "09 01 09");
                m.FreezeValue(hpfAddress2, "byte", "255");
                HPF = true;
            }
            else
            {
                Console.WriteLine("HPF Turned OFF");
                HPFButton.Text = "OFF";
                m.UnfreezeValue(hpfAddress);
                m.UnfreezeValue(hpfAddress2);
                HPF = false;
            }

        }



        private void DroneComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DroneLevels droneLevelsObj = DroneComboBox.SelectedItem as DroneLevels;
            float curDroneLevel = m.ReadFloat(droneAddress); 
            m.FreezeValue(droneAddress, "float", droneLevelsObj.DroneLevelVal);
            //m.WriteMemory(droneAddressActive, "float", (curDroneLevel - 5).ToString());

            Console.WriteLine("Drone Level: " + droneLevelsObj.DroneLevelVal);            
            Console.WriteLine("Current Drone Level: " + curDroneLevel);

        }

        private void LRComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LRLevels lrLevelsObj = LRComboBox.SelectedItem as LRLevels;
            if (lrLevelsObj != null) {
                if (lrLevelsObj.LRLevel == "Default")
                {
                    m.WriteMemory(dwRangeFree, "byte", lrLevelsObj.LRLevelVal);
                    m.WriteMemory(dwRangeLR, "bytes", dwRangeLROffValue);
                    //m.WriteMemory(dwNOTAR1, "bytes", "0F 85 1A 01 00");
                    //m.WriteMemory(dwNOTAR2, "bytes", "0F 85 F3 00 00");
                    m.WriteMemory(dwRangeWalkBypass, "bytes", "0F B7 0D 68 D2 98 00");
                    m.WriteMemory(dwRangeDropBypass, "bytes", "0F B7 05 68 D2 98 00");
                }
                else if (lrLevelsObj.LRLevel == "Level 5")
                {
                    m.WriteMemory(dwRangeFree, "byte", lrLevelsObj.LRLevelVal);
                    m.WriteMemory(dwRangeLR, "bytes", dwRangeLROnValue);
                    //m.WriteMemory(dwNOTAR1, "bytes", "E9 1B 01 00 00");
                    //m.WriteMemory(dwNOTAR2, "bytes", "E9 F4 00 00 00");
                    m.WriteMemory(dwRangeWalkBypass, "bytes", "90 90 90 90 90 90 90");
                    m.WriteMemory(dwRangeDropBypass, "bytes", "90 90 90 90 90 90 90");
                }
                else {
                    m.WriteMemory(dwRangeFree, "byte", lrLevelsObj.LRLevelVal);
                    m.WriteMemory(dwRangeLR, "bytes", dwRangeLROnValue);
                    m.WriteMemory(dwRangeWalkBypass, "bytes", "90 90 90 90 90 90 90");
                    m.WriteMemory(dwRangeDropBypass, "bytes", "90 90 90 90 90 90 90");
                }
            }                  
        }
 

        private void AOELRButton_Click(object sender, EventArgs e)
        {
            if (!AoeLR)
            {
                AOELRButton.Text = "ON";
                //m.WriteMemory(dwRange, "byte", "4"); //ADD RANGE
                //m.WriteMemory(dwRangeFree, "byte", "4"); //Free Address AOE
                //m.WriteMemory(bodyRadWalkBypass, "bytes", "90 90 90 90 90 90 90");
                //m.WriteMemory(bodyRadDropBypass, "bytes", "90 90 90 90 90 90 90");
                //m.WriteMemory(dwRangeLR, "bytes", dwRangeLROnValue);
                //m.WriteMemory(dwDD1, "byte", "75"); //For DD1
                //m.WriteMemory(dwDD2, "byte", "75"); //For DD2
                //m.WriteMemory(dwNOTAR1, "bytes", "E9 1B 01 00 00"); //notar lr 1
                //m.WriteMemory(dwNOTAR2, "bytes", "E9 F4 00 00 00"); //notar lr 2
                m.WriteMemory(dw5b, "bytes", "8D 44 11 5B"); //eax,[ecx+edx+5B]
                //m.WriteMemory(dw1up, "bytes", "90 90 90 90 90 90 90"); //1-6 up 1-2 down
                //m.WriteMemory(dw2up, "bytes", "90 90 90 90 90 90 90");
                //m.WriteMemory(dw3up, "bytes", "90 90 90 90 90 90 90");
                //m.WriteMemory(dw4up, "bytes", "90 90 90 90 90 90 90");
                //m.WriteMemory(dw5up, "bytes", "90 90 90 90 90 90 90");
                //m.WriteMemory(dw6up, "bytes", "90 90 90 90 90 90 90");
                //m.WriteMemory(dw1down, "bytes", "90 90 90 90 90 90 90");
                //m.WriteMemory(dw2down, "bytes", "90 90 90 90 90 90 90");
                m.WriteMemory(dw2eaxeax, "bytes", dw2eaxeaxOnValue); //push 45 69, below mov call enter,  scroll down call edx+30, push eax, call enter, scroll down xor eax,eax
                AoeLR = true;
            }
            else
            {
                AOELRButton.Text = "OFF";
                //m.WriteMemory(dwRange, "byte", "4"); //ADD RANGE
                //m.WriteMemory(dwRangeFree, "byte", "4"); //Free Address AOE
                //m.WriteMemory(bodyRadWalkBypass, "bytes", "66 8B 0D CC F7 9B");
                //m.WriteMemory(bodyRadDropBypass, "bytes", "0F B7 05 CC F7 9B");
                //m.WriteMemory(dwRangeLR, "bytes", dwRangeLROffValue);
                //m.WriteMemory(dwDD1, "byte", "74"); //For DD1
                //m.WriteMemory(dwDD2, "byte", "74"); //For DD2
                //m.WriteMemory(dwNOTAR1, "bytes", "0F 85 1A 01 00"); //notar lr 1
                //m.WriteMemory(dwNOTAR2, "bytes", "0F 85 F3 00 00"); //notar lr 2
                m.WriteMemory(dw5b, "bytes", "8D 44 11 02"); //eax,[ecx+edx+5B]
                //m.WriteMemory(dw1up, "bytes", "0F B7 05 2C F6 9B 00"); //1-6 up 1-2 down
                //m.WriteMemory(dw2up, "bytes", "0F B7 05 2C F6 9B 00");
                //m.WriteMemory(dw3up, "bytes", "0F B7 0D 2C F6 9B 00");
                //m.WriteMemory(dw4up, "bytes", "0F B7 05 2C F6 9B 00");
                //m.WriteMemory(dw5up, "bytes", "0F B7 0D 2C F6 9B 00");
                //m.WriteMemory(dw6up, "bytes", "0F B7 0D 2C F6 9B 00");
                //m.WriteMemory(dw1down, "bytes", "0F B7 05 2C F6 9B 00");
                //m.WriteMemory(dw2down, "bytes", "0F B7 05 2C F6 9B 00");
                m.WriteMemory(dw2eaxeax, "bytes", dw2eaxeaxOffValue); //push 45 69, below mov call enter,  scroll down call edx+30, push eax, call enter, scroll down xor eax,eax
                AoeLR = false;
            }

        }

        private void QAPButton_Click(object sender, EventArgs e)
        {
            if (!AP)
            {
                QAPButton.Text = "ON";
                Console.WriteLine("Q AP ON");
                m.WriteMemory(qAutoPots, "byte", "1");
                m.WriteMemory(qAutoPots2, "byte", "0");
                AP = true;
            }
            else
            {
                QAPButton.Text = "OFF";
                Console.WriteLine("Q AP OFF");
                m.WriteMemory(qAutoPots, "byte", "2");
                m.WriteMemory(qAutoPots2, "byte", "2");
                AP = false;
            }
        }

        private void piercethruwallsButton_Click(object sender, EventArgs e)
        {


            if (!isPierce)
            {
                piercethruwallsButton.Text = "ON";
                m.WriteMemory(dwNameWallHack, "byte", "EB");
                m.WriteMemory(pierceThruWalls1, "bytes", "90 90 90 90");
                //m.WriteMemory(pierceThruWalls2, "bytes", "90 90 90 90");
                isPierce = true;

            }
            else
            {
                piercethruwallsButton.Text = "OFF";
                m.WriteMemory(dwNameWallHack, "byte", "74");
                m.WriteMemory(pierceThruWalls1, "bytes", "D9 44 24 44");
                //m.WriteMemory(pierceThruWalls2, "bytes", "D9 44 24 20");
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
