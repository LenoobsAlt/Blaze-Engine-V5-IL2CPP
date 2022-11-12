using System;
using System.Linq;
using IL2CPP_Core.Objects;

namespace VRC.UI
{
    public class PageWorldInfo : VRCUiPage
    {
        public PageWorldInfo(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("CreateNewInstance") != null && x.GetMethod("ReportWorld") != null);
    }
}
