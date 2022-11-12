using System;
using System.Collections.Generic;
using IL2ExitGames.Client.Photon;
using NetworkSanity.Core;

namespace NetworkSanity.Sanitizers
{
    internal class ValidData  //: ISanitizer
    {
        private readonly RateLimiter _rateLimiter = new RateLimiter();
        private readonly Dictionary<int, (long, int)> limit = new Dictionary<int, (long, int)>();

        public bool OnPhotonEvent(EventData eventData)
        {
            return IsValidClient(eventData);
        }

        public bool VRCNetworkingClientOnPhotonEvent(EventData eventData)
        {
            return _rateLimiter.IsRateLimited(eventData.Sender);
        }

        private bool IsValidClient(EventData eventData)
        {
            return false;
        }

    }
}