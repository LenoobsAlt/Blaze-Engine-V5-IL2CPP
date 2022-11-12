using System;
using System.Linq;
using System.Collections.Generic;
using IL2CPP_Core.Objects;
using UnityEngine;
using VRC.UI.Core;


namespace VRC.UI.Elements.Controls
{
    public class MenuTabGroup : MonoBehaviour
    {
        public MenuTabGroup(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRC.UI.Elements"].GetClasses().FirstOrDefault(x => x.GetMethod("ShowTabContent", y => y.GetParameters().Length == 1) != null);
    }
}