using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace HeathenEngineering.OSK.v2
{
    public class OnScreenKeyboardKey : MonoBehaviour
    {
        public OnScreenKeyboardKey(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("PressKey") != null);
    }
}