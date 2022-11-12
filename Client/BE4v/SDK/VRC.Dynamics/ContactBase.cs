using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;
using VRC.Udon.Common.Interfaces;
using VRC.Udon.Common.Enums;

namespace VRC.Dynamics
{
    public abstract class ContactBase : MonoBehaviour
    {
        public ContactBase(IntPtr ptr) : base(ptr) { }

        public Transform GetRootTransform()
        {
            return null;
        }

        unsafe public Vector3 position
        {
            get => Instance_Class.GetField(nameof(position)).GetValue<Vector3>(this).GetValue();
            set => Instance_Class.GetField(nameof(position)).SetValue(this, new IntPtr(&value));
        }


        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRC.Dynamics"].GetClass("ContactBase", "VRC.Dynamics");
    }
}
