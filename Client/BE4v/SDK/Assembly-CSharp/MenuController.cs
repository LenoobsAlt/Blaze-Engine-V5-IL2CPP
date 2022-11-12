using System;
using IL2CPP_Core.Objects;
using VRC.Core;
using UnityEngine;

public class MenuController : ScriptableObject
{
    public MenuController(IntPtr ptr) : base(ptr) { }

    public APIUser activeUser
    {
        get => Instance_Class.GetField(nameof(activeUser)).GetValue(this)?.GetValue<APIUser>();
        set => Instance_Class.GetField(nameof(activeUser)).SetValue(this, value.Pointer);
    }
    
    public ApiAvatar activeAvatar
    {
        get => Instance_Class.GetField(nameof(activeAvatar)).GetValue(this)?.GetValue<ApiAvatar>();
        set => Instance_Class.GetField(nameof(activeAvatar)).SetValue(this, value.Pointer);
    }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClass("MenuController");
}
