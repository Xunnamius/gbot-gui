using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace GameBotGUI.Profile
{
    static class ProfileController
    {
        public static NodeProfile LoadProfile(String filePath)
        {
            NodeProfile profile = null;

            using(Stream stream = File.Open(filePath, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                profile = (NodeProfile) formatter.Deserialize(stream);
            }

            if(profile != null && !Properties.Settings.Default.profileHistory.Contains(profile.FilePath))
                Properties.Settings.Default.profileHistory.Add(profile.FilePath);

            return profile;
        }

        public static void SaveProfile(NodeProfile profile)
        {
            using(Stream stream = File.OpenRead(profile.FilePath))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, profile);
            }

            if(!Properties.Settings.Default.profileHistory.Contains(profile.FilePath))
                Properties.Settings.Default.profileHistory.Add(profile.FilePath);
        }
    }
}
