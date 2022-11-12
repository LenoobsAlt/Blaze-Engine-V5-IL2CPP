using System;
using System.Linq;
using IL2CPP_Core.Objects;

namespace VRC.UI.Elements.Menus
{
    public class LaunchPadQMMenu : UIPage
	{
        public LaunchPadQMMenu(IntPtr ptr) : base(ptr) { }

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRC.UI.Elements"].GetClasses().FirstOrDefault(x => x.BaseType?.Pointer == UIPage.Instance_Class.Pointer && x.GetFields().Length > 6 && x.GetFields().Select(y => y.ReturnType.Name == UnityEngine.UI.Button.Instance_Class.FullName).Count() > 5);
    }
}