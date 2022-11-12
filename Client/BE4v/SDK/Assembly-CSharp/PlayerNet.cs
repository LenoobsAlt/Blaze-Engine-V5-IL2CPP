using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class PlayerNet : VRCNetworkBehaviour
{
	public PlayerNet(IntPtr ptr) : base(ptr) { }

	public short Ping
	{
		get
		{
			IL2Property property = Instance_Class.GetProperty(nameof(Ping));
			if (property == null)
            {
				(property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == typeof(short).FullName)).Name = nameof(Ping);
				if (property == null)
					return default;
			}
			return property.GetGetMethod().Invoke<short>(this).GetValue();
		}
	}

	// FPS
	public byte ApproxDeltaTimeMS
	{
		get
		{
			IL2Property property = Instance_Class.GetProperty(nameof(ApproxDeltaTimeMS));
			if (property == null)
			{
				(property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == typeof(byte).FullName)).Name = nameof(ApproxDeltaTimeMS);
				if (property == null)
					return default;
			}
			return property.GetGetMethod().Invoke<byte>(this).GetValue();
		}
	}

	public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClass(VRC.Player.Instance_Class.GetField("_playerNet")?.ReturnType.Name);
}