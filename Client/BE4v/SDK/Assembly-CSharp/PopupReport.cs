using System;
using System.Linq;
using IL2CPP_Core.Objects;

public class PopupReport : VRCUiPopup
{
    public PopupReport(IntPtr ptr) : base(ptr) { }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("OpenPage2")?.IsVirtual == true);
}