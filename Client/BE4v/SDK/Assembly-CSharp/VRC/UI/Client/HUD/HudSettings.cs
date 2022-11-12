using System;
using System.Linq;
using UnityEngine;
using IL2CPP_Core.Objects;

namespace VRC.UI.Client.HUD
{
    public class HudSettings : IL2Object
    {
        public HudSettings(IntPtr ptr) : base(ptr) { }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClass("HudSettings", "VRC.UI.Client.HUD");
    }
}
