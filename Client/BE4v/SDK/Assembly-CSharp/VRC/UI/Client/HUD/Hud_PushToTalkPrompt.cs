using System;
using System.Linq;
using UnityEngine;
using IL2CPP_Core.Objects;

namespace VRC.UI.Client.HUD
{
    public class Hud_PushToTalkPrompt : MonoBehaviour
    {
        public Hud_PushToTalkPrompt(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetField("keyParent") != null);
    }
}
