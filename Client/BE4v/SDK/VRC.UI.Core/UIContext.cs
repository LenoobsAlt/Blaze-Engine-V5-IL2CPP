using System;
using System.Linq;
using IL2CPP_Core.Objects;

namespace VRC.UI.Core
{
    public class UIContext : IL2Object
    {
        public UIContext(IntPtr ptr) : base(ptr) { }

		public static IL2Class Instance_Class = IL2CPP.AssemblyList["VRC.UI.Core"].GetClasses().FirstOrDefault(x => x.GetFields().Length == 4 && x.GetMethods().Length < 3);
    }
}