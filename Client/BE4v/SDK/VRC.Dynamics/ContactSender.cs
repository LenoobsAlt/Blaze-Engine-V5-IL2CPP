using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;
using VRC.Udon.Common.Interfaces;
using VRC.Udon.Common.Enums;

namespace VRC.Dynamics
{
    public class ContactSender : ContactBase
    {
        public ContactSender(IntPtr ptr) : base(ptr) { }


        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRC.Dynamics"].GetClass("ContactSender", "VRC.Dynamics");
    }
}
