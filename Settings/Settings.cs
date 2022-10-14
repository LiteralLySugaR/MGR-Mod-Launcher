using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MGRModLauncher.ModsMenu;

namespace MGRModLauncher.Settings
{
    public class Settings
    {
        internal static string Path { get; set; }
        internal static int Theme { get; set; }
        internal static string Language { get; set; }
        internal static bool isLogging { get; set; }
        internal static bool EnableNewMods { get; set; }
        internal static List<string> EnabledMods = new List<string>();
        public class Modification
        {
            public string Name;
            public int ID;
            public string Path;
            public string FileName;
            public bool isLoaded;
            public string FullPath;
        }
    }
}
