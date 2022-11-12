using System;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace IL2Photon.Pun
{
    [Obsolete]
    public class PhotonView : MonoBehaviour
    {
        public PhotonView(IntPtr ptr) : base(ptr) { }

        public int viewIdField
        {
            get => Instance_Class.GetField(nameof(viewIdField)).GetValue<int>(this).GetValue();
        }

        unsafe public static PhotonView Find(int viewID)
        {
            IL2Method method = Instance_Class.GetMethod(nameof(Find));
            if (method == null)
                (method = Instance_Class.GetMethod(x => x.ReturnType.Name == Instance_Class.FullName && x.GetParameters().Length == 1 && x.GetParameters()[0].ReturnType.Name == typeof(int).FullName)).Name = nameof(Find);
            return method?.Invoke(new IntPtr[] { new IntPtr(&viewID) }).GetValue<PhotonView>();
        }

        /*
        public void RPC(string command, RpcTarget target, params IntPtr[] objects)
        {
            RpcSecure(command, target, false, objects);
        }
        public void RpcSecure(string command, RpcTarget target, bool encrypt, params IntPtr[] objects) 
        {
            PhotonNetwork.RPC(this, command, target, encrypt, objects);
        }

        public void RPC(string command, IL2Photon.Realtime.Player targetPlayer, params IntPtr[] objects)
        {
            RpcSecure(command, targetPlayer, false, objects);
        }

        public void RpcSecure(string command, IL2Photon.Realtime.Player targetPlayer, bool encrypt, params IntPtr[] objects) 
        {
            PhotonNetwork.RPC(this, command, targetPlayer, encrypt, objects);
        }
        */
        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClass("PhotonView", "Photon.Pun");
    }
}
