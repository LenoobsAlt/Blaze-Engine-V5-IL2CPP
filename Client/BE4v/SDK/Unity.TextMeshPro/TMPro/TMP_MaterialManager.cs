using System;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace TMPro
{
    public static class TMP_MaterialManager
    {
        public static Material GetBaseMaterial(Material stencilMaterial)
        {
            return Instance_Class.GetMethod(nameof(GetBaseMaterial)).Invoke(new IntPtr[] { stencilMaterial == null ? IntPtr.Zero : stencilMaterial.Pointer })?.GetValue<Material>();
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["Unity.TextMeshPro"].GetClass("TMP_MaterialManager", "TMPro");
    }
}
