using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GameBotGUI.Node.Types;
using System.ComponentModel;

namespace GameBotGUI.Profile
{
    [Serializable()]
    public class NodeProfile : ICloneable
    {
        private String _name;
        private String _dirPath;

        public String Name
        {
            get { return _name; }
            set { Rename(value); }
        }
        
        public String DirPath
        {
            get { return _dirPath; }
            set
            {
                _dirPath = value;
                Rename(_name);
            }
        }

        public String FilePath { get; private set; }
        public Boolean Loaded { get; set; }
        public BindingList<GenericNode> NodeList { get; private set; }
        public String Display { get { return ToString(); } }
        
        public NodeProfile(String name, String dirpath, BindingList<GenericNode> nodeList)
        {
            _name = name;
            NodeList = nodeList;
            DirPath = dirpath;
        }

        public void Rename(String newName, String ext=null)
        {
            if(ext == null)
                ext = Properties.Settings.Default.ProfileFileExtension;

            String newFilePath = Path.Combine(DirPath, newName + "." + ext);

            if(FilePath != null && File.Exists(FilePath))
            {
                if(File.Exists(newFilePath))
                    File.Delete(newFilePath);
                File.Move(FilePath, newFilePath);
            }

            else
            {
                DirectoryInfo di = Directory.CreateDirectory(DirPath);
                FileStream file = File.Create(newFilePath);
                file.Close();
            }

            FilePath = newFilePath;
            _name = newName;
        }

        public virtual new String ToString()
        {
            Int32 ndx = FilePath.LastIndexOf(Path.DirectorySeparatorChar);

            if(ndx == -1)
                return FilePath;

            String newFilePath = FilePath.Substring(0, ndx);
            ndx = newFilePath.LastIndexOf(Path.DirectorySeparatorChar);

            if(ndx == -1)
                return FilePath;

            newFilePath = FilePath.Substring(ndx);

            Int32 count = FilePath.Count((c) =>
            {
                if(c == Path.DirectorySeparatorChar)
                    return true;
                else
                    return false;
            });

            if(count > 2)
                newFilePath = "..." + newFilePath;
            else
                newFilePath = newFilePath.Trim(Path.DirectorySeparatorChar);

            return newFilePath;
        }

        public virtual Object Clone()
        {
            BindingList<GenericNode> dl = new BindingList<GenericNode>();
            foreach(GenericNode node in NodeList)
                dl.Add((GenericNode) node.Clone());

            return new NodeProfile(Name, DirPath, dl);
        }

        public virtual Object Clone(String newName, String newDirPath)
        {
            BindingList<GenericNode> dl = new BindingList<GenericNode>();
            foreach(GenericNode node in NodeList)
                dl.Add((GenericNode) node.Clone());

            return new NodeProfile(newName, newDirPath, dl);
        }
    }
}
