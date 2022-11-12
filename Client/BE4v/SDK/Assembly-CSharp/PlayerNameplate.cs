using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameplate : MonoBehaviour
{
	public PlayerNameplate(IntPtr ptr) : base(ptr) { }

	unsafe public Color ModifyTrustColor(Color color)
    {
		IL2Method method = Instance_Class.GetMethod(nameof(ModifyTrustColor));
		if (method == null)
			(method = Instance_Class.GetMethod(x => x.GetParameters().Length == 1 && x.GetParameters()[0].ReturnType.Name == Color.Instance_Class.FullName)).Name = nameof(ModifyTrustColor);
		return method.Invoke<Color>(this, new IntPtr[] { new IntPtr(&color) }).GetValue();
	}
	
	public Graphic uiNameBackground
    {
        get
        {
			IL2Field field = Instance_Class.GetField(nameof(uiNameBackground));
			if (field == null)
				(field = Instance_Class.GetFields().First(x => x.ReturnType.Name == Graphic.Instance_Class.FullName)).Name = nameof(uiNameBackground);
			return field.GetValue(this).GetValue<Graphic>();
		}
	}

	public enum Mode
	{
		Standard,
		Icons,
		Hidden,
		MAX
	}

	// Only: UnityEngine.Transform
	public struct Anchors
	{
		public IntPtr friendIcon;

		public IntPtr friendCapsule;

		public IntPtr friendStats;
	}

	// Only: UnityEngine.Sprite
	public struct Icons
	{
		public IntPtr perfExcellent;

		public IntPtr perfGood;

		public IntPtr perfMedium;

		public IntPtr perfPoor;

		public IntPtr perfVeryPoor;

		public IntPtr backgroundDefault;

		public IntPtr voiceGlowFull;

		public IntPtr voiceGlowHalf;

		public IntPtr voicePulseFull;

		public IntPtr voicePulseLeft;

		public IntPtr voicePulseRight;
	}

	public enum SpeakerState
	{
		NULL,
		Idle,
		Speaking,
		Mute
	}

	public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetNestedType("Anchors") != null);
}