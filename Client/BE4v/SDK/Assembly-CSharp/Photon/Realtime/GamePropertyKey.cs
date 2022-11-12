using System;

namespace IL2Photon.Realtime
{
	public class GamePropertyKey
	{
		public const byte MaxPlayers = 255;

		public const byte IsVisible = 254;

		public const byte IsOpen = 253;

		public const byte PlayerCount = 252;

		public const byte Removed = 251;

		public const byte PropsListedInLobby = 250;

		public const byte CleanupCacheOnLeave = 249;

		public const byte MasterClientId = 248;

		public const byte ExpectedUsers = 247;

		public const byte PlayerTtl = 246;

		public const byte EmptyRoomTtl = 245;
	}
}
