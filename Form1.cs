using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MGRModLauncher.Settings;

namespace MGRModLauncher
{
    public partial class Form1 : Form
    {
        Settingsmanager SettingsManager = new Settingsmanager();
        ModsMenu ModsMenu = null;
        public Form1()
        {
            if (!Directory.Exists("Mods\\"))
            {
                Directory.CreateDirectory("Mods\\");
            }
            SettingsManager.SetupLauncherSettings();
            InitializeComponent();
            CustomizeDesign();
            Settings.Settings.Path = SettingsManager.ReadLauncherSettings("path");
            Settings.Settings.EnableNewMods = Convert.ToBoolean(SettingsManager.ReadLauncherSettings("enableNewMods"));
            Settings.Settings.isLogging = Convert.ToBoolean(SettingsManager.ReadLauncherSettings("logging"));
            Settings.Settings.Language = SettingsManager.ReadLauncherSettings("language");
            Settings.Settings.Theme = Convert.ToInt32(SettingsManager.ReadLauncherSettings("theme"));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //SettingsManager.SetupLauncherSettings();
            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(DonationButton, "You will get redirected to DonationAlerts.");
            toolTip.SetToolTip(YoutubeSubButton, "You will get redirected to YouTube.");
        }
        private void CustomizeDesign()
        {
            SettingsPanel.Visible = false;
            AboutPanel.Visible = false;
            MainPanel.Visible = false;
        }
        private void hideSubMenu()
        {
            if (SettingsPanel.Visible)
            {
                SettingsPanel.Visible = false;
            }
            if (AboutPanel.Visible)
            {
                AboutPanel.Visible = false;
            }
            if (MainPanel.Visible)
            {
                MainPanel.Visible = false;
            }
        }
        private void showSubMenu(Panel subMenu)
        {
            if (!subMenu.Visible)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void SettingsMenuButton_Click(object sender, EventArgs e)
        {
            showSubMenu(SettingsPanel);
        }

        private void AboutMenu_Click(object sender, EventArgs e)
        {
            showSubMenu(AboutPanel);
        }

        private void DonationButton_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://www.donationalerts.com/r/beautifuljuly");
            Process.Start(sInfo);
        }
        private void YoutubeSubButton_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://www.youtube.com/channel/UCSp0uYU7ye0FrcV12DkXGVA/about");
            Process.Start(sInfo);
        }

        private Form ActiveForm = null;
        private void openChildForm(Form ChildForm)
        {
            if (ActiveForm != null)
            {
                ActiveForm.Close();
            }
            ActiveForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(ChildForm);
            panelChildForm.Tag = ChildForm;
            ChildForm.Show();
        }
        private Form openChildFormReturn(Form ChildForm)
        {
            if (ActiveForm != null)
            {
                ActiveForm.Close();
            }
            ActiveForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(ChildForm);
            panelChildForm.Tag = ChildForm;
            ChildForm.Show();
            return ChildForm;
        }

        //private void MainMenuButton_Click(object sender, EventArgs e)
        //{
        //    openChildForm(new Form2());
        //    showSubMenu(MainPanel);
        //}

        private void IUMenuSubButton_Click(object sender, EventArgs e)
        {
            openChildForm(new SettingsInterface());
        }

        private void ParamsMenuSubButton_Click(object sender, EventArgs e)
        {
            openChildForm(new SettingsParams());
        }

        private void ModsMenuButton_Click(object sender, EventArgs e)
        {
            ModsMenu = (ModsMenu)openChildFormReturn(new ModsMenu());
            showSubMenu(MainPanel);
        }

        private void MiscMenuSubButton_Click(object sender, EventArgs e)
        {
            openChildForm(new SettingsMisc());
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //private void Logg(string log)
        //{
        //    if (!File.Exists($"{Settings.Settings.Path}logg.txt"))
        //    {
        //        File.Create($"{Settings.Settings.Path}logg.txt").Close();
        //    }
        //    StreamWriter sw = new StreamWriter($"{Settings.Settings.Path}logg.txt", true);
        //    sw.WriteLine(log);
        //    sw.Flush();
        //    sw.Close();
        //}
        private async void buttonLaunchGame_Click(object sender, EventArgs e)
        {
            List<string> FileNames = new List<string>();
            List<string> DirList = new List<string>();
            List<Settings.Settings.Modification> ModsList = new List<Settings.Settings.Modification>();
            string[] files = Directory.GetFiles(@"Mods\", "*.mgrmod", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                Settings.Settings.Modification MGRmod = new Settings.Settings.Modification();
                string[] dividedPath = file.Split(new string[] { $"{Settings.Settings.Path}" }, StringSplitOptions.RemoveEmptyEntries);
                string shortPath = dividedPath[0];
                bool nameChecked = false;
                bool idChecked = false;
                bool loadChecked = false;
                foreach (string str in File.ReadAllLines(shortPath))
                {
                    if (str.StartsWith("name="))
                    {
                        MGRmod.Name = str.Split(new char[1] { '=' })[1];
                        nameChecked = true;
                    }
                    if (str.StartsWith("path="))
                    {
                        MGRmod.Path = str.Split(new char[1] { '=' })[1];
                    }
                    if (str.StartsWith("filename="))
                    {
                        MGRmod.FileName = str.Split(new char[1] { '=' })[1];
                    }
                    if (str.StartsWith("id="))
                    {
                        MGRmod.ID = Convert.ToInt32(str.Split(new char[1] { '=' })[1]);
                        idChecked = true;
                    }
                    if (str.StartsWith("isloaded="))
                    {
                        MGRmod.isLoaded = Convert.ToBoolean(str.Split(new char[1] { '=' })[1]);
                        loadChecked = true;
                    }
                    if (MGRmod.FileName != null && MGRmod.Path != null && nameChecked && idChecked && loadChecked && !ModsList.Contains(MGRmod))
                    {
                        MGRmod.FullPath = file;
                        ModsList.Add(MGRmod);
                    }
                }
            }
            foreach (Settings.Settings.Modification Mod in ModsList)
            {
                if (Mod.isLoaded && !FileNames.Contains(Mod.FileName))
                {
                    FileNames.Add(Mod.FileName);
                }
            }
            var directories = Directory.GetDirectories($"Mods\\", "*.*", SearchOption.AllDirectories);
            foreach (var Dir in directories)
            {
                foreach (var FN in FileNames)
                {
                    if (Dir.Contains(FN))
                    {
                        DirList.Add(Dir);
                    }
                }
                foreach (Settings.Settings.Modification Mod in ModsMenu.ModList)
                {
                    Directory.CreateDirectory(Dir.Replace($"Mods\\{Mod.FileName}\\", $"GameData\\"));
                }
            }
            foreach (Settings.Settings.Modification Mod in ModsMenu.ModList)
            {
                foreach (string newPath in Directory.GetFiles($"Mods\\{Mod.FileName}\\", "*.*", SearchOption.AllDirectories))
                {
                    if (newPath.Contains(".mgrmod")) { continue; }
                    File.Copy(newPath, newPath.Replace($"Mods\\{Mod.FileName}\\", $"GameData\\"), true);
                }
            }
            //if (ModsMenu != null)
            //{
            //    foreach (Settings.Settings.Modification Mod in ModsMenu.ModList)
            //    {
            //        if (Mod.isLoaded)
            //        {
            //            FileNames.Add(Mod.FileName);
            //        }
            //    }
            //    var directories = Directory.GetDirectories($"Mods\\");
            //    foreach (var Dir in directories)
            //    {
            //        foreach (var FN in FileNames)
            //        {
            //            if (Dir.Contains(FN))
            //            {
            //                DirList.Add(Dir);
            //            }
            //        }
            //        foreach (Settings.Settings.Modification Mod in ModsMenu.ModList)
            //        {
            //            Directory.CreateDirectory(Dir.Replace($"Mods\\{Mod.FileName}\\", $"GameData\\"));
            //        }
            //    }
            //    foreach (Settings.Settings.Modification Mod in ModsMenu.ModList)
            //    {
            //        foreach (string newPath in Directory.GetFiles($"Mods\\{Mod.FileName}\\", " *.*", SearchOption.AllDirectories))
            //        {
            //            File.Copy(newPath, newPath.Replace($"Mods\\{Mod.FileName}\\", $"GameData\\"), true);
            //        }
            //    }
            //}

            this.WindowState = FormWindowState.Minimized;
            Process.Start($@"{Settings.Settings.Path}METAL GEAR RISING REVENGEANCE.exe");
            await Task.Delay(1000 * 2);
            Process process = new Process();
            foreach (Process process1 in Process.GetProcesses())
            {
                if (process1.ProcessName == "METAL GEAR RISING REVENGEANCE")
                {
                    process = process1;
                }
            }
            process.WaitForExit();
            await Task.Delay(1000 * 1);

            string[] gameDirsToIgnore = new string[18];
            gameDirsToIgnore[0] = "movie";
            gameDirsToIgnore[1] = "movie_ui";
            gameDirsToIgnore[2] = "sound";
            gameDirsToIgnore[3] = "data000.cpk";
            gameDirsToIgnore[4] = "data001.cpk";
            gameDirsToIgnore[5] = "data002.cpk";
            gameDirsToIgnore[6] = "data003.cpk";
            gameDirsToIgnore[7] = "data004.cpk";
            gameDirsToIgnore[8] = "data005.cpk";
            gameDirsToIgnore[9] = "data006.cpk";
            gameDirsToIgnore[10] = "data104.cpk";
            gameDirsToIgnore[11] = "data105.cpk";
            gameDirsToIgnore[12] = "data106.cpk";
            gameDirsToIgnore[13] = "data107.cpk";
            gameDirsToIgnore[14] = "data108.cpk";
            gameDirsToIgnore[15] = "shadereff.dat";
            gameDirsToIgnore[16] = "shader.dat";
            gameDirsToIgnore[17] = "shader2.dat";
            string[] filePaths = Directory.GetFiles("GameData\\");
            string[] DirPaths = Directory.GetDirectories("GameData\\");
            foreach (string filePath in filePaths)
            {
                var name = new FileInfo(filePath).Name;
                name = name.ToLower();
                if (!gameDirsToIgnore.Contains(name))
                {
                    File.Delete(filePath);
                }
            }
            foreach (string DirPath in DirPaths)
            {
                var name = new FileInfo(DirPath).Name;
                name = name.ToLower();
                if (!gameDirsToIgnore.Contains(name))
                {
                    Directory.Delete(DirPath, true);
                }
            }

            this.WindowState = FormWindowState.Normal;
        }
    }
}
