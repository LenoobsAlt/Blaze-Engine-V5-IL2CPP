using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;
using VRC.Dynamics;

namespace VRC.SDK3.Dynamics.Contact.Components
{
    public class VRCContactSender : ContactSender
    {
        public VRCContactSender(IntPtr ptr) : base(ptr) { }


        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRC.SDK3.Dynamics.Contact"].GetClass("VRCContactSender", "VRC.SDK3.Dynamics.Contact.Components");
    }
}
