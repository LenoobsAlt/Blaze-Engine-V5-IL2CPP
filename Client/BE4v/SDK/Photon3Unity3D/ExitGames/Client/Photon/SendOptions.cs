namespace IL2ExitGames.Client.Photon
{
	public struct SendOptions
	{
		public bool Reliability
		{
			get
			{
				return DeliveryMode == DeliveryMode.Reliable;
			}
			set
			{
				DeliveryMode = (value ? DeliveryMode.Reliable : DeliveryMode.Unreliable);
			}
		}

		public static readonly SendOptions SendReliable = new SendOptions
		{
			Reliability = true
		};

		public static readonly SendOptions SendUnreliable = new SendOptions
		{
			Reliability = false
		};

		public DeliveryMode DeliveryMode;

		public bool Encrypt;

		public byte Channel;
	}
}
