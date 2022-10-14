using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGRModLauncher
{
    public partial class SettingsInterface : Form
    {
        public SettingsInterface()
        {
            InitializeComponent();
            CustomizeDesignSP();
        }
        private void CustomizeDesignSP()
        {
            panelThemeSetting.Visible = false;
            panelLanguageSetting.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panelThemeSetting.Visible)
            {
                panelThemeSetting.Visible = false;
            }
            if (panelLanguageSetting.Visible)
            {
                panelLanguageSetting.Visible = false;
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
        private void buttonTheme_Click(object sender, EventArgs e)
        {
            showSubMenu(panelThemeSetting);
        }

        private void buttonLanguage_Click(object sender, EventArgs e)
        {
            showSubMenu(panelLanguageSetting);
        }
    }
}
