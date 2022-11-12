using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;
using VRC.SDKBase;

namespace VRC
{
    public static class Network
    {
        static Network()
        {
            Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetProperty(y => y.GetGetMethod()?.ReturnType.Name == VRC_EventHandler.Instance_Class.FullName && y.GetSetMethod() != null) != null);
            if (Instance_Class == null)
            {
                "VRC::Network::Instance_Class not found!".RedPrefix("WARNING!");
            }
        }

        [Obsolete]
        public static Player MasterPlayer
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(MasterPlayer));
                if (property == null)
                {
                    (property = Instance_Class.GetProperties(x => x.GetGetMethod().ReturnType.Name == GameObject.Instance_Class.FullName).FirstOrDefault()).Name = nameof(MasterPlayer);
                    if (property == null)
                        return null;
                }
                return property.GetGetMethod().Invoke()?.GetValue<Player>();
            }
        }

        [Obsolete]
        public static Player LocalPlayer
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(LocalPlayer));
                if (property == null)
                {
                    (property = Instance_Class.GetProperties(x => x.GetGetMethod().ReturnType.Name == GameObject.Instance_Class.FullName).LastOrDefault()).Name = nameof(LocalPlayer);
                    if (property == null)
                        return null;
                }
                return property.GetGetMethod().Invoke()?.GetValue<Player>();
            }
        }


        unsafe public static DateTime _networkDateTime
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(_networkDateTime));
                if (field == null)
                    (field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(DateTime).FullName)).Name = nameof(_networkDateTime);
                return field?.GetValue<DateTime>().GetValue() ?? default(DateTime);
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(_networkDateTime));
                if (field == null)
                    (field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(DateTime).FullName)).Name = nameof(_networkDateTime);
                field?.SetValue(new IntPtr(&value));
            }
        }

        unsafe public static double CalculateServerDeltaTime(double timeInSeconds, double previousTimeInSeconds)
        {
            IL2Method method = Instance_Class.GetMethod(nameof(CalculateServerDeltaTime));
            if (method == null)
            {
                (method = Instance_Class.GetMethods().First(
                    x =>
                        x.ReturnType.Name == typeof(double).FullName &&
                        x.GetParameters().Length == 2
                )).Name = nameof(CalculateServerDeltaTime);
                if (method == null)
                    return default;
            }
            return method.Invoke<double>(new IntPtr[] { new IntPtr(&timeInSeconds), new IntPtr(&previousTimeInSeconds) }).GetValue();
        }

        unsafe public static GameObject Instantiate(VRC_EventHandler.VrcBroadcastType broadcast, string prefabPathOrDynamicPrefabName, Vector3 position, Quaternion rotation)
        {
            IL2Method method = Instance_Class.GetMethod(nameof(Instantiate), x => x.GetParameters().Length == 4 && x.ReturnType.Name == GameObject.Instance_Class.FullName);
            if (method == null)
            {
                (method = Instance_Class.GetMethod(x => x.GetParameters().Length == 4 && x.ReturnType.Name == GameObject.Instance_Class.FullName)).Name = nameof(Instantiate);
                if (method == null)
                    return null;
            }

            return method.Invoke(new IntPtr[] { new IntPtr(&broadcast), new IL2String_utf16(prefabPathOrDynamicPrefabName).Pointer, new IntPtr(&position), new IntPtr(&rotation) })?.GetValue<GameObject>();
        }

        unsafe public static void RPC(VRC_EventHandler.VrcTargetType targetClients, GameObject targetObject, string methodName, IntPtr[] parameters)
        {
            IL2Method method = Instance_Class.GetMethod("RPC", x => x.GetParameters().Length == 4 && x.GetParameters()[0].ReturnType.Name.EndsWith(".RPC.Destination"));
            if (method == null)
            {
                (method = Instance_Class.GetMethods().Where(x => x.GetParameters().Length == 4 && x.ReturnType.Name == "System.Void").First(
                    x =>
                        x.GetParameters()[0].ReturnType.Name.EndsWith(".RPC.Destination") &&
                        x.GetParameters()[1].ReturnType.Name == GameObject.Instance_Class.FullName &&
                        x.GetParameters()[2].ReturnType.Name == typeof(string).FullName &&
                        x.GetParameters()[3].ReturnType.Name == typeof(object[]).FullName
                )).Name = "RPC";
                if (method == null)
                    return;
            }
            method.Invoke(IntPtr.Zero, new IntPtr[] {
                new IntPtr(&targetClients),
                targetObject == null ? IntPtr.Zero : targetObject.Pointer,
                new IL2String_utf16(methodName).Pointer,
                parameters.ToObjectPtr()
            }, ex: true);
        }

        unsafe public static GameObject FindGameObject(string path, bool suppressErrors = false)
        {
            IL2Method method = Instance_Class.GetMethod(nameof(FindGameObject));
            if (method == null)
            {
                (method = Instance_Class.GetMethod(x => x.GetParameters().Length == 2
                    && x.GetParameters()[0].ReturnType.Name == typeof(string).FullName
                    && x.GetParameters()[1].ReturnType.Name == typeof(bool).FullName)).Name = nameof(FindGameObject);
                if (method == null)
                    return null;
            }
            return method.Invoke(new IntPtr[] { new IL2String_utf16(path).Pointer, new IntPtr(&suppressErrors) })?.GetValue<GameObject>();
        }

        public static GameObject SceneDispatcherObject
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(SceneDispatcherObject));
                if (property == null)
                {
                    (property = Instance_Class.GetProperty(GameObject.Instance_Class)).Name = nameof(SceneDispatcherObject);
                    if (property == null)
                        return null;
                }
                return property.GetGetMethod().Invoke()?.GetValue<GameObject>();
            }
            set
            {
                IL2Property property = Instance_Class.GetProperty(nameof(SceneDispatcherObject));
                if (property == null)
                {
                    (property = Instance_Class.GetProperty(GameObject.Instance_Class)).Name = nameof(SceneDispatcherObject);
                    if (property == null)
                        return;
                }
                property.GetGetMethod().Invoke(new IntPtr[] { value == null ? IntPtr.Zero : value.Pointer });
            }
        }
        public static VRC_EventHandler SceneEventHandler
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(SceneEventHandler));
                if (property == null)
                    (property = Instance_Class.GetProperty(VRC_EventHandler.Instance_Class)).Name = nameof(SceneEventHandler);
                return property.GetGetMethod().Invoke()?.GetValue<VRC_EventHandler>();
            }
            set
            {
                IL2Property property = Instance_Class.GetProperty(nameof(SceneEventHandler));
                if (property == null)
                    (property = Instance_Class.GetProperty(VRC_EventHandler.Instance_Class)).Name = nameof(SceneEventHandler);
                property.GetSetMethod().Invoke(new IntPtr[] { value == null ? IntPtr.Zero : value.Pointer });
            }
        }

        public static ObjectInstantiator Instantiator
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(Instantiator));
                if (field == null)
                    (field = Instance_Class.GetField(ObjectInstantiator.Instance_Class)).Name = nameof(Instantiator);
                return field.GetValue()?.GetValue<ObjectInstantiator>();
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(Instantiator));
                if (field == null)
                    (field = Instance_Class.GetField(ObjectInstantiator.Instance_Class)).Name = nameof(Instantiator);
                field.SetValue(value == null ? IntPtr.Zero : value.Pointer);
            }
        }

        public static IL2Class Instance_Class;
    }
}