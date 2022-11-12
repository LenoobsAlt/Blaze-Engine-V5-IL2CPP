using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace VRTK.UnityEventHelper
{
    //  VRTK_UnityEvents<VRTK_UIPointer> -> MonoBehaviour
    public class VRTK_UIPointer_UnityEvents : MonoBehaviour
    {
        public VRTK_UIPointer_UnityEvents(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetNestedType("UIPointerEvent") != null);
    }
}