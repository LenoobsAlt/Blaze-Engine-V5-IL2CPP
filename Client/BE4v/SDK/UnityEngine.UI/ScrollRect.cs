using System;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using IL2CPP_Core.Objects;

namespace UnityEngine.UI
{
    public class ScrollRect : UIBehaviour
    {
        public ScrollRect(IntPtr ptr) : base(ptr) { }


		public Scrollbar verticalScrollbar
		{
			get => Instance_Class.GetProperty(nameof(verticalScrollbar)).GetGetMethod().Invoke(this)?.GetValue<Scrollbar>();
			set => Instance_Class.GetProperty(nameof(verticalScrollbar)).GetSetMethod().Invoke(this, new IntPtr[] { value == null ? IntPtr.Zero : value.Pointer });
		}

		unsafe public ScrollbarVisibility verticalScrollbarVisibility
		{
			get => Instance_Class.GetProperty(nameof(verticalScrollbarVisibility)).GetGetMethod().Invoke<ScrollRect.ScrollbarVisibility>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(verticalScrollbarVisibility)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		public RectTransform viewport
		{
			get => Instance_Class.GetProperty(nameof(viewport)).GetGetMethod().Invoke(this)?.GetValue<RectTransform>();
			set => Instance_Class.GetProperty(nameof(viewport)).GetSetMethod().Invoke(this, new IntPtr[] { value == null ? IntPtr.Zero : value.Pointer });
		}

		public enum Direction
		{
			LeftToRight,
			RightToLeft,
			BottomToTop,
			TopToBottom
		}

		[Serializable]
		public class ScrollEvent : UnityEvent // <float>
		{
			public ScrollEvent(IntPtr ptr) : base(ptr) { }
			public ScrollEvent() : base(IntPtr.Zero)
			{
			}
		}

		private enum Axis
		{
			Horizontal,
			Vertical
		}

		public enum ScrollbarVisibility
		{
			Permanent,
			AutoHide,
			AutoHideAndExpandViewport
		}
		
		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.UI"].GetClass("ScrollRect", "UnityEngine.UI");
    }
}
