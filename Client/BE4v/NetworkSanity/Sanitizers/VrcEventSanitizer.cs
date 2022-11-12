using System;
using System.Linq;
using System.Collections.Generic;
using IL2CPP_Core.Objects;
using IL2ExitGames.Client.Photon;
using NetworkSanity.Core;
using VRC.SDKBase;
using BE4v.Mods;
using BE4v.Serilize;

namespace NetworkSanity.Sanitizers
{
    internal class VrcEventSanitizer // : ISanitizer
    {
        private readonly RateLimiter _rateLimiter = new RateLimiter();

        private readonly Dictionary<string, (int, int)> ratelimitValues = new Dictionary<string, (int, int)>()
        {
            { "Generic", (500, 500) },
            // { "ReceiveVoiceStatsSyncRPC", (348, 64) },
            { "InformOfBadConnection", (64, 6) },
            { "initUSpeakSenderRPC", (256, 6) },
            { "InteractWithStationRPC", (128, 32) },
            { "SpawnEmojiRPC", (128, 6) },
            { "SanityCheck", (256, 32) },
            { "PlayEmoteRPC", (256, 6) },
            { "TeleportRPC", (256, 16) },
            { "CancelRPC", (256, 32) },
            { "SetTimerRPC", (256, 64) },
            { "_DestroyObject", (512, 128) },
            { "_InstantiateObject", (512, 128) },
            { "_SendOnSpawn", (512, 128) },
            { "ConfigurePortal", (512, 128) },
            { "UdonSyncRunProgramAsRPC", (512, 128) }, // <--- Udon is gay
            { "ChangeVisibility", (128, 12) },
            { "PhotoCapture", (128, 32) },
            { "TimerBloop", (128, 16) },
            { "ReloadAvatarNetworkedRPC", (128, 12) },
            { "InternalApplyOverrideRPC", (512, 128) },
            { "AddURL", (64, 6) },
            { "Play", (64, 6) },
            { "Pause", (64, 6) },
            { "SendVoiceSetupToPlayerRPC", (512, 6) },
            { "SendStrokeRPC", (512, 32) }
        };


        public bool OnPhotonEvent(EventData eventData)
        {
            if (eventData.Code != 6)
                return false;

            return IsRpcBad(eventData);
        }

        /*
        public bool VRCNetworkingClientOnPhotonEvent(EventData eventData)
        {
            if (eventData.Code != 6)
                return false;

            return Status.isRPCBlock || _rateLimiter.IsRateLimited(eventData.Sender);
        }
        */
        private bool IsRpcBad(EventData eventData)
        {
            if (!_rateLimiter.IsSafeToRun("Generic", 0))
                return true; // Failsafe to prevent extremely high amounts of RPCs passing through

            IL2Object obj = eventData.CustomData;
            if (obj == null)
                return false;

            try
            {
                byte[] bytes = new IL2Array<byte>(obj.Pointer).GetAsByteArray();
                obj = (IL2Object)NonIL_BinarySerializer.Deserialize(bytes);
            }
            catch (Exception)
            {
                _rateLimiter.BlacklistUser(eventData.Sender, eventData.Code, "Bad serilize");
                return true;
            }


            var evtLogEntry = new VRC_EventLog.EventLogEntry(obj.Pointer);

            if (evtLogEntry.instigatorPhotonId != eventData.Sender)
            {
                _rateLimiter.BlacklistUser(eventData.Sender, eventData.Code, "instigator != sender");
                return true;
            }

            var vrcEvent = evtLogEntry.theEvent;

            if (vrcEvent.EventType > VRC_EventHandler.VrcEventType.CallUdonMethod)
            {
                _rateLimiter.BlacklistUser(eventData.Sender, eventData.Code, "overflow eventtype");
                return true;
            }

            if (vrcEvent.EventType != VRC_EventHandler.VrcEventType.SendRPC)
                return false;

            if (!evtLogEntry.ObjectPath.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == ':' || c == '/' || c is ' ' || c == '(' || c == ')' || c == '-' || c == '_'))
            {
                _rateLimiter.BlacklistUser(eventData.Sender, eventData.Code, "invalid object");
                return true;
            }

            if (!_rateLimiter.IsSafeToRun($"G_{vrcEvent.ParameterString}", 0)
                || !_rateLimiter.IsSafeToRun(vrcEvent.ParameterString, eventData.Sender))
                return true;

            IL2Object[] parameters;
            try
            {
                parameters = ParameterSerialization.Decode(vrcEvent.ParameterBytes);
            }
            catch (Exception)
            {
                _rateLimiter.BlacklistUser(eventData.Sender, eventData.Code, "catch params");
                return true;
            }

            if (parameters == null)
            {
                _rateLimiter.BlacklistUser(eventData.Sender, eventData.Code, "params == null");
                return true;
            }

            return false;
        }
    }
}