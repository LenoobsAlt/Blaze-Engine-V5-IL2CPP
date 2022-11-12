using System;
using IL2CPP_Core.Objects;

namespace Steamworks
{
    public class ConnectionInterface : IL2Object
    {
        public ConnectionInterface(IntPtr ptr) : base(ptr) { }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["Steamworks"].GetClass("ConnectionInterface", "Steamworks");
    }
}
