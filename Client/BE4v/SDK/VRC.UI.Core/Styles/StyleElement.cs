using System;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace VRC.UI.Core.Styles
{
    public class StyleElement : MonoBehaviour
    {
        public StyleElement(IntPtr ptr) : base(ptr) { }

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRC.UI.Core"].GetClass("StyleElement", "VRC.UI.Core.Styles");
    }
}