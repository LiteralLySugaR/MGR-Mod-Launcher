using System.IO;

namespace MGRModLauncher.Settings
{
    public class ModsManager
    {
        internal void UpdateModParameters(Settings.Modification modification)
        {
            string[] lines = new string[5];
            lines[0] = $"name={modification.Name}";
            lines[1] = $"path={modification.Path}";
            lines[2] = $"id={modification.ID}";
            lines[3] = $"filename={modification.FileName}";
            lines[4] = $"isloaded={modification.isLoaded}";
            File.WriteAllLines($"{modification.FullPath}", lines);
        }
        internal void UpdateParameters(Settings.Modification modification, string name, string path, int id, string filename, bool isloaded)
        {
            string[] lines = new string[5];
            lines[0] = $"name={name}";
            lines[1] = $"path={path}";
            lines[2] = $"id={id}";
            lines[3] = $"filename={filename}";
            lines[4] = $"isloaded={isloaded}";
            File.WriteAllLines($"{modification.FullPath}", lines);
        }
        //internal string ReadParameter(string parameter, string modPath)
        //{
        //    string str1 = "";
        //    if (File.Exists($"{modPath}"))
        //    {
        //        foreach (string str in File.ReadAllLines($"{modPath}"))
        //        {
        //            if (str.StartsWith(parameter))
        //            {
        //                str1 = str.Split(new char[1] { '=' })[1];
        //            }
        //        }
        //    }
        //    return str1;
        //}
    }
}
