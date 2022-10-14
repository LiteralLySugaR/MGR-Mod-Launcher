using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using MGRModLauncher.Settings;

namespace MGRModLauncher.Settings
{
    public class Settingsmanager
    {
        internal void UpdateAllSettings()
        {
            Settings.Path = ReadLauncherSettings("path");
            Settings.EnableNewMods = Convert.ToBoolean(ReadLauncherSettings("enableNewMods"));
            Settings.isLogging = Convert.ToBoolean(ReadLauncherSettings("logging"));
            Settings.Language = ReadLauncherSettings("language");
            Settings.Theme = Convert.ToInt32(ReadLauncherSettings("theme"));
            string str = ReadLauncherSettings("enabledMods");
            if (!str.Contains(","))
            {
                Settings.EnabledMods.Add(str);
            }
            else
            {
                string[] str1 = str.Split(',');
                foreach (string str2 in str1)
                {
                    Settings.EnabledMods.Add(str2);
                }
            }
        }
        internal void SetupLauncherSettings()
        {
            if (!File.Exists(@"LauncherData\launcherSettings.txt"))
            {
                Process process = new Process();
                foreach (Process processes in Process.GetProcesses())
                {
                    if (processes.ProcessName == "MGRModLauncher")
                    {
                        process = processes;
                    }
                }
                string path = process.MainModule.FileName;
                string pathRemove = "MGRModLauncher.exe";
                string[] lines = new string[6];
                lines[0] = $"path={path.Substring(0, path.Length - pathRemove.Length)}";
                lines[1] = $"theme=0";
                lines[2] = $"language=english";
                lines[3] = $"logging=True";
                lines[4] = $"enableNewMods=True";
                lines[5] = $"enabledMods=void,";
                Directory.CreateDirectory(@"LauncherData\");
                File.Create(@"LauncherData\launcherSettings.txt").Close();
                File.WriteAllLines($@"LauncherData\launcherSettings.txt", lines);
            }
        }
        internal void DefaultLauncherSettings()
        {
            Process process = new Process();
            foreach (Process processes in Process.GetProcesses())
            {
                if (processes.ProcessName == "MGRModLauncher")
                {
                    process = processes;
                }
            }
            string path = process.MainModule.FileName;
            string pathRemove = "MGRModLauncher.exe";
            string[] lines = new string[6];
            lines[0] = $"path={path.Substring(0, path.Length - pathRemove.Length)}";
            lines[1] = $"theme=0";
            lines[2] = $"language=english";
            lines[3] = $"logging=True";
            lines[4] = $"enableNewMods=True";
            lines[5] = $"enabledMods=void,";
            File.Create(@"LauncherData\launcherSettings.txt").Close();
            File.WriteAllLines($@"LauncherData\launcherSettings.txt", lines);
        }
        internal void ReplaceLauncherSettings(string path, int theme, string language, bool logging, bool enableNewMods, List<string> ModList)
        {
            string enabledMods = string.Join(",", ModList);
            if (!File.Exists(@"LauncherData\launcherSettings.txt"))
            {
                string[] lines = new string[6];
                lines[0] = $"path={path}";
                lines[1] = $"theme={theme}";
                lines[2] = $"language={language}";
                lines[3] = $"logging={logging}";
                lines[4] = $"enableNewMods={enableNewMods}";
                lines[5] = $"enabledMods={enabledMods}";
                Directory.CreateDirectory(@"LauncherData\");
                File.Create(@"LauncherData\launcherSettings.txt").Close();
                File.WriteAllLines($@"LauncherData\launcherSettings.txt", lines);
            }
            else
            {
                string[] lines = new string[6];
                lines[0] = $"path={path}";
                lines[1] = $"theme={theme}";
                lines[2] = $"language={language}";
                lines[3] = $"logging={logging}";
                lines[4] = $"enableNewMods={enableNewMods}";
                lines[5] = $"enabledMods={enabledMods}";
                File.WriteAllLines($@"LauncherData\launcherSettings.txt", lines);
            }
        }
        internal string ReadLauncherSettings(string setting)
        {
            string str1 = "";
            if (File.Exists(@"LauncherData\launcherSettings.txt"))
            {
                foreach (string str in File.ReadAllLines(@"LauncherData\launcherSettings.txt"))
                {
                    if (str.StartsWith(setting))
                    {
                        str1 = str.Split(new char[1] { '=' })[1];
                    }
                }
            }
            return str1;
        }
    }
}
