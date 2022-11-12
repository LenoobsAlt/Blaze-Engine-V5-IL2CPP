using System;
using System.Linq;
using IL2CPP_Core.Objects;

namespace VRC.UI
{
    public class PopupUpdateStatus : VRCUiPopup
    {
        public PopupUpdateStatus(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("TrimStatusText") != null);
    }
}
