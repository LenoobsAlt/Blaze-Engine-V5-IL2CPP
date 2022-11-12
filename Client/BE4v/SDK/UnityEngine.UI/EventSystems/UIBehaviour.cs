using System;
using IL2CPP_Core.Objects;

namespace UnityEngine.EventSystems
{
	public abstract class UIBehaviour : MonoBehaviour
	{
		public UIBehaviour(IntPtr ptr) : base(ptr) { }
	
		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.UI"].GetClass("UIBehaviour", "UnityEngine.EventSystems");
	}
}
