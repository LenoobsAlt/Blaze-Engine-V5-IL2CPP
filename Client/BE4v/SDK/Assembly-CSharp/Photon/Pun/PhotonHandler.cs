using System;
using System.Linq;
using IL2CPP_Core.Objects;
using IL2Photon.Realtime;

namespace IL2Photon.Pun
{
    public class PhotonHandler : ConnectionHandler
    {
        public PhotonHandler(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.BaseType?.FullName == ConnectionHandler.Instance_Class.FullName);
    }
}
