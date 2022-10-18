using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using MGRModLauncher.Settings;

namespace MGRModLauncher
{
    public partial class ModsMenu : Form
    {
        Settingsmanager SettingsManager = new Settingsmanager();
        ModsManager ModsManager = new ModsManager();
        //public class Modification
        //{
        //    public string Name;
        //    public int ID;
        //    public string Path;
        //    public string FileName;
        //    public bool isLoaded;
        //    public string FullPath;
        //}
        internal List<ModMenuModContent> ModForms = new List<ModMenuModContent>();
        internal List<Settings.Settings.Modification> ModList = new List<Settings.Settings.Modification>();
        internal bool isRenaming = false;
        public ModsMenu()
        {
            InitializeComponent();
            CustomizeDesign();
            //thiSettings.Path = SettingsManager.ReadLauncherSettings("path");
            //thiSettings.EnableNewMods = Convert.ToBoolean(SettingsManager.ReadLauncherSettings("enableNewMods"));
            //thiSettings.isLogging = Convert.ToBoolean(SettingsManager.ReadLauncherSettings("logging"));
            //thiSettings.Language = SettingsManager.ReadLauncherSettings("language");
            //thiSettings.Theme = Convert.ToInt32(SettingsManager.ReadLauncherSettings("theme"));
        }
        private void MGRModSaveData(Settings.Settings.Modification MGRmod, string shortPath, string fullPath)
        {
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
                if (MGRmod.FileName != null && MGRmod.Path != null && nameChecked && idChecked && loadChecked)
                {
                    MGRmod.FullPath = fullPath;
                    ModList.Add(MGRmod);
                }
            }
        }
        private void MGRModSetupList()
        {
            foreach (Settings.Settings.Modification mod in ModList)
            {
                //ModMenuModContent thisModContent = new ModMenuModContent();
                ModMenuModContent thisModContent = (ModMenuModContent)openChildForm(new ModMenuModContent(), mod.FileName);
                //modContent = (ModMenuModContent)thisModContent;
                if (mod.Name == mod.FileName || mod.Name == null || mod.Name == "")
                {
                    thisModContent.ThisModContextText = $"{mod.FileName}";
                }
                if (mod.Name != mod.FileName && mod.Name != null && mod.Name != "")
                {
                    thisModContent.ThisModContextText = $"{mod.Name} ({mod.FileName})";
                }
                thisModContent.ThisModContext = mod;
            }
        }
        private void ModsMenu_Load(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(@"Mods\", "*.mgrmod", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                Settings.Settings.Modification MGRmod = new Settings.Settings.Modification();
                string[] dividedPath = file.Split(new string[] { $"{Settings.Settings.Path}" }, StringSplitOptions.RemoveEmptyEntries);
                string shortPath = dividedPath[0];
                MGRModSaveData(MGRmod, shortPath, file);
            }
            MGRModSetupList();
        }
        private Form openChildForm(Form ChildForm, string TAG)
        {
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Top;
            ModListChildForm.Controls.Add(ChildForm);
            ChildForm.Show();
            ModForms.Add((ModMenuModContent)ChildForm);
            ModMenuModContent thisModContent = (ModMenuModContent)ChildForm;
            thisModContent.ModContextSpecialID = TAG;
            return ChildForm;
        }
        private Form openChildFormClear(Form ChildForm)
        {
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ModListChildForm.Controls.Add(ChildForm);
            ChildForm.Show();
            ChildForm.BringToFront();
            return ChildForm;
        }
        private void closeChildForm(Form ChildForm)
        {
            ModListChildForm.Controls.Remove(ChildForm);
            //ModListChildForm.Tag = ChildForm;
            ChildForm.Close();
            ChildForm.Tag = "";
            ModForms.Remove((ModMenuModContent)ChildForm);
        }
        private void ModActionButton_Click(object sender, EventArgs e)
        {
            showSubMenu(ModActionsPanel);
        }

        private void ModsManagebutton_Click(object sender, EventArgs e)
        {
            showSubMenu(panelModsManage);
        }
        private void CustomizeDesign()
        {
            ModActionsPanel.Visible = false;
            panelModsManage.Visible = false;
        }
        private void hideSubMenu()
        {
            if (ModActionsPanel.Visible)
            {
                ModActionsPanel.Visible = false;
            }
            if (panelModsManage.Visible)
            {
                panelModsManage.Visible = false;
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

        private void SelectAllSubButton_Click(object sender, EventArgs e)
        {
            foreach (ModMenuModContent ModContent in ModForms)
            {
                if (!ModContent.ModContextStateSelected)
                {
                    ModContent.ModContextStateSelected = true;
                    ModContent.UpdateOnCall();
                }
            }
        }

        private void LoadSelectedSubButton_Click(object sender, EventArgs e)
        {
            foreach (ModMenuModContent ModContent in ModForms)
            {
                if (ModContent.ModContextSpecialID == ModContent.thisMod.FileName && !ModContent.isLoaded)
                {
                    if (ModContent.isSelected) 
                    { 
                        ModContent.isLoaded = true;
                        MoveLoadedUnloaded(ModContent);
                    }
                    //Settings.Settings.EnabledMods.Add(ModContent.thisMod.FileName);
                    int indexID = Settings.Settings.EnabledMods.IndexOf(ModContent.thisMod.FileName);
                    SettingsManager.ReplaceLauncherSettings(Settings.Settings.Path,
                        Settings.Settings.Theme,
                        Settings.Settings.Language,
                        Settings.Settings.isLogging,
                        Settings.Settings.EnableNewMods,
                        Settings.Settings.EnabledMods);
                    ModsManager.UpdateParameters(ModContent.thisMod, ModContent.thisMod.Name, ModContent.thisMod.Path, indexID, ModContent.thisMod.FileName, true);
                }
                ModContent.UpdateMod();
            }
        }
        internal void MoveLoadedUnloaded(Form modMenuModContent)
        {
            List<ModMenuModContent> SaveFroms = new List<ModMenuModContent>();
            ModMenuModContent ModContent = (ModMenuModContent)modMenuModContent;
            List<string> ModString = new List<string>();

            //Moving Loaded to 0. (MODCONTEXT: adding loaded)
            if (ModContent.isLoaded)
            {
                modMenuModContent.SendToBack();
                ModMenuModContent contentFirst = ModContent;
                if (SaveFroms.Count <= 0)
                {
                    SaveFroms.Add(contentFirst);
                }

                foreach (ModMenuModContent modMenu in ModForms)
                {
                    if (!SaveFroms.Contains(modMenu) && modMenu != null)
                    {
                        SaveFroms.Add(modMenu);
                    }
                    ModString.Add(modMenu.thisMod.FileName);
                }
                ModForms = SaveFroms;

                Settings.Settings.EnabledMods.Clear();
                foreach (ModMenuModContent modMenu in ModForms)
                {
                    foreach (string str in ModString)
                    {
                        if (modMenu.isLoaded && modMenu.thisMod.FileName == str && !Settings.Settings.EnabledMods.Contains(str))
                        {
                            Settings.Settings.EnabledMods.Add(str);
                        }
                    }
                }
            }

            //Moving Unloaded to last. (MODCONTEXT: removing unloaded)
            if (!ModContent.isLoaded)
            {
                modMenuModContent.BringToFront();
                ModMenuModContent contentLast = ModContent;
                ModMenuModContent contentFirst = ModForms[0];
                if ((contentFirst, contentLast) != (null, null) && SaveFroms.Count <= 0)
                {
                    SaveFroms.Add(contentFirst);
                    SaveFroms.Add(contentLast);
                }

                foreach (ModMenuModContent modMenu in ModForms)
                {
                    if (!SaveFroms.Contains(modMenu) && modMenu != null)
                    {
                        SaveFroms.Remove(contentLast);
                        SaveFroms.Add(modMenu);
                        SaveFroms.Add(contentLast);
                    }
                    ModString.Add(modMenu.thisMod.FileName);
                }
                ModForms = SaveFroms;

                Settings.Settings.EnabledMods.Clear();
                foreach (ModMenuModContent modMenu in ModForms)
                {
                    foreach (string str in ModString)
                    {
                        if (modMenu.isLoaded && modMenu.thisMod.FileName == str && !Settings.Settings.EnabledMods.Contains(str))
                        {
                            Settings.Settings.EnabledMods.Add(str);
                        }
                    }
                }
            }
        }

        private void UnloadSelectedSubButton_Click(object sender, EventArgs e)
        {
            foreach (ModMenuModContent ModContent in ModForms)
            {
                if (ModContent.ModContextSpecialID == ModContent.thisMod.FileName && ModContent.isLoaded && ModContent.isSelected)
                {
                    ModContent.ModContextStateLoaded = false;
                    if (!ModContent.isLoaded && ModContent.isSelected)
                    {
                        MoveLoadedUnloaded(ModContent);
                    }
                    //Settings.Settings.EnabledMods.Remove(ModContent.thisMod.FileName);
                    SettingsManager.ReplaceLauncherSettings(Settings.Settings.Path,
                        Settings.Settings.Theme,
                        Settings.Settings.Language,
                        Settings.Settings.isLogging,
                        Settings.Settings.EnableNewMods,
                        Settings.Settings.EnabledMods);
                    ModsManager.UpdateParameters(ModContent.thisMod, ModContent.thisMod.Name, ModContent.thisMod.Path, 0, ModContent.thisMod.FileName, false);
                }
                ModContent.UpdateMod();
            }
        }

        private void RenameModSubButton_Click(object sender, EventArgs e)
        {
            RenameForm renameForm = null;
            ModMenuModContent modMenuModContent = null;
            foreach (ModMenuModContent modContent in ModForms)
            {
                if (modContent.ModContextStateSelected)
                {
                    modMenuModContent = modContent;
                    renameForm = (RenameForm)openChildFormClear(new RenameForm());
                    renameForm.RenameContentSelfSharing = this;
                    break;
                }
            }
            if (modMenuModContent != null && renameForm != null)
            {
                foreach (Settings.Settings.Modification Mod in ModList)
                {
                    if (modMenuModContent.ModContextSpecialID == Mod.FileName)
                    {
                        renameForm.RenameContentMod = Mod;
                        break;
                    }
                }
            }
        }
        public void CatchEventRenameForm(RenameForm RenameForm, bool SaveEvent)
        {
            if (SaveEvent)
            {
                RenameForm.RenameContentMod.Name = RenameForm.RenameContentNewName;
                ModsManager.UpdateParameters(
                    RenameForm.RenameContentMod, 
                    RenameForm.RenameContentMod.Name, 
                    RenameForm.RenameContentMod.Path, 
                    RenameForm.RenameContentMod.ID, 
                    RenameForm.RenameContentMod.FileName, 
                    RenameForm.RenameContentMod.isLoaded);
            }
            RenameForm.Close();
            isRenaming = false;
            ModContentUpdateAll();
        }
        internal void ModContentUpdateAll()
        {
            foreach (ModMenuModContent modContent in ModForms)
            {
                modContent.UpdateMod();
            }
        }

        private void AddModSubButton_Click(object sender, EventArgs e)
        {

        }

        private void GenerateSubButton_Click(object sender, EventArgs e)
        {
            string[] Dirs = Directory.GetDirectories($@"Mods\");
            string[] MGRmods = Directory.GetFiles($@"Mods\", "*.mgrmod", SearchOption.AllDirectories);
            foreach (string str in Dirs)
            {
                foreach (string str1 in MGRmods)
                {
                    if (str1.Contains(str))
                    {
                        continue;
                    }
                    string[] sepDir = null;
                    sepDir = str.Split('\\');
                    File.Create($@"Mods\{sepDir[1]}\{sepDir[1]}.mgrmod").Close();
                    string[] lines = new string[5];
                    lines[0] = $"name=";
                    lines[1] = $@"path=Mods/{sepDir[1]}/";
                    lines[2] = "id=0";
                    lines[3] = $"filename={sepDir[1]}";
                    lines[4] = $"isloaded={false}";
                    File.WriteAllLines($@"Mods\{sepDir[1]}\{sepDir[1]}.mgrmod", lines);
                }
            }
        }
    }
}
