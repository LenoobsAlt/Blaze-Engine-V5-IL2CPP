using System;
using System.Linq;
using IL2CPP_Core.Objects;

namespace Discord
{
    public class Discord : IL2Object
    {
        public Discord(IntPtr ptr) : base(ptr) { }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod(".ctor", y => y.GetParameters().Length == 2 && y.GetParameters()[0].Name == "clientId") != null);
    }
}