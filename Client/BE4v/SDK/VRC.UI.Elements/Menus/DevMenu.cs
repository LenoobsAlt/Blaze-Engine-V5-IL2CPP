using System;
using System.Linq;
using UnityEngine.UI;
using IL2CPP_Core.Objects;

namespace VRC.UI.Elements.Menus
{
    public class DevMenu : UIPage
	{
        public DevMenu(IntPtr ptr) : base(ptr) { }

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRC.UI.Elements"].GetClasses().FirstOrDefault(
            x => x.BaseType?.Pointer == UIPage.Instance_Class.Pointer
            && x.GetFields().Length == 4
            && x.GetFields(y => y.ReturnType.Name == Toggle.Instance_Class.FullName).Length == 2
            && x.GetFields(y => y.ReturnType.Name == Button.Instance_Class.FullName).Length == 2
        );
    }
}