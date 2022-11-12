using System;
using IL2CPP_Core.Objects;

namespace TMPro
{
    public class TextMeshProUGUI : TMP_Text
    {
        public TextMeshProUGUI(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Unity.TextMeshPro"].GetClass("TextMeshProUGUI", "TMPro");
    }
}
