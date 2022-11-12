using System;
using System.Linq;
using IL2CPP_Core.Objects;

namespace VRC.UI
{
    public class PopupClearPlaylist : VRCUiPopup
    {
        public PopupClearPlaylist(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("ClearPlaylist") != null);
    }
}