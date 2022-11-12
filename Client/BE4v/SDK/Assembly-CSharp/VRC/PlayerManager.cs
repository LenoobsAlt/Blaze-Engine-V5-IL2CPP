using System;
using System.Linq;
using System.Collections.Generic;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace VRC
{
    public class PlayerManager : MonoBehaviour
    {
        public PlayerManager(IntPtr ptr) : base(ptr) { }

        public static PlayerManager Instance
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(Instance));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.Instance)).Name = nameof(Instance);
                return property?.GetGetMethod().Invoke()?.GetValue<PlayerManager>();
            }
        }

        public static Player[] GetPlayerList()
        {
            IL2Method method = Instance_Class.GetMethod(nameof(GetPlayerList));
            if (method == null)
            {
                (method = Instance_Class.GetMethod(x => x.ReturnType.Name == "System.Collections.Generic.List<" + VRC.Player.Instance_Class.FullName + ">")).Name = nameof(GetPlayerList);
            }
            IL2Object result = method?.Invoke();
            if (result == null)
                return null;

            return new IL2List<IntPtr>(result.Pointer).ToArray<Player>();
        }

        public static int MasterId { get; set; }
        public static Player[] PlayersCopy
        {
            get => FindObjectsOfType<Player>().Reverse().ToArray();
        }

        unsafe public static Player GetPlayer(int playerId)
        {
            if (playerId < 0)
                return null;

            return Instance_Class.GetMethod(nameof(GetPlayer)).Invoke(new IntPtr[] { new IntPtr(&playerId) })?.GetValue<Player>();
        }

        public static Player GetPlayer(IL2Photon.Realtime.Player photonPlayer)
        {
            if (photonPlayer == null)
                return null;

            return Instance_Class.GetMethod(nameof(GetPlayer), x => x.GetParameters()[0].ReturnType.Name == IL2Photon.Realtime.Player.Instance_Class.FullName).Invoke(new IntPtr[] { photonPlayer.Pointer })?.GetValue<Player>();
        }

        public static Player GetPlayer(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return null;

            return Instance_Class.GetMethod(nameof(GetPlayer), x => x.GetParameters()[0].ReturnType.Name == typeof(string).FullName).Invoke(new IntPtr[] { new IL2String_utf8(userId).Pointer })?.GetValue<Player>();
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("OnPlayerDisconnected") != null);
    }
}