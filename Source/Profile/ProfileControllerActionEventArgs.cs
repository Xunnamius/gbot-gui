using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameBotGUI.Profile
{
    public class ProfileControllerActionEventArgs : EventArgs
    {
        public readonly ProfileControllerAction Action;
        public readonly NodeProfile Profile;

        public ProfileControllerActionEventArgs(ProfileControllerAction action, NodeProfile profile)
        {
            Action = action;
            Profile = profile;
        }
    }
}
