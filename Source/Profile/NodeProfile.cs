using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GameBotGUI.Node.Types;

namespace GameBotGUI.Profile
{
    [Serializable()]
    class NodeProfile
    {
        private String _name;

        public String Name { get { return _name; } set { Rename(value); } }
        public String FullName { get; private set; }
        public String FilePath { get; private set; }
        public List<GenericNode> NodeList { get; set; }
        
        public NodeProfile(String name, String path, List<GenericNode> nodeList)
        {
            NodeList = nodeList;
            FilePath = path;
            Rename(name);
        }

        public void Rename(String newName)
        {
            Int32 pos = FilePath.LastIndexOf(Path.DirectorySeparatorChar);

            String newFilePath = FilePath.Substring(0, pos) + Path.DirectorySeparatorChar + newName + Properties.Settings.Default.profileFileExtension;
            File.Move(FilePath, newFilePath);
            FilePath = newFilePath;

            FullName = FilePath.Substring((FilePath.Substring(0, pos)).LastIndexOf(Path.DirectorySeparatorChar) + 1);
            _name = newName;
        }

        public virtual new String ToString()
        {
            return FullName;
        }
    }
}
