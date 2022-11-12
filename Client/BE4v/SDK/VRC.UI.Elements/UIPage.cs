using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;


namespace VRC.UI.Elements
{
    public class UIPage : MonoBehaviour
    {
		public UIPage(IntPtr ptr) : base(ptr) { }

		public unsafe string Name
		{
			get
			{
				IL2Field field = Instance_Class.GetField(nameof(Name));
				if (field == null)
				{
					(field = Instance_Class.GetFields().FirstOrDefault(x => x.ReturnType.Name == typeof(string).FullName)).Name = nameof(Name);
					if (field == null)
						return null;
				}

				return field.GetValue(this)?.GetValue<IL2String>().ToString();
			}
			set
			{
				IL2Field field = Instance_Class.GetField(nameof(Name));
				if (field == null)
				{
					(field = Instance_Class.GetFields().FirstOrDefault(x => x.ReturnType.Name == typeof(string).FullName)).Name = nameof(Name);
					if (field == null)
						return;
				}
				field.SetValue(this, new IL2String_utf16(value).Pointer);
			}
		}

		public unsafe MenuStateController _menuStateController
		{
			get
			{
				IL2Field field = Instance_Class.GetField(nameof(_menuStateController));
				if (field == null)
				{
					(field = Instance_Class.GetField(MenuStateController.Instance_Class)).Name = nameof(_menuStateController);
					if (field == null)
						return null;
				}

				return field.GetValue(this)?.GetValue<MenuStateController>();
			}
			set
			{
				IL2Field field = Instance_Class.GetField(nameof(_menuStateController));
				if (field == null)
				{
					(field = Instance_Class.GetField(MenuStateController.Instance_Class)).Name = nameof(_menuStateController);
					if (field == null)
						return;
				}
				field.SetValue(this, value == null ? IntPtr.Zero : value.Pointer);
			}
		}

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRC.UI.Elements"].GetClasses().FirstOrDefault(x => x.GetField(y => y.ReturnType.Name == "DG.Tweening.Sequence") != null);
    }
}