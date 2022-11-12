using System;
using System.Linq;
using VRC.DataModel.Interfaces;
using IL2CPP_Core.Objects;

namespace VRC.UI.Elements.Menus
{
    public class SelectedUserMenuQM : UIPage
	{
        public SelectedUserMenuQM(IntPtr ptr) : base(ptr) { }

        public ClassIUser _iUser
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(_iUser));
                if (field == null)
                    (field = Instance_Class.GetField(ClassIUser.Instance_Class)).Name = nameof(_iUser);
                return field.GetValue(this)?.GetValue<ClassIUser>();
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(_iUser));
                if (field == null)
                    (field = Instance_Class.GetField(ClassIUser.Instance_Class)).Name = nameof(_iUser);
                field.SetValue(this, value == null ? IntPtr.Zero : value.Pointer);
            }
        }

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRC.UI.Elements"].GetClasses().FirstOrDefault(
                x => x.BaseType?.Pointer == UIPage.Instance_Class.Pointer
                && x.GetField(
                    y => y.Static
                    && y.ReturnType.Name == typeof(string).FullName
                    && y.GetValue()?.GetValue<IL2String>()?.ToString() == "UI.SelectedUser.UserActions"
                ) != null
            );
    }
}