using System;
using IL2CPP_Core.Objects;

namespace TMPro
{
    public class TMP_FontAsset : TMP_Asset
    {
        public TMP_FontAsset(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Unity.TextMeshPro"].GetClass("TMP_FontAsset", "TMPro");
    }
}
