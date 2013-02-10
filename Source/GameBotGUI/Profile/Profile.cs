using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GameBotGUI
{
    class Profile
    {
        public readonly String Name;
        public readonly String FullName;
        public readonly String FilePath;

        public Profile(String name, String path)
        {
            Int32 pos = name.LastIndexOf(Path.DirectorySeparatorChar);
            Name = name;
            FullName = name.Substring((name.Substring(0, pos)).LastIndexOf(Path.DirectorySeparatorChar) + 1);
            FilePath = path;
        }
    }
}
