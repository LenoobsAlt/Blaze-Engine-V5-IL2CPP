using System;
using IL2CPP_Core.Objects;

namespace Transmtn.DTO.Notifications
{
    public class Notification : IL2Object
    {
        public Notification(IntPtr ptr) : base(ptr) { }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["Transmtn"].GetClass("Notification", "Transmtn.DTO.Notifications");
    }
}