using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;
using VRC.Core;

public class UserController : ScriptableObject
{
    public UserController(IntPtr ptr) : base(ptr) { }

	public void ChangeAvatar(ApiAvatar avatar, string changeMethod = "Unknown")
	{
		IL2Method method = Instance_Class.GetMethod(nameof(ChangeAvatar));
		if (method == null)
			(method = Instance_Class.GetMethod(x =>
				x.GetParameters().Length == 2
				&& x.GetParameters()[0].ReturnType.Name == ApiAvatar.Instance_Class.FullName
				&& x.GetParameters()[1].ReturnType.Name == typeof(string).FullName
			)).Name = nameof(ChangeAvatar);
		method.Invoke(this, new IntPtr[] { avatar == null ? IntPtr.Zero : avatar.Pointer, changeMethod == null ? IntPtr.Zero : new IL2String_utf8(changeMethod).Pointer });
	}

	public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClass("UserController");
}