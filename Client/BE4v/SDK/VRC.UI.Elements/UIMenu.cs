using System;
using System.Linq;
using IL2CPP_Core.Objects;
using VRC.UI.Core;

namespace VRC.UI.Elements
{
    public class UIMenu : UIElement
    {
        public UIMenu(IntPtr ptr) : base(ptr) { }

        public MenuStateController MenuStateController
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(MenuStateController));
                if (property == null)
                {
                    (property = Instance_Class.GetProperty(MenuStateController.Instance_Class)).Name = nameof(MenuStateController);
                    if (property == null)
                        return null;
                }
                return property.GetGetMethod().Invoke(this)?.GetValue<MenuStateController>();
            }
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRC.UI.Elements"].GetClasses().FirstOrDefault(x => x.BaseType?.FullName == UIElement.Instance_Class.FullName);
    }
}