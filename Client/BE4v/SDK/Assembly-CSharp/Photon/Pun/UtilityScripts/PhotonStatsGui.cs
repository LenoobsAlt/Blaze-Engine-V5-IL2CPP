using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace IL2Photon.Pun.UtilityScripts
{
    public class PhotonStatsGui : MonoBehaviour
    {
        public PhotonStatsGui(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("Start") != null && x.GetMethod("OnGUI") != null && x.Pointer != OVRLipSyncMicInput.Instance_Class.Pointer);
    }
}