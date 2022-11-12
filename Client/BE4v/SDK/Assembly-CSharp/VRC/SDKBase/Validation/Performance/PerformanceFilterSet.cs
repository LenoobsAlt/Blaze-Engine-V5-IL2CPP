using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace VRC.SDKBase.Validation.Performance
{
    public class PerformanceFilterSet : ScriptableObject
    {
        public PerformanceFilterSet(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClass("PerformanceFilterSet", "VRC.SDKBase.Validation.Performance");
    }
}
