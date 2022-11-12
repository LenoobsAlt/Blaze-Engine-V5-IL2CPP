using System;
using IL2CPP_Core.Objects;

namespace Steamworks
{
    public class SocketInterface : IL2Object
    {
        public SocketInterface(IntPtr ptr) : base(ptr) { }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["Steamworks"].GetClass("SocketInterface", "Steamworks");
    }
}
