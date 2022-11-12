using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;


namespace VRC
{
    public class SelectedUserManager : MonoBehaviour
    {
        public SelectedUserManager(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClass(VRCPlayer.Instance_Class.GetMethod(m => m.Name.EndsWith("RPC")).GetParameters().LastOrDefault().ReturnType.Name);
    }
}
