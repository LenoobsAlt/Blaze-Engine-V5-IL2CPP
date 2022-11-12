using System;
using System.Linq;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
    public static class Physics
    {
        unsafe public static Vector3 gravity
        {
            get => Instance_Class.GetProperty(nameof(gravity)).GetGetMethod().Invoke<Vector3>().GetValue();
            set => Instance_Class.GetProperty(nameof(gravity)).GetSetMethod().Invoke(new IntPtr[] { new IntPtr(&value) });
        }

        public static bool Raycast(Ray ray, out RaycastHit hitInfo)
        {
            IL2Method method = Instance_Class.GetMethod("Raycast_out");
            if (method == null)
                (method = Instance_Class.GetMethod("Raycast", x => x.GetParameters().Length == 2 && x.GetParameters()[1].ReturnType.Name == "UnityEngine.RaycastHit&")).Name = "Raycast_out";

            unsafe
            {
                fixed (RaycastHit* hitInfoPtr = &hitInfo)
                {
                    return method.Invoke<bool>(new IntPtr[] { new IntPtr(&ray), new IntPtr(hitInfoPtr) }).GetValue();
                }
            }
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.PhysicsModule"].GetClass("Physics", "UnityEngine");
    }
}
