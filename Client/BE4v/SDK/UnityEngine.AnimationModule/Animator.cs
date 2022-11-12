using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
    public sealed class Animator : MonoBehaviour
    {
        public Animator(IntPtr ptr) : base(ptr) { }

        unsafe public Transform GetBoneTransform(HumanBodyBones humanBoneId)
        {
            return Instance_Class.GetMethod(nameof(GetBoneTransform)).Invoke(this, new IntPtr[] { new IntPtr(&humanBoneId) })?.GetValue<Transform>();
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.AnimationModule"].GetClass("Animator", "UnityEngine");
    }
}
