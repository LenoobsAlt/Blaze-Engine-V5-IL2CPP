using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace VRTK
{
	public struct UIPointerEventArgs
	{
		// VRTK_ControllerReference
		public IntPtr controllerReference;

		public bool isActive;

		// UnityEngine.GameObject
		public IntPtr currentTarget;

		// UnityEngine.GameObject
		public IntPtr previousTarget;

		public RaycastResult raycastResult;
	}
}
