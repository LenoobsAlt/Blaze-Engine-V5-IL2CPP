using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace VRC.UserCamera
{
    public class CameraInteractable : MonoBehaviour
    {
        public CameraInteractable(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("OnPickupUseDown") != null);
    }
}
