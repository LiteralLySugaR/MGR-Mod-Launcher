using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MGRModLauncher.Settings;

namespace MGRModLauncher
{
    public partial class Form2 : Form
    {
        Settingsmanager SettingsManager = new Settingsmanager();
        public Form2()
        {
            InitializeComponent();
            CustomizeDesignSP();
            Settings.Settings.Path = SettingsManager.ReadLauncherSettings("path");
            Settings.Settings.EnableNewMods = Convert.ToBoolean(SettingsManager.ReadLauncherSettings("enableNewMods"));
            Settings.Settings.isLogging = Convert.ToBoolean(SettingsManager.ReadLauncherSettings("logging"));
            Settings.Settings.Language = SettingsManager.ReadLauncherSettings("language");
            Settings.Settings.Theme = Convert.ToInt32(SettingsManager.ReadLauncherSettings("theme"));
        }
        private void CustomizeDesignSP()
        {
            panelModsActionSettings.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panelModsActionSettings.Visible)
            {
                panelModsActionSettings.Visible = false;
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
        private void buttonModsAction_Click(object sender, EventArgs e)
        {
            showSubMenu(panelModsActionSettings);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
