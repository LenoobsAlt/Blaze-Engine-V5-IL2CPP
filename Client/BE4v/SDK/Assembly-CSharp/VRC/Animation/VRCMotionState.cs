using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace VRC.Animation
{
    public class VRCMotionState : MonoBehaviour
    {
        public VRCMotionState(IntPtr ptr) : base(ptr) { }

        unsafe public Vector3 PlayerVelocity
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(PlayerVelocity));
                if (property == null)
                    (property = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == "UnityEngine.Vector3" && x.GetSetMethod() != null)).Name = nameof(PlayerVelocity);
                return property.GetGetMethod().Invoke<Vector3>(this).GetValue();
            }
            set
            {
                IL2Property property = Instance_Class.GetProperty(nameof(PlayerVelocity));
                if (property == null)
                    (property = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == "UnityEngine.Vector3" && x.GetSetMethod() != null)).Name = nameof(PlayerVelocity);
                property.GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
            }
        }
        unsafe public float jumpPower
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(jumpPower));
                if (field == null)
                    (field = Instance_Class.GetFields().Last(x => x.ReturnType.Name == "System.Single")).Name = nameof(jumpPower);
                return field.GetValue<float>(this).GetValue();
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(jumpPower));
                if (field == null)
                    (field = Instance_Class.GetFields().Last(x => x.ReturnType.Name == "System.Single")).Name = nameof(jumpPower);
                field.SetValue(this, new IntPtr(&value));
            }
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("OnControllerColliderHit") != null && x.BaseType == MonoBehaviour.Instance_Class);
    }
}
