using System;

namespace IL2ExitGames.Client.Photon
{
	public enum ConnectionProtocol : byte
	{
		Udp,
		Tcp,
		WebSocket = 4,
		WebSocketSecure
	}
}
