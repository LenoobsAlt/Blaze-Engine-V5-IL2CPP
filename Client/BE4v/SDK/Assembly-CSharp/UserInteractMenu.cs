using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;
using UnityEngine.UI;

public class UserInteractMenu : MonoBehaviour
{
    public UserInteractMenu(IntPtr ptr) : base(ptr) { }

    public Text cloneAvatarButtonText
    {
        get => Instance_Class.GetField(Text.Instance_Class).GetValue(this)?.GetValue<Text>();
        set => Instance_Class.GetField(Text.Instance_Class).SetValue(this, value.Pointer);
    }

    public MenuController menuController
    {
        get => Instance_Class.GetField(MenuController.Instance_Class).GetValue(this)?.GetValue<MenuController>();
        set => Instance_Class.GetField(MenuController.Instance_Class).SetValue(this, value.Pointer);
    }
    
    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetFields(y => y.ReturnType.Name == Button.Instance_Class.FullName).Length == 3 && x.GetField(MenuController.Instance_Class) != null);
}
