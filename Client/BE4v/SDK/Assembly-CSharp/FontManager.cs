using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;
using TMPro;

public class FontManager : MonoBehaviour
{
	public FontManager(IntPtr ptr) : base(ptr) { }

	public static FontManager Instance
	{
		get
		{
			IL2Property property = Instance_Class.GetProperty(nameof(Instance));
			if (property == null)
				(property = Instance_Class.GetProperty(x => x.Instance)).Name = nameof(Instance);
			return property?.GetGetMethod()?.Invoke().GetValue<FontManager>();
		}
	}
	
	public TMP_FontAsset[] DynamicFonts
	{
		get
		{
			IL2Field field = Instance_Class.GetField(nameof(DynamicFonts));
			if (field == null)
				(field = Instance_Class.GetField(y => y.ReturnType.Name.StartsWith(TMP_FontAsset.Instance_Class.FullName))).Name = nameof(DynamicFonts);
			
			IL2Object result = field?.GetValue(this);
			if (result == null)
				return null;

			return new IL2Array<IntPtr>(result.Pointer).ToArray<TMP_FontAsset>();
		}
		set
		{
			IL2Field field = Instance_Class.GetField(nameof(DynamicFonts));
			if (field == null)
				(field = Instance_Class.GetField(y => y.ReturnType.Name.StartsWith(TMP_FontAsset.Instance_Class.FullName))).Name = nameof(DynamicFonts);
			
			// field?.SetValue(ptr, );
		}
	}


	public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetField(y => y.ReturnType.Name.StartsWith(TMP_FontAsset.Instance_Class.FullName)) != null);
}