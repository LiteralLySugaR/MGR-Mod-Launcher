using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MGRModLauncher.Settings;

namespace MGRModLauncher
{
    public partial class SettingsParams : Form
    {
        Settingsmanager SettingsManager = new Settingsmanager();
        public SettingsParams()
        {
            InitializeComponent();
            CustomizeDesignSP();
            Settings.Settings.Path = SettingsManager.ReadLauncherSettings("path");
            Settings.Settings.EnableNewMods = Convert.ToBoolean(SettingsManager.ReadLauncherSettings("enableNewMods"));
            Settings.Settings.isLogging = Convert.ToBoolean(SettingsManager.ReadLauncherSettings("logging"));
            Settings.Settings.Language = SettingsManager.ReadLauncherSettings("language");
            Settings.Settings.Theme = Convert.ToInt32(SettingsManager.ReadLauncherSettings("theme"));
            string str = SettingsManager.ReadLauncherSettings("enabledMods");
            if (!str.Contains(","))
            {
                Settings.Settings.EnabledMods.Add(str);
            }
            else
            {
                string[] str1 = str.Split(',');
                foreach (string str2 in str1)
                {
                    Settings.Settings.EnabledMods.Add(str2);
                }
            }
        }
        private void CustomizeDesignSP()
        {
            panelGameDirSetting.Visible = false;
            panelLoggingSettings.Visible = false;
            panelEnableModsSetting.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panelGameDirSetting.Visible)
            {
                panelGameDirSetting.Visible = false;
            }
            if (panelLoggingSettings.Visible)
            {
                panelLoggingSettings.Visible = false;
            }
            if (panelEnableModsSetting.Visible)
            {
                panelEnableModsSetting.Visible = false;
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
        private void buttonGameDirectory_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    GameDirTextBox.Text = fbd.SelectedPath;
                }
            }
        }

        private void buttonGameDir_Click(object sender, EventArgs e)
        {
            showSubMenu(panelGameDirSetting);
        }

        private void buttonEnableLogging_Click(object sender, EventArgs e)
        {
            showSubMenu(panelLoggingSettings);
        }

        private void buttonEnableNewMods_Click(object sender, EventArgs e)
        {
            showSubMenu(panelEnableModsSetting);
        }

        private void SettingsParams_Load(object sender, EventArgs e)
        {
            GameDirTextBox.Text = SettingsManager.ReadLauncherSettings("path");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SettingsManager.ReplaceLauncherSettings(GameDirTextBox.Text, Settings.Settings.Theme, Settings.Settings.Language, Settings.Settings.isLogging, Settings.Settings.EnableNewMods, Settings.Settings.EnabledMods);
            SettingsManager.UpdateAllSettings();
        }

        private void buttonRestore_Click(object sender, EventArgs e)
        {
            SettingsManager.DefaultLauncherSettings();
        }
    }
}
