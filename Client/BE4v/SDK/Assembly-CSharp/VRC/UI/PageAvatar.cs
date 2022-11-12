using System;
using System.Linq;
using IL2CPP_Core.Objects;

namespace VRC.UI
{
    public class PageAvatar : VRCUiPage
    {
        public PageAvatar(IntPtr ptr) : base(ptr) { }

        public PageAvatar() : base(IntPtr.Zero)
        {
            Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
            Instance_Class.GetMethod(".ctor").Invoke(Pointer);
        }

        public SimpleAvatarPedestal avatar
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(avatar));
                if (field == null)
                    (field = Instance_Class.GetField(SimpleAvatarPedestal.Instance_Class)).Name = nameof(avatar);
                return field.GetValue(this)?.GetValue<SimpleAvatarPedestal>();
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(avatar));
                if (field == null)
                    (field = Instance_Class.GetField(SimpleAvatarPedestal.Instance_Class)).Name = nameof(avatar);
                field.SetValue(this, value == null ? IntPtr.Zero : value.Pointer);
            }
        }

        public void ChangeToSelectedAvatar()
        {
            Instance_Class.GetMethod(nameof(ChangeToSelectedAvatar)).Invoke(this);
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("ChangeToSelectedAvatar") != null);
    }
}
