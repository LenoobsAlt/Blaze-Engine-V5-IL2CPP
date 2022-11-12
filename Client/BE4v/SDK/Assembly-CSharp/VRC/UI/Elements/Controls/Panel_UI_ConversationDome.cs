using System;
using System.Linq;
using UnityEngine;
using IL2CPP_Core.Objects;

namespace VRC.UI.Elements.Controls
{
    public class Panel_UI_ConversationDome : MonoBehaviour
    {
        public Panel_UI_ConversationDome(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetField("_alwaysShowVisualAideToggle") != null);
    }
}
