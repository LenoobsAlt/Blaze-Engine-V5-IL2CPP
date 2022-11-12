using System;
using System.Linq;
using IL2CPP_Core.Objects;
using Steamworks;

public class SteamNetworkingConnectionInterface : ConnectionInterface
{
    public SteamNetworkingConnectionInterface(IntPtr ptr) : base(ptr) { }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("OnConnecting")?.GetParameters().Length == 1);
}