using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace VRC.Networking.Tween
{
    public class PositionEvent : IL2Object
    {
        public PositionEvent(IntPtr ptr) : base(ptr) { }

        unsafe public Vector3 Velocity
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(Velocity));
                if (field == null)
                    (field = Instance_Class.GetFields().FirstOrDefault(x => x.ReturnType.Name == typeof(Vector3).FullName)).Name = nameof(Velocity);
                return field?.GetValue<Vector3>(this).GetValue() ?? default;
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(Velocity));
                if (field == null)
                    (field = Instance_Class.GetFields().FirstOrDefault(x => x.ReturnType.Name == typeof(Vector3).FullName)).Name = nameof(Velocity);
                field?.SetValue(this, new IntPtr(&value));
            }
        }
        unsafe public Vector3 Position
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(Position));
                if (field == null)
                    (field = Instance_Class.GetFields().LastOrDefault(x => x.ReturnType.Name == typeof(Vector3).FullName)).Name = nameof(Position);
                return field?.GetValue<Vector3>(this).GetValue() ?? default;
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(Position));
                if (field == null)
                    (field = Instance_Class.GetFields().LastOrDefault(x => x.ReturnType.Name == typeof(Vector3).FullName)).Name = nameof(Position);
                field?.SetValue(this, new IntPtr(&value));
            }
        }


        public static IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClass(SyncPhysics.Instance_Class.GetMethod("ApplyEvent").GetParameters()[0].ReturnType.Name);
    }
}