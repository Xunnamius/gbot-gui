using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;

namespace GameBotGUI.Profile
{
    public class ProfileController
    {
        private String _defaultSaveDirectory;
        private NodeProfile _activeProfile = null;

        public String DefaultSaveDirectory
        {
            get { return _defaultSaveDirectory; }
            set { _defaultSaveDirectory = value; }
        }

        public String PathOfDefaultProfile
        {
            get { return Path.Combine(DefaultSaveDirectory, NameToProfileFile("default")); }
        }

        public NodeProfile ActiveProfile
        {
            get { return _activeProfile; }
            set
            {
                _activeProfile = value;
                value.Loaded = true;
                OnProfileControllerAction(
                    new ProfileControllerActionEventArgs(Profile.ProfileControllerAction.Activated, value));
            }
        }

        public BindingList<NodeProfile> Profiles = new BindingList<NodeProfile>();
        public delegate void ProfileControllerActionHandler(Object sender, ProfileControllerActionEventArgs e);
        public event ProfileControllerActionHandler ProfileControllerAction;

        public ProfileController(String intermediateFolderName)
        {
            if(Properties.Settings.Default.ProfileDefaultSaveLocation.Length > 0)
                DefaultSaveDirectory = Properties.Settings.Default.ProfileDefaultSaveLocation;
            else
            {
                DefaultSaveDirectory = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    intermediateFolderName,
                    "profiles"
                );
            }
        }

        public NodeProfile LoadProfile(String filePath)
        {
            NodeProfile profile = null;

            using(Stream stream = File.OpenRead(filePath))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                profile = (NodeProfile) formatter.Deserialize(stream);
            }

            if(IndexOfLoadedProfileWithFilePath(profile.FilePath) != -1)
            {
                OnProfileControllerAction(
                    new ProfileControllerActionEventArgs(GameBotGUI.Profile.ProfileControllerAction.AlreadyLoaded, profile));
            }

            else
            {
                RemoveFromProfilesWhereFilePathExists(profile);
                Profiles.Add(profile);
                _activeProfile = profile;
                profile.Loaded = true;

                OnProfileControllerAction(
                    new ProfileControllerActionEventArgs(GameBotGUI.Profile.ProfileControllerAction.Load, profile));
            }

            return profile;
        }

        public void RemoveFromProfilesWhereFilePathExists(NodeProfile profile)
        {
            int ndx = IndexOfProfileWithFilePath(profile.FilePath);
            if(ndx != -1) Profiles.RemoveAt(ndx);
        }

        public void SaveProfile(NodeProfile profile)
        {
            using(Stream stream = File.Open(profile.FilePath, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, profile);
            }

            if(IndexOfProfileWithFilePath(profile.FilePath) == -1)
                Profiles.Insert(0, profile);

            OnProfileControllerAction(
                new ProfileControllerActionEventArgs(GameBotGUI.Profile.ProfileControllerAction.Save, profile));
        }

        public Int32 IndexOfProfileWithFilePath(String filePath)
        {
            foreach(NodeProfile pro in Profiles)
            {
                if(pro.FilePath == filePath)
                    return Profiles.IndexOf(pro);
            }

            return -1;
        }

        private int IndexOfLoadedProfileWithFilePath(String filePath)
        {
            foreach(NodeProfile pro in Profiles)
            {
                if(pro.Loaded && pro.FilePath == filePath)
                    return Profiles.IndexOf(pro);
            }

            return -1;
        }

        public String NameToProfileFile(String name)
        {
            return name + "." + Properties.Settings.Default.ProfileFileExtension;
        }

        private void OnProfileControllerAction(ProfileControllerActionEventArgs e)
        {
            if(ProfileControllerAction != null)
                ProfileControllerAction(this, e);
        }
    }
}
