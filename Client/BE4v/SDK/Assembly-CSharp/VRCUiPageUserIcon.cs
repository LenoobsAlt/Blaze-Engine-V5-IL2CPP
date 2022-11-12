using System;
using System.Linq;
using IL2CPP_Core.Objects;

public class VRCUiPageUserIcon : VRCUiPage
{
    public VRCUiPageUserIcon(IntPtr ptr) : base(ptr) { }

    public UserController userController
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(userController));
            if (field == null)
                (field = Instance_Class.GetField(UserController.Instance_Class)).Name = nameof(userController);
            return field.GetValue(this).GetValue<UserController>();
        }
        set
        {
            IL2Field field = Instance_Class.GetField(nameof(userController));
            if (field == null)
                (field = Instance_Class.GetField(UserController.Instance_Class)).Name = nameof(userController);
            field.SetValue(this, value == null ? IntPtr.Zero : value.Pointer);
        }
    }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("UploadUserIconOnVRChatWebsite") != null);
}