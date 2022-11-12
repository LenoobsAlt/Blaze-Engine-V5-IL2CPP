using System;
using IL2CPP_Core.Objects;

namespace IL2ExitGames.Client.Photon
{
    public class PhotonPeer : IL2Object
    {
        public PhotonPeer(IntPtr ptr) : base(ptr) { }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["Photon-DotNet"].GetClass("PhotonPeer", "ExitGames.Client.Photon");
    }
}