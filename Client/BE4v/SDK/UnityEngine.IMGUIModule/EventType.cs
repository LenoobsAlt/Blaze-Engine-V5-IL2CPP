using System;

namespace UnityEngine
{
	public enum EventType
	{
		MouseDown,
		MouseUp,
		MouseMove,
		MouseDrag,
		KeyDown,
		KeyUp,
		ScrollWheel,
		Repaint,
		Layout,
		DragUpdated,
		DragPerform,
		DragExited = 15,
		Ignore = 11,
		Used,
		ValidateCommand,
		ExecuteCommand,
		ContextClick = 16,
		MouseEnterWindow = 20,
		MouseLeaveWindow,
		[Obsolete]
		mouseDown = 0,
		[Obsolete]
		mouseUp,
		[Obsolete]
		mouseMove,
		[Obsolete]
		mouseDrag,
		[Obsolete]
		keyDown,
		[Obsolete]
		keyUp,
		[Obsolete]
		scrollWheel,
		[Obsolete]
		repaint,
		[Obsolete]
		layout,
		[Obsolete]
		dragUpdated,
		[Obsolete]
		dragPerform,
		[Obsolete]
		ignore,
		[Obsolete]
		used
	}
}
