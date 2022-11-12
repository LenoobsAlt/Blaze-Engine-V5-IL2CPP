namespace IL2ExitGames.Client.Photon
{
	public enum EgMessageType : byte
	{
		Init,
		InitResponse,
		Operation,
		OperationResponse,
		Event,
		InternalOperationRequest = 6,
		InternalOperationResponse,
		Message,
		RawMessage
	}
}
