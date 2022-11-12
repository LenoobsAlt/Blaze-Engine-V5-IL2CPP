using System;
using IL2CPP_Core.Objects;

namespace IL2ExitGames.Client.Photon
{
    public class EnetPeer : IL2Object
    {
        public EnetPeer(IntPtr ptr) : base(ptr) { }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["Photon-DotNet"].GetClass("EnetPeer", "ExitGames.Client.Photon");
    }
}