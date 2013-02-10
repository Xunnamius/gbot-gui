using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace GameBotGUI.Profile
{
    static sealed class ProfileController
    {
        public static Profile LoadProfile(String filePath)
        {
            Profile profile = null;

            using(Stream stream = File.Open(filePath, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                profile = (Profile) formatter.Deserialize(stream);
            }

            if(profile != null && !Properties.Settings.Default.profileHistory.Contains(profile.FilePath))
                Properties.Settings.Default.profileHistory.Insert(0, profile.FilePath);

            return profile;
        }

        public static void SaveProfile(Profile profile)
        {
            using(Stream stream = File.OpenRead(profile.FilePath))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, profile);
            }

            if(!Properties.Settings.Default.profileHistory.Contains(profile.FilePath))
                Properties.Settings.Default.profileHistory.Insert(0, profile.FilePath);
        }
    }
}
