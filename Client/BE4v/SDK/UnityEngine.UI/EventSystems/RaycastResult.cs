using System;

namespace UnityEngine.EventSystems
{
	public struct RaycastResult
	{
		public GameObject gameObject
		{
			get => new GameObject(m_GameObject);
			set => m_GameObject = value.Pointer;
		}

		public bool isValid
		{
			get
			{
				return false;
			}
		}

		public void Clear()
		{
		}

		public override string ToString()
		{
			return string.Empty;
		}

		// UnityEngine.GameObject
		private IntPtr m_GameObject;

		// UnityEngine.EventSystems.BaseRaycaster
		public IntPtr module;

		public float distance;

		public float index;

		public int depth;

		public int sortingLayer;

		public int sortingOrder;

		public Vector3 worldPosition;

		public Vector3 worldNormal;

		public Vector2 screenPosition;

		internal int displayIndex;
	}
}
