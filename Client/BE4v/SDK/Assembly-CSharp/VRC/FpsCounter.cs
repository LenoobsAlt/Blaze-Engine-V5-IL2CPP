using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace VRC
{
    public class FpsCounter : MonoBehaviour
    {
        public FpsCounter(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("fpsSamplesCount") != null);
    }
}
