using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NetworkSanity.Core;
using IL2ExitGames.Client.Photon;
using IL2Photon.Realtime;
using BE4v.Mods;

namespace NetworkSanity
{
    public static class NetworkSanity
    {
        public static List<int> userList = new List<int>();

        public static void Start()
        {
            IEnumerable<Type> types;
            try
            {
                types = Assembly.GetExecutingAssembly().GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                types = e.Types.Where(t => t != null);
            }
            List<ISanitizer> sanitar = new List<ISanitizer>();
            foreach (var t in types)
            {
                if (t.IsAbstract)
                    continue;
                if (!typeof(ISanitizer).IsAssignableFrom(t))
                    continue;

                var sanitizer = Activator.CreateInstance(t) as ISanitizer;
                sanitar.Add(sanitizer);
                $"Add Interface: {t.Name}".GreenPrefix("Sanitizer");
            }
            Sanitizers = sanitar.ToArray();
        }

        public static class LoadBalancingClient
        {
            public static bool OnEvent(IntPtr eventDataPtr)
            {
                if (eventDataPtr == IntPtr.Zero)
                    return false;

                EventData eventData = new EventData(eventDataPtr);
                if (IsValid(eventData))
                    return true;

                if (userList.Contains(eventData.Sender))
                    return false;

                foreach (var i in Sanitizers)
                {
                    if (i.OnPhotonEvent(eventData))
                        return false;
                }
                return true;
            }
        }

        public static class VRCNetworkingClient
        {
            public static bool OnEvent(IntPtr eventDataPtr)
            {
                if (eventDataPtr == IntPtr.Zero)
                    return false;

                EventData eventData = new EventData(eventDataPtr);
                if (IsValid(eventData))
                    return true;

                if (userList.Contains(eventData.Sender))
                    return false;

                foreach (var i in Sanitizers)
                {
                    if (i.VRCNetworkingClientOnPhotonEvent(eventData))
                        return false;
                }

                return true;
            }
        }
        
        public static class PhotonNetwork
        {
            public static bool OnEvent(IntPtr eventDataPtr)
            {
                if (eventDataPtr == IntPtr.Zero)
                    return false;

                EventData eventData = new EventData(eventDataPtr);
                if (IsValid(eventData))
                    return true;

                if (userList.Contains(eventData.Sender))
                    return false;

                foreach (var i in Sanitizers)
                {
                    if (i.OnPhotonEvent(eventData))
                        return false;
                }

                return true;
            }
        }

        private static bool IsValid(EventData eventData)
        {
            int sender = eventData.Sender;
            if (sender < 1) return true;
            int eventCode = eventData.Code;
            if (eventCode == EventCode.Leave || eventCode == EventCode.Join)
            {
                if (userList.Contains(sender))
                    userList.Remove(sender);

                Threads.UpdatePlayers();

                return true;
            }
            return false;
        }

        public static VRC.Player[] players = new VRC.Player[0];

        private static ISanitizer[] Sanitizers = new ISanitizer[0];

        public static string github_thx = "https://github.com/RequiDev/NetworkSanity/";
    }
}
