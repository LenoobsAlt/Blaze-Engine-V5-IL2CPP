using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class ActionMenuDriver : MonoBehaviour
{
	public ActionMenuDriver(IntPtr ptr) : base(ptr) { }

	public static ActionMenuDriver Instance
	{
		get
		{
			IL2Property property = Instance_Class.GetProperty(nameof(Instance));
			if (property == null)
				(property = Instance_Class.GetProperty(x => x.Instance)).Name = nameof(Instance);
			return property?.GetGetMethod()?.Invoke().GetValue<ActionMenuDriver>();
		}
	}



	// Only: UnityEngine.Texture2D
	public struct MenuIcons
	{
		public IntPtr home;

		public IntPtr options;

		public IntPtr config;

		public IntPtr expressions;

		public IntPtr emojis;

		public IntPtr micOn;

		public IntPtr micOff;

		public IntPtr gesturesOn;

		public IntPtr gesturesOff;

		public IntPtr defaultExpression;

		public IntPtr back;

		public IntPtr close;

		public IntPtr debug;

		public IntPtr resetAvatar;

		public IntPtr toggleOn;

		public IntPtr toggleOff;

		public IntPtr settingHudPosition;

		public IntPtr settingSize;

		public IntPtr settingOpacity;

		public IntPtr nameplate;

		public IntPtr arrowUp;

		public IntPtr arrowRight;

		public IntPtr arrowDown;

		public IntPtr arrowLeft;

		public IntPtr folder;

		public IntPtr visibility;

		public IntPtr radioOn;

		public IntPtr radioOff;
	}

	// Only: UnityEngine.Texture2D
	public struct EmojiCategoryIcons
	{
		public IntPtr page1;

		public IntPtr page2;

		public IntPtr page3;

		public IntPtr page4;

		public IntPtr fall;

		public IntPtr winter;

		public IntPtr summer;
	}

	// Only: UnityEngine.Texture2D
	public struct ExpressionIcons
	{
		public IntPtr typeToggleOn;

		public IntPtr typeToggleOff;

		public IntPtr typeFolder;

		public IntPtr typeAxis;

		public IntPtr typeRadial;

		public IntPtr typePlayOn;

		public IntPtr typePlayOff;
	}

	// Only: UnityEngine.AudioClip
	public struct Sounds
	{
		public IntPtr hover;

		public IntPtr deny;

		public IntPtr select;

		public IntPtr back;
	}

	public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetNestedType("EmojiCategoryIcons") != null);
}