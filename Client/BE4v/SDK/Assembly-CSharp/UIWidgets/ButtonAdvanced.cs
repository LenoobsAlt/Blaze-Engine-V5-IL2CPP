using System;
using System.Linq;
using UnityEngine.UI;
using IL2CPP_Core.Objects;

namespace UIWidgets
{
    public class ButtonAdvanced : Button
    {
        public ButtonAdvanced(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClass(Spinner.Instance_Class.GetField("_minusButton").ReturnType.Name);
    }
}