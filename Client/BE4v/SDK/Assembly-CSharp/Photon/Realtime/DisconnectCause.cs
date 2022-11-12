namespace IL2Photon.Realtime
{
	public enum DisconnectCause
	{
		None,
		ExceptionOnConnect,
		Exception,
		ServerTimeout,
		DisconnectByServer = 3,
		ClientTimeout,
		TimeoutDisconnect = 4,
		DisconnectByServerLogic,
		DisconnectByServerReasonUnknown,
		InvalidAuthentication,
		CustomAuthenticationFailed,
		AuthenticationTicketExpired,
		MaxCcuReached,
		DisconnectByServerUserLimit = 10,
		InvalidRegion,
		OperationNotAllowedInCurrentState,
		DisconnectByClientLogic
	}
}