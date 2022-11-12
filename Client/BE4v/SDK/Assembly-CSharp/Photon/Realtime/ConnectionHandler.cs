using System;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace IL2Photon.Realtime
{
    public class ConnectionHandler : MonoBehaviour
	{
		public ConnectionHandler(IntPtr ptr) : base(ptr) { }

		static ConnectionHandler()
        {
            Instance_Class.GetProperty(x => x.GetGetMethod()?.ReturnType.Name == LoadBalancingClient.Instance_Class.FullName).Name = "Client";
        }

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClass("ConnectionHandler", "Photon.Realtime");
    }
}