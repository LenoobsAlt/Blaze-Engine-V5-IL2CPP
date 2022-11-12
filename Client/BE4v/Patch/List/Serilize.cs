using System;
using IL2CPP_Core.Objects;
using IL2Photon.Realtime;
using IL2ExitGames.Client.Photon;
using BE4v.Mods;
using BE4v.MenuEdit;
using BE4v.Patch.Core;
using BE4v.SDK;
using UnityEngine;
using VRC.SDKBase;
using System.Runtime.InteropServices;
using VRC;
using System.Data.SqlTypes;

namespace BE4v.Patch.List
{
    public class Serilize : IPatch
    {
        public delegate bool _OpRaiseEvent(IntPtr instance, byte operationCode, IntPtr operationParameters, IntPtr raiseEventOptions, SendOptions sendOptions, IntPtr method);
        public static void Toggle()
        {
            Status.isSerilize = !Status.isSerilize;
            CustomQuickMenu.Menus.MainMenu.Serilize.Refresh();
        }

        public void Start()
        {
            IL2Method method = IL2Photon.Realtime.LoadBalancingClient.Instance_Class.GetMethod("OpRaiseEvent");
            if (method == null)
                throw new NullReferenceException();


            patch = new IL2Patch(method, (_OpRaiseEvent)OpRaiseEvent);
            __OpRaiseEvent = patch.CreateDelegate<_OpRaiseEvent>();
            patch.Enabled = false;
        }
        public static GameObject gameObject = null;
        public static bool DoesCloneExist = false;
        public static void GenClone()
        {
            if (VRCPlayer.Instance == null || VRCPlayer.Instance.avatarGameObject == null)
            {
                "Could Not gen avi clone".RedPrefix("Error");

            }
            
            if (VRCPlayer.Instance != null && VRCPlayer.Instance.avatarGameObject != null && DoesCloneExist == false)
            {
                 gameObject = UnityEngine.Object.Instantiate(VRCPlayer.Instance.avatarGameObject, VRCPlayer.Instance.transform);

                gameObject.name = "Local Avatar Clone";
                gameObject.transform.position = VRCPlayer.Instance.avatarGameObject.transform.position;
                gameObject.transform.rotation = VRCPlayer.Instance.avatarGameObject.transform.rotation;
                foreach (Transform componentsInChild in gameObject.GetComponentsInChildren<Transform>(includeInactive: true))
                {
                    componentsInChild.gameObject.layer = 0;
                    if ((double)componentsInChild.localScale.x < 0.001 && (double)componentsInChild.localScale.y < 0.001 && (double)componentsInChild.localScale.z < 0.001)
                    {
                        componentsInChild.localScale = new Vector3(1f, 1f, 1f);
                    }
                }
                UnityEngine.Object.DestroyImmediate(gameObject.GetComponent<Animator>());
                DoesCloneExist = true;
            }
        }
        public static bool OpRaiseEvent(IntPtr instance, byte operationCode, IntPtr operationParameters, IntPtr raiseEventOptions, SendOptions sendOptions, IntPtr method)
        {
            byte[] array = null;
            if (operationParameters != IntPtr.Zero)
            {
                array = new IL2Array<byte>(operationParameters).GetAsByteArray();
            }
            $"Event Code: {operationCode} by len: {(array?.Length ?? -1)} |".RedPrefix("Logger");

            IntPtr unmanagedPointer = IntPtr.Zero;
            if (Status.isSerilize)
            {
                if (operationCode == 12)
                {
                    GenClone();
                    return true;

                }
            }
            else
            {
                if (Status.isSerilize == false && gameObject != null)
                {
                    GameObject.DestroyImmediate(gameObject);
                    DoesCloneExist = false;
                }
            }
            /*
            if (Mod_Console.crashToggle)
            {
                if (operationCode == 6)
                {
                    IL2Array<byte> array = new IL2Array<byte>(operationParameters);
                    int len = array.Length;
                    int ifCount = 0;
                    short sh = 0;
                    for (int i = len - 1; i <= 0; i--)
                    {
                        if (array[i] == 4)
                        {
                            if (i + 5 < len)
                            {
                                // 80, 108, 97, 121
                                if (
                                    array[i + 2] == 80
                                && array[i + 3] == 108
                                && array[i + 4] == 97
                                && array[i + 5] == 121
                                )
                                {
                                    byte[] bytes = new byte[2];
                                    sh = 80;
                                    bytes = BitConverter.GetBytes(sh);

                                    array[i] = bytes[0];
                                    array[i + 1] = bytes[1];
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            */
            try
            {
                return __OpRaiseEvent(instance, operationCode, operationParameters, raiseEventOptions, sendOptions, method);
            }
            catch(Exception ex) {
                Console.WriteLine(ex);
                return false;
            }
        }

        public static IL2Patch patch;

        public static _OpRaiseEvent __OpRaiseEvent;
    }
}
