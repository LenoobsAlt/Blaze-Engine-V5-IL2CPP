using System;
using System.Collections.Generic;
using IL2ExitGames.Client.Photon;
using NetworkSanity.Core;

namespace NetworkSanity.Sanitizers
{
    internal class ModerationEvent  : ISanitizer
    {
        private readonly RateLimiter _rateLimiter = new RateLimiter();
        
        public bool OnPhotonEvent(EventData eventData)
        {
            //if (eventData.Code != 33)
            //    return false;

            if (eventData.Code == 1
            || eventData.Code == 7
            || eventData.Code == 8
            || eventData.Code == 9
            )
                return false;

            // ClientLogs.Add("Player " + eventData.Sender + " send " + eventData.Code + " event");
            return false;
        }

        public bool VRCNetworkingClientOnPhotonEvent(EventData eventData)
        {

            // object obj = FromIL2CPPToManaged<object>(eventData_0.CustomData);
            return false;
        }
    }
}