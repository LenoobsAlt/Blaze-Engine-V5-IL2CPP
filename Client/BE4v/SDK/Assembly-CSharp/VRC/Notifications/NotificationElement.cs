using System;
using System.Linq;
using UnityEngine;
using IL2CPP_Core.Objects;

namespace VRC.Notifications
{
    public class NotificationElement : MonoBehaviour
    {
        public NotificationElement(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("ShowMoreOptionsMenu") != null);
    }
}
