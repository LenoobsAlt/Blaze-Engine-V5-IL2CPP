using System;
using IL2ExitGames.Client.Photon;
using NetworkSanity.Core;

namespace NetworkSanity.Sanitizers
{
    internal class USpeakSanitizer // : ISanitizer
    {
        private readonly RateLimiter _rateLimiter = new RateLimiter();

        public bool OnPhotonEvent(EventData eventData)
        {
            if (eventData.Code != 1)
                return false;

            return  IsVoicePacketBad(eventData);
        }
        public bool VRCNetworkingClientOnPhotonEvent(EventData eventData)
        {
            if (eventData.Code != 1)
                return false;

            return _rateLimiter.IsRateLimited(eventData.Sender);
        }

        private bool IsVoicePacketBad(EventData eventData)
        {
            if (_rateLimiter.IsRateLimited(eventData.Sender))
                return true;

            if (eventData.CustomData == null)
                return false;

            byte[] bytes = new IL2Array<byte>(eventData.CustomData.Pointer).GetAsByteArray();
            if (bytes.Length <= 8)
            {
                _rateLimiter.BlacklistUser(eventData.Sender, eventData.Code, "len <= 8 | len="+bytes.Length);
                return true;
            }

            var sender = BitConverter.ToInt32(bytes, 0);
            if (sender != eventData.Sender)
            {
                _rateLimiter.BlacklistUser(eventData.Sender, eventData.Code, "sender != eventData.Sender");
                return true;
            }
            /*
            var sourceOffset = 4;
            var source = bytes.Skip(4).ToArray();
            while (sourceOffset < source.Length)
            {
                var container = new USpeakFrameContainer();
                var offset = container.LoadFrom(source, sourceOffset);
                if (offset == -1)
                {
                    _rateLimiter.BlacklistUser(eventData.Sender);
                    return true;
                }

                container.Cleanup();
                sourceOffset += offset;
            }
            */

            return false;
        }
    }
}