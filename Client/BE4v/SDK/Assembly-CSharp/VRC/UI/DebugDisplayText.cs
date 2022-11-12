using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace VRC.UI
{
    public class DebugDisplayText : MonoBehaviour
    {
        static DebugDisplayText()
        {
            try
            {
                Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x =>
                    x.GetFields().Length == 2
                    && x.GetField(UnityEngine.UI.Text.Instance_Class) != null
                    && x.GetField(y => y.ReturnType.Name.StartsWith(x.FullName + ".")) != null
                    && x.GetMethod("Update") != null
                );
                if (Instance_Class == null)
                    "VRC.UI.DebugDisplayText::Instance_Class not found!".RedPrefix("Exception");
            }
            catch(Exception ex) { ex.ToString().RedPrefix("Exception"); }
        }
        public DebugDisplayText(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class;
    }
}
