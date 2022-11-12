using System;
using System.Linq;
using IL2CPP_Core.Objects;

public class VRCUiPageTOS : VRCUiPage
{
    public VRCUiPageTOS(IntPtr ptr) : base(ptr) { }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("ContinuePressed") != null && x.GetMethod("OpenPrivacyPolicy") != null);
}