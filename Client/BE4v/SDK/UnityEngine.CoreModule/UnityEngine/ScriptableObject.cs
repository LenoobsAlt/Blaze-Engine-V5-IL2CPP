using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
    public class ScriptableObject : Object
    {
        public ScriptableObject(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("ScriptableObject", "UnityEngine");
    }
}
