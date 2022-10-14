using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGRModLauncher.Localisation
{
    public class LocalisationHandler
    {
        internal bool CheckLanguage(string lang)
        {
            bool returnBool = false;
            if (!lang.Equals("english"))
            {
                returnBool = SetLanguage();
            }
            return returnBool;
        }
        internal bool SetLanguage()
        {
            return true;
        }
    }
}
