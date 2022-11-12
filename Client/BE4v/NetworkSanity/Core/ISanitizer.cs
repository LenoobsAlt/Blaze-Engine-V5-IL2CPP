using IL2ExitGames.Client.Photon;
using IL2Photon.Realtime;

namespace NetworkSanity.Core
{
    /// <summary>
    /// Return value of function determines whether it should block the original function
    /// </summary>
    internal interface ISanitizer
    {
        // check event and reject if necessary
        bool OnPhotonEvent(EventData eventData);
        // check if currently ratelimited to make sure vrchat doesn't log those events in case debug logging is enabled
        bool VRCNetworkingClientOnPhotonEvent(EventData eventData);
    }
}
