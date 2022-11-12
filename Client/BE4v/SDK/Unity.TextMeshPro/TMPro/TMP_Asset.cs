using System;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace TMPro
{
    public abstract class TMP_Asset : ScriptableObject
    {
        public TMP_Asset(IntPtr ptr) : base(ptr) { }


        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Unity.TextMeshPro"].GetClass("TMP_Asset", "TMPro");
    }
}
