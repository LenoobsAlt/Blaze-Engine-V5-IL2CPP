using System;
using System.Collections.Generic;
using IL2CPP_Core.Objects;

namespace UnityEngine.Experimental.XR
{
    public static class Boundary
    {
        unsafe public static bool TryGetDimensions(out Vector3 dimensionsOut, Type boundaryType = Type.PlayArea)
        {
            fixed (Vector3* dimensionsOutPtr = &dimensionsOut)
            {
                return Instance_Class.GetMethod(nameof(TryGetDimensions)).Invoke<bool>(new IntPtr[] { new IntPtr(dimensionsOutPtr), new IntPtr(&boundaryType) }).GetValue();
            }
        }

        unsafe public static bool TryGetDimensionsInternal(out Vector3 dimensionsOut, Type boundaryType)
        {
            fixed (Vector3* dimensionsOutPtr = &dimensionsOut)
            {
                return Instance_Class.GetMethod(nameof(TryGetDimensionsInternal)).Invoke<bool>(new IntPtr[] { new IntPtr(dimensionsOutPtr), new IntPtr(&boundaryType) }).GetValue();
            }
        }

        unsafe public static bool visible
        {
            get => Instance_Class.GetProperty(nameof(visible)).GetGetMethod().Invoke<bool>().GetValue();
            set => Instance_Class.GetProperty(nameof(visible)).GetGetMethod().Invoke(new IntPtr[] { new IntPtr(&value) });
        }

        unsafe public static bool configured
        {
            get => Instance_Class.GetProperty(nameof(configured)).GetGetMethod().Invoke<bool>().GetValue();
        }

        public static bool TryGetGeometry(List<Vector3> geometry, Type boundaryType = Type.PlayArea)
        {
            return true;
        }

        public static bool TryGetGeometryScriptingInternal(List<Vector3> geometry, Type boundaryType)
        {
            return true;
        }

        public enum Type
        {
            PlayArea,
            TrackedArea
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.VRModule"].GetClass("Boundary", "UnityEngine.Experimental.XR");
    }
}
