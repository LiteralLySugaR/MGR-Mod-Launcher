using MGRModLauncher.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGRModLauncher
{
    public partial class ModMenuModContent : Form
    {
        //public class Modification
        //{
        //    public string Name;
        //    public int ID;
        //    public string Path;
        //    public string FileName;
        //    public bool isLoaded;
        //    public string FullPath;
        //}
        Settingsmanager SettingsManager = new Settingsmanager();
        ModsManager ModsManager = new ModsManager();

        internal bool isLoaded;
        internal int selectInt = 0;
        internal bool isSelected;
        internal string SpecialID;
        internal Settings.Settings.Modification thisMod;
        public ModMenuModContent()
        {
            InitializeComponent();
            
            UpdateMod();
            UpdateOnCall();
        }
        public string ThisModContextText
        {
            get
            {
                return ModContextText.Text;
            }
            set
            {
                ModContextText.Text = value;
            }
        }
        public Settings.Settings.Modification ThisModContext
        {
            get
            {
                return thisMod;
            }
            set
            {
                thisMod = value;
            }
        }
        public bool ModContextStateLoaded
        {
            get
            {
                return isLoaded;
            }
            set
            {
                isLoaded = value;
            }
        }
        public string ModContextSpecialID
        {
            get
            {
                return SpecialID;
            }
            set
            {
                SpecialID = value;
            }
        }
        public bool ModContextStateSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                if (value == true) { selectInt = 1; }
                if (value == false) { selectInt = 0; }
                isSelected = value;
            }
        }

        private void ModViewIndicator_Click(object sender, EventArgs e)
        {
            selectInt++;
            isSelected = !isSelected;
            if (selectInt >= 2) { selectInt = 0; }
            UpdateOnCall();
        }

        private void ModContextText_Click(object sender, EventArgs e)
        {
            selectInt++;
            isSelected = !isSelected;
            if (selectInt >= 2) { selectInt = 0; }
            UpdateOnCall();
        }
        public async void UpdateMod()
        {
            await Task.Delay(100);
            string str1 = null;
            string[] str2 = null;
            string str3 = null;
            foreach (string str in File.ReadAllLines(SettingsManager.ReadLauncherSettings("path") + "LauncherData//launcherSettings.txt"))
            {
                if (str.StartsWith("enabledMods="))
                {
                    str1 = str.Split(new char[1] { '=' })[1];
                    if (str1.Contains(","))
                    {
                        str3 = str1;
                        str2 = str1.Split(',');
                    }
                    else
                    {
                        str3 = str1;
                    }
                    break;
                }
            }
            if (str3.Contains(","))
            {
                foreach (string str in str2)
                {
                    if (str.Equals(this.ModContextSpecialID))
                    {
                        ModContextStateLoaded = true;
                        break;
                    }
                }
            }
            else
            {
                if (str3.Equals(this.ModContextSpecialID))
                {
                    ModContextStateLoaded = true;
                }
            }
            if (isLoaded)
            {
                ModViewIndicator.BackColor = Color.FromArgb(89, 109, 98);
            }
            if (!isLoaded)
            {
                ModViewIndicator.BackColor = Color.FromArgb(109, 89, 98);
            }
            await Task.Delay(100);
            UpdateOnCall();
        }
        public void UpdateOnCall()
        {
            if (selectInt == 1)
            {
                ModViewIndicator.BackColor = Color.FromArgb(109, 109, 98);
            }
            if (isLoaded && selectInt == 0)
            {
                ModViewIndicator.BackColor = Color.FromArgb(89, 109, 98);
            }
            if (!isLoaded && selectInt == 0)
            {
                ModViewIndicator.BackColor = Color.FromArgb(109, 89, 98);
            }
        }
    }
}
