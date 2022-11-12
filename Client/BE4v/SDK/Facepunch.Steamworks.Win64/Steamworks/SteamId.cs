using System;

namespace Steamworks
{
	public struct SteamId
	{
		public static implicit operator SteamId(ulong value)
		{
			SteamId steam = new SteamId();
			steam.Value = value;
			return steam;
		}

		public static implicit operator ulong(SteamId value)
		{
			return value.Value;
		}

		public override string ToString()
		{
			return Value.ToString();
		}

		public ulong Value;
	}
}
