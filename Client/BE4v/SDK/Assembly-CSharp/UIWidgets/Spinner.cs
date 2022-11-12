using System;
using System.Linq;
using UnityEngine.UI;
using IL2CPP_Core.Objects;

namespace UIWidgets
{
    public class Spinner : InputField
    {
        public Spinner(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetField("_minusButton") != null);
    }
}