using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;
using VRC.SDKBase;
using VRC.Core;

namespace VRC
{
    public class Player : MonoBehaviour
    {
        public Player(IntPtr ptr) : base(ptr) { }
        // <!---------- ---------- ---------->
        // <!---------- PROPERTY'S ---------->
        // <!---------- ---------- ---------->
        public static Player Instance
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(Instance));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.Instance)).Name = nameof(Instance);
                return property?.GetGetMethod().Invoke()?.GetValue<Player>();
            }
        }

        public APIUser user
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(user));
                if (property == null)
                    (property = Instance_Class.GetProperty(APIUser.Instance_Class)).Name = nameof(user);
                return property?.GetGetMethod().Invoke(this)?.GetValue<APIUser>();
            }
        }

        public PlayerNet playerNet
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(playerNet));
                if (property == null)
                    (property = Instance_Class.GetProperty(PlayerNet.Instance_Class)).Name = nameof(playerNet);
                return property?.GetGetMethod().Invoke(this)?.GetValue<PlayerNet>();
            }
        }

        public IL2Photon.Realtime.Player PhotonPlayer
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(PhotonPlayer));
                if (property == null)
                    (property = Instance_Class.GetProperty(IL2Photon.Realtime.Player.Instance_Class)).Name = nameof(PhotonPlayer);
                return property?.GetGetMethod().Invoke(this)?.GetValue<IL2Photon.Realtime.Player>();
            }
        }

        public VRCPlayer Components
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(Components));
                if (property == null)
                    (property = Instance_Class.GetProperty(VRCPlayer.Instance_Class)).Name = nameof(Components);
                return property?.GetGetMethod().Invoke(this)?.GetValue<VRCPlayer>();
            }
        }

        public VRCPlayerApi playerApi
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(playerApi));
                if (property == null)
                    (property = Instance_Class.GetProperty(VRCPlayerApi.Instance_Class)).Name = nameof(playerApi);
                return property?.GetGetMethod().Invoke(this)?.GetValue<VRCPlayerApi>();
            }
        }

        public bool IsBot
        {
            get
            {
                PlayerNet net = playerNet;
                if (net != null)
                    return (net.Ping == 0 && net.ApproxDeltaTimeMS == 0) || transform.position == Vector3.zero;
                return true;
            }
        }

        public bool IsMuted
        {

            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(IsMuted));
                if (property == null)
                    (property = Instance_Class.GetProperties(x => x.GetGetMethod().ReturnType.Name == typeof(bool).FullName && x.GetSetMethod() != null).Skip(2).FirstOrDefault()).Name = nameof(IsMuted);

                return property?.GetGetMethod().Invoke<bool>(this).GetValue() ?? default(bool);
            }
        }

        unsafe public bool IsBlocked
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(IsBlocked));
                if (field == null)
                    (field = Instance_Class.GetFields(x => x.ReturnType.Name == typeof(bool).FullName).First()).Name = nameof(IsBlocked);
                return field.GetValue<bool>(this).GetValue();
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(IsBlocked));
                if (field == null)
                    (field = Instance_Class.GetFields(x => x.ReturnType.Name == typeof(bool).FullName).First()).Name = nameof(IsBlocked);
                field.SetValue(this, new IntPtr(&value));
            }
        }

        unsafe public bool IsBlockedBy
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(IsBlockedBy));
                if (field == null)
                    (field = Instance_Class.GetFields(x => x.ReturnType.Name == typeof(bool).FullName).Skip(1).First()).Name = nameof(IsBlockedBy);
                return field.GetValue<bool>(this).GetValue();
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(IsBlockedBy));
                if (field == null)
                    (field = Instance_Class.GetFields(x => x.ReturnType.Name == typeof(bool).FullName).Skip(1).First()).Name = nameof(IsBlockedBy);
                field.SetValue(this, new IntPtr(&value));
            }
        }

        public void OnNetworkReady()
        {
            Instance_Class.GetMethod(nameof(OnNetworkReady)).Invoke(this);
        }

        /*
        private static IL2Property propertyIsFriend = null;
        unsafe public bool IsFriend
        {
            get
            {
                if (propertyIsFriend == null)
                {
                    var properties = Instance_Class.GetProperties().Where(x => x.GetGetMethod().ReturnType.Name == typeof(bool).FullName);
                    var methodAPI = APIUser.Instance_Class.GetProperty("friendIDs").GetGetMethod();
                    foreach (var prop in properties)
                    {
                        var method = prop.GetGetMethod();
                        if (method == null)
                            continue;

                        var disassembler = disasm.GetDisassembler(method);
                        var instructions = disassembler.Disassemble();
                        foreach (var @obj in ILCode.CastToILObject(instructions))
                        {
                            if (@obj.Type != ILType.method)
                                continue;

                            if (*(IntPtr*)methodAPI.ptr == @obj.ptr)
                            {
                                propertyIsFriend = prop;
                                break;
                            }
                        }
                        if (propertyIsFriend != null) break;
                    }
                    if (propertyIsFriend == null)
                        return false;
                }
                return propertyIsFriend.GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
            }
        }

        public IL2String userId
        {

            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(userId));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == typeof(string).FullName && x.GetSetMethod() == null)).Name = nameof(userId);
                return property?.GetGetMethod().Invoke(ptr)?.unbox_ToString();
            }
        }

        // <!---------- ------- ---------->
        // <!---------- FIELD'S ---------->
        // <!---------- ------- ---------->
        public USpeaker mUSpeaker
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(mUSpeaker));
                if (field == null)
                    (field = Instance_Class.GetField(USpeaker.Instance_Class)).Name = nameof(mUSpeaker);
                return field.GetValue(ptr)?.unbox<USpeaker>();
            }
        }

        public new IL2String ToString()
        {
            return Instance_Class.GetMethod(nameof(ToString)).Invoke(ptr)?.unbox_ToString();
        }
        */
        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetField("_USpeaker") != null);
    }
}
