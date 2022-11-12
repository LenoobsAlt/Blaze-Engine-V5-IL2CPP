using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    static NetworkManager()
    {
        var methodsPlayer = Instance_Class.GetMethods(x => x.GetParameters().Length == 1 && x.GetParameters()[0].ReturnType.Name == VRC.Player.Instance_Class.FullName);
        try
        {
            methodsPlayer[0].Name = "OnPlayerJoined";
        }
        catch { "OnPlayerJoined not found".RedPrefix("Method"); }

        try
        {
            methodsPlayer[1].Name = "OnPlayerConnect";
        }
        catch { "OnPlayerConnect not found".RedPrefix("Method"); }
        

        try
        {
            methodsPlayer[2].Name = "OnPlayerLeft";
        }
        catch { "OnPlayerLeft not found".RedPrefix("Method"); }
    }
    public NetworkManager(IntPtr ptr) : base(ptr) { }



    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("OnCustomAuthenticationResponse") != null && x.GetMethod("Awake") != null);
}