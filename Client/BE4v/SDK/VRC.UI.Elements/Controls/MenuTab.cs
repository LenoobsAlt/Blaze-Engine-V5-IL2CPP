using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace VRC.UI.Elements.Controls
{
    public class MenuTab : MonoBehaviour
    {
		public MenuTab(IntPtr ptr) : base(ptr) { }

		public void ShowTabContent()
		{
			Instance_Class.GetMethod(nameof(ShowTabContent)).Invoke(this);
		}

		public unsafe string pageName
		{
			get
			{
				IL2Field field = Instance_Class.GetField(nameof(pageName));
				if (field == null)
                {
					(field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(string).FullName)).Name = nameof(pageName);
					if (field == null)
						return null;
                }
				return field.GetValue(this)?.GetValue<IL2String>().ToString();
			}
			set
			{
				IL2Field field = Instance_Class.GetField(nameof(pageName));
				if (field == null)
				{
					(field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(string).FullName)).Name = nameof(pageName);
					if (field == null)
						return;
				}
				field.SetValue(this, new IL2String_utf16(value).Pointer);
			}
		}

		public unsafe int obfus_Field_Int32
		{
			get
			{
				IL2Field field = Instance_Class.GetField(nameof(obfus_Field_Int32));
				if (field == null)
                {
					(field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(int).FullName)).Name = nameof(obfus_Field_Int32);
					if (field == null)
						throw new Exception("MenuTab::Int32_Filed not found!");
				}
				return field.GetValue<int>(this).GetValue();
			}
			set
			{
				IL2Field field = Instance_Class.GetField(nameof(obfus_Field_Int32));
				if (field == null)
				{
					(field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(int).FullName)).Name = nameof(obfus_Field_Int32);
					if (field == null)
						throw new Exception("MenuTab::Int32_Filed not found!");
				}
				field.SetValue(this, new IntPtr(&value));
			}
		}
		
		public unsafe int obfus_Field_Bool
		{
			get
			{
				IL2Field field = Instance_Class.GetField(nameof(obfus_Field_Bool));
				if (field == null)
                {
					(field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(bool).FullName)).Name = nameof(obfus_Field_Bool);
					if (field == null)
						throw new Exception("MenuTab::Bool_Filed not found!");
                }
				return field.GetValue<int>(this).GetValue();
			}
			set
			{
				IL2Field field = Instance_Class.GetField(nameof(obfus_Field_Int32));
				if (field == null)
				{
					(field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(bool).FullName)).Name = nameof(obfus_Field_Bool);
					if (field == null)
						throw new Exception("MenuTab::Bool_Filed not found!");
				}
				field.SetValue(this, new IntPtr(&value));
			}
		}

		public GameObject menuObject
		{
			get
			{
				IL2Field field = Instance_Class.GetField(nameof(menuObject));
				if (field == null)
                {
					(field = Instance_Class.GetField(x => x.ReturnType.Name == GameObject.Instance_Class.FullName)).Name = nameof(menuObject);
					if (field == null)
						return null;
                }
				return field.GetValue(this)?.GetValue<GameObject>();
			}
			set
			{
				IL2Field field = Instance_Class.GetField(nameof(menuObject));
				if (field == null)
				{
					(field = Instance_Class.GetField(x => x.ReturnType.Name == GameObject.Instance_Class.FullName)).Name = nameof(menuObject);
					if (field == null)
						return;
				}
				field.SetValue(this, value == null ? IntPtr.Zero : value.Pointer);
			}
		}
		
		public MenuTabGroup menuTabGroup
		{
			get
			{
				IL2Field field = Instance_Class.GetField(nameof(menuTabGroup));
				if (field == null)
                {
					(field = Instance_Class.GetField(x => x.ReturnType.Name == MenuTabGroup.Instance_Class.FullName)).Name = nameof(menuTabGroup);
					if (field == null)
						return null;
                }
				return field.GetValue(this)?.GetValue<MenuTabGroup>();
			}
			set
			{
				IL2Field field = Instance_Class.GetField(nameof(menuTabGroup));
				if (field == null)
				{
					(field = Instance_Class.GetField(x => x.ReturnType.Name == MenuTabGroup.Instance_Class.FullName)).Name = nameof(menuTabGroup);
					if (field == null)
						return;
				}
				field.SetValue(this, value == null ? IntPtr.Zero : value.Pointer);
			}
		}
		
		public MenuStateController menuStateController
		{
			get
			{
				IL2Field field = Instance_Class.GetField(nameof(menuStateController));
				if (field == null)
                {
					(field = Instance_Class.GetField(x => x.ReturnType.Name == MenuStateController.Instance_Class.FullName)).Name = nameof(menuStateController);
					if (field == null)
						return null;
                }
				return field.GetValue(this)?.GetValue<MenuStateController>();
			}
			set
			{
				IL2Field field = Instance_Class.GetField(nameof(menuStateController));
				if (field == null)
				{
					(field = Instance_Class.GetField(x => x.ReturnType.Name == MenuStateController.Instance_Class.FullName)).Name = nameof(menuStateController);
					if (field == null)
						return;
				}
				field.SetValue(this, value == null ? IntPtr.Zero : value.Pointer);
			}
		}

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRC.UI.Elements"].GetClasses().FirstOrDefault(x => x.GetMethods(y => y.Name == "ShowTabContent").Length == 1);
    }
}