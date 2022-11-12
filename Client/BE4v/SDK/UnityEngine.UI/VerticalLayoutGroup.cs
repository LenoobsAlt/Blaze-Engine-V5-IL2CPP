using System;
using IL2CPP_Core.Objects;

namespace UnityEngine.UI
{
    public class VerticalLayoutGroup : HorizontalOrVerticalLayoutGroup
    {
		public VerticalLayoutGroup(IntPtr ptr) : base(ptr) { }

		public VerticalLayoutGroup() : base(IntPtr.Zero)
		{
			Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
			Instance_Class.GetMethod(".ctor").Invoke(Pointer);
		}

		public void CalculateLayoutInputHorizontal()
		{
			Instance_Class.GetMethod(nameof(CalculateLayoutInputHorizontal)).Invoke(this);
		}

		public void CalculateLayoutInputVertical()
		{
			Instance_Class.GetMethod(nameof(CalculateLayoutInputVertical)).Invoke(this);
		}

		public void SetLayoutHorizontal()
		{
			Instance_Class.GetMethod(nameof(SetLayoutHorizontal)).Invoke(this);
		}

		public void SetLayoutVertical()
		{
			Instance_Class.GetMethod(nameof(SetLayoutVertical)).Invoke(this);
		}

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.UI"].GetClass("VerticalLayoutGroup", "UnityEngine.UI");
    }
}
