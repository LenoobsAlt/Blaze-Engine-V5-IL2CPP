using System;
using System.Collections.Concurrent;
using IL2CPP_Core.Objects;
using IL2ExitGames.Client.Photon;
using NetworkSanity.Core;

namespace NetworkSanity.Sanitizers
{
    internal class OwnershipTransfer // : ISanitizer
    {
        private readonly RateLimiter _rateLimiter = new RateLimiter();

        public static int fps = 0;
        public static readonly ConcurrentDictionary<int, int> limit = new ConcurrentDictionary<int, int>();

        // OwnershipRequest 209
        // OwnershipTransfer 210
        public bool OnPhotonEvent(EventData eventData)
        {
            if (eventData.Code == 7)
                return _rateLimiter.IsRateLimited(eventData.Sender);

            if (eventData.Code != 209 && eventData.Code != 210)
                return false;

            return IsOwnershipTransfer(eventData);
        }

        public bool VRCNetworkingClientOnPhotonEvent(EventData eventData)
        {
            if (eventData.Code == 7)
                return _rateLimiter.IsRateLimited(eventData.Sender);

            if (eventData.Code != 209 && eventData.Code != 210)
                return false;

            return _rateLimiter.IsRateLimited(eventData.Sender);
        }

        private bool IsOwnershipTransfer(EventData eventData)
        {
            IL2Object obj = eventData.CustomData;
            if (obj == null)
            {
                _rateLimiter.BlacklistUser(eventData.Sender, eventData.Code, "CustomData == null");
                return true;
            }

            byte[] bytes = new IL2Array<byte>(eventData.CustomData.Pointer).GetAsByteArray();
            if (bytes.Length != 8)
            {
                _rateLimiter.BlacklistUser(eventData.Sender, eventData.Code, "len != 8");
                return true;
            }

            int transObj = BitConverter.ToInt32(bytes, 0);
            int sender = BitConverter.ToInt32(bytes, 4);
            if (VRC.PlayerManager.MasterId == eventData.Sender)
                return false;

            if (sender != eventData.Sender)
            {
                _rateLimiter.BlacklistUser(eventData.Sender, eventData.Code, "Sender != Sender");
                return true;
            }
            if (transObj < 1)
            {
                _rateLimiter.BlacklistUser(eventData.Sender, eventData.Code, "object < 1");
                return true;
            }

            int value = limit.AddOrUpdate(sender, 0, (key, oldValue) => oldValue + 1);
            if (value > 2)
            {
                _rateLimiter.BlacklistUser(eventData.Sender, eventData.Code, "Anti-flood");
                return true;
            }
            /*
            if (transObj.ToString().StartsWith(sender.ToString()))
            {
                for (int i = 1; i <= 4; i++)
                {
                    if (transObj.ToString() == sender + "0000" + i)
                    {
                        return true;
                    }
                }
            }
            */

            // [Debug 210] Sender: 521 | TransObject: 62800004 | Sender: 628
            // $"Sender: {eventData.Sender} | TransObject: {transObj} | Sender: {sender}".RedPrefix("Debug " + eventData.Code);
            /*
            int sender = eventData.Sender;
            var argObject = BitConverter.ToInt32(bytes, 0);
            var argSender = BitConverter.ToInt32(bytes, 4);
            if (argObject <= 0)
            {
                _rateLimiter.BlacklistUser(eventData.Sender, eventData.Code, "object <= 0  |" + argObject + "|" + argSender);
                return true;
            }
            for (int i=0;i<=5;i++)
            {
                if (argSender.ToString() == argObject + "0000" + i)
                {
                    return true;
                }
            }
            /*
            if (!limit.ContainsKey(sender))
            {
                limit.Add(sender, (Threads.timestamp, 0));
            }
            else
            {
                if (limit[sender].Item1 != Threads.timestamp)
                {
                    limit.Remove(sender);
                    return true;
                }
                limit[sender] = (limit[sender].Item1, limit[sender].Item2 + 1);
                if (limit[sender].Item2 > 5)
                {
                    _rateLimiter.BlacklistUser(eventData.Sender);
                    return true;
                }
            }
            */
            return false;
        }

    }
}