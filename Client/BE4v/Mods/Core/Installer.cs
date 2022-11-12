using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using BE4v.SDK;
using BE4v.Patch.Core;
using SharpDisasm.Udis86;
using IL2CPP_Core.Objects;

namespace BE4v.Mods.Core
{
    public delegate void _Update(IntPtr instance);
    public delegate void _OnGUI(IntPtr instance);
    public delegate void _null(IntPtr instance);
    public static class Installer
    {
        public static _Update __Update;
        public static _OnGUI __OnGUI;
        public static _null __Awake;

        private static T1[] LoadInterfaces<T1>() where T1 : IThread
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
            List<T1> list = new List<T1>();
            foreach (var t in types)
            {
                if (t.IsAbstract)
                    continue;
                if (!typeof(T1).IsAssignableFrom(t))
                    continue;

                var sanitizer = (T1)Activator.CreateInstance(t);
                list.Add(sanitizer);
                $"Load Functions: {t.Name}".GreenPrefix(typeof(T1).Name);
            }
            return list.ToArray();
        }

        public unsafe static void Start()
        {
            try
            {
                IL2Method method = InteractivePlayer.Instance_Class.GetMethod("Update");
                if (method != null)
                {
                    updates = LoadInterfaces<IUpdate>();
                    __Update = PatchUtils.FastPatch<_Update>(method, Update);
                    // *(IntPtr*)method.Pointer.ToPointer() = ((_Update)Update).Method.MethodHandle.GetFunctionPointer();
                }
                else
                    $"Installer: Method Update not found!".RedPrefix("Patch");
            }
            catch (Exception ex)
            {
                ex.ToString().WriteMessage("Patch");
            }
            try
            {
                IL2Method method = Analytics.Instance_Class.GetMethod("Awake");
                if (method != null)
                {
                    __Awake = PatchUtils.FastPatch<_null>(method, Awake);
                    // *(IntPtr*)method.Pointer.ToPointer() = ((_Update)Update).Method.MethodHandle.GetFunctionPointer();
                }
                else
                    $"Installer: Method Awake not found!".RedPrefix("Patch");
            }
            catch (Exception ex)
            {
                ex.ToString().WriteMessage("Patch");
            }
            // ---
            try
            {
                IL2Method method = OVRLipSyncMicInput.Instance_Class.GetMethod("OnGUI");
                if (method != null)
                {
                    onGUIs = LoadInterfaces<IOnGUI>();
                    __OnGUI = PatchUtils.FastPatch<_OnGUI>(method, OnGUI);
                    // *(IntPtr*)method.Pointer.ToPointer() = ((_OnGUI)OnGUI).Method.MethodHandle.GetFunctionPointer();
                }
                else
                    $"Installer: Method OnGUI not found!".RedPrefix("Patch");
            }
            catch (Exception ex)
            {
                ex.ToString().WriteMessage("Patch");
            }

            try
            {
                IL2Method[] methods = OVRLipSyncMicInput.Instance_Class.GetMethods(x => !x.IsStatic && x.GetParameters().Length == 0 && x.Name != "OnGUI");
                foreach(var method in methods)
                {
                    if (method != null)
                    {
                        new IL2Patch(method, (_null)StopMicrophone);
                    }
                    else
                        throw new NullReferenceException();
                }
            }
            catch (Exception ex)
            {
                ex.ToString().WriteMessage("Patch");
            }
        }

        private static IUpdate[] updates = new IUpdate[0];
        public static void Update(IntPtr instance)
        {
            Threads.isCtrl = Input.GetKey(KeyCode.LeftControl);
            try
            {
                foreach (var i in updates)
                {
                    i.Update();
                }
            }
            finally
            {
                if (instance != IntPtr.Zero)
                    __Update(instance);
            }
        }
        
        public static void Awake(IntPtr instance)
        {
            try
            {
                Mods.Threads.Create();
            }
            finally
            {
                if (instance != IntPtr.Zero)
                    __Awake(instance);
            }
        }

        public static void StopMicrophone(IntPtr instance)
        {
        }

        private static IOnGUI[] onGUIs = new IOnGUI[0];
        public static void OnGUI(IntPtr instance)
        {
            try
            {
                foreach (var i in onGUIs)
                {
                    i.OnGUI();
                }
            }
            finally
            {
                if (instance != IntPtr.Zero)
                    __OnGUI(instance);
            }
        }
    }
}
