using System;
using System.Linq;
using IL2CPP_Core.Objects;
using VRC.Core;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public RoomManager(IntPtr ptr) : base(ptr) { }

    public static string GetPhotonRoomIDForWorldInstance(ApiWorldInstance apiWorldInstance)
    {
        return apiWorldInstance.instanceWorld.id + ":" + apiWorldInstance.idWithTags;
    }

    unsafe public static ApiWorldInstance SelectWorldInstanceToJoin(ApiWorld world, string desiredInstanceId, ApiWorldInstance.AccessType worldDefaultAccessType)
    {
        IL2Method method = Instance_Class.GetMethod(nameof(SelectWorldInstanceToJoin));
        if (method == null)
            (method = Instance_Class.GetMethod(x => x.GetParameters().Length == 3 && x.GetParameters()[0].ReturnType.Name == ApiWorld.Instance_Class.FullName)).Name = nameof(SelectWorldInstanceToJoin);
        
        return method?.Invoke(new IntPtr[] { world == null ? IntPtr.Zero : world.Pointer, new IL2String_utf16(desiredInstanceId).Pointer, new IntPtr(&worldDefaultAccessType) })?.GetValue<ApiWorldInstance>();
    }

    unsafe public static bool EnterWorld(ApiWorld world, ApiWorldInstance worldInstance)
    {
        IL2Method method = Instance_Class.GetMethod(nameof(EnterWorld));
        if (method == null)
            (method = Instance_Class.GetMethod(x => x.GetParameters().Length == 4 && x.GetParameters()[0].ReturnType.Name == ApiWorld.Instance_Class.FullName)).Name = nameof(EnterWorld);

        int zero = 0;
        return method?.Invoke<bool>(new IntPtr[] { world == null ? IntPtr.Zero : world.Pointer, worldInstance == null ? IntPtr.Zero : worldInstance.Pointer, IntPtr.Zero, new IntPtr(&zero) }).GetValue()??false;
    }

    public static string currentAuthorId
    {
        get => currentRoom?.authorId;
    }

    public static string currentOwnerId
    {
        get => currentWorldInstance?.ownerId;
    }

    public static ApiWorld currentRoom
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(currentRoom));
            if (field == null)
                (field = Instance_Class.GetField(ApiWorld.Instance_Class)).Name = nameof(currentRoom);
            return field?.GetValue()?.GetValue<ApiWorld>();
        }
    }

    internal static ApiWorldInstance currentWorldInstance
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(currentWorldInstance));
            if (field == null)
                (field = Instance_Class.GetField(ApiWorldInstance.Instance_Class)).Name = nameof(currentWorldInstance);
            return field?.GetValue()?.GetValue<ApiWorldInstance>();
        }
    }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.BaseType == MonoBehaviour.Instance_Class && x.GetField(y => y.ReturnType.Name == "System.Collections.Generic.Dictionary<" + typeof(int).FullName + "," + PortalInternal.Instance_Class.FullName + ">") != null);
}