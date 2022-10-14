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
    public partial class RenameForm : Form
    {
        public RenameForm()
        {
            InitializeComponent();
        }
        internal string thisNewName;
        public string RenameContentNewName
        {
            get
            {
                return thisNewName;
            }
            set
            {
                thisNewName = value;
            }
        }
        internal ModsMenu thisSelfSharing;
        public ModsMenu RenameContentSelfSharing
        {
            get
            {
                return thisSelfSharing;
            }
            set
            {
                thisSelfSharing = value;
            }
        }
        internal Settings.Settings.Modification thisContextMod;
        public Settings.Settings.Modification RenameContentMod
        {
            get
            {
                return thisContextMod;
            }
            set
            {
                thisContextMod = value;
            }
        }
        private void buttonSaveNewNameContent_Click(object sender, EventArgs e)
        {
            thisNewName = textBoxNewName.Text;
            thisSelfSharing.CatchEventRenameForm(this, true);
        }

        private void buttonRenameContentExit_Click(object sender, EventArgs e)
        {
            thisSelfSharing.CatchEventRenameForm(this, false);
        }
    }
}
