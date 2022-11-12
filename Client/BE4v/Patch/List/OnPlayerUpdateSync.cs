using System;
using System.Collections.Generic;
using IL2CPP_Core.Objects;
using UnityEngine;
using VRC.Core;
using BE4v.Mods;
using BE4v.Patch.Core;
using BE4v.Utils;
using VRC.SDKBase;
using VRC.SDK3.Components;

namespace BE4v.Patch.List
{
    public class OnPlayerUpdateSync : IPatch
    {
        public delegate void _VRC_Player_Update(IntPtr instance);
        public void Start()
        {
            IL2Method method = VRC.Player.Instance_Class.GetMethod("Update");
            if (method == null)
                throw new NullReferenceException();

            VRC_PlayerUpdate = PatchUtils.FastPatch<_VRC_Player_Update>(method, VRC_Player_Update);
        }

        public static void VRC_Player_Update(IntPtr instance)
        {
            if (instance == IntPtr.Zero) return;
            VRC_PlayerUpdate(instance);
            VRC.Player PlayerInstance = VRC.Player.Instance;
            if (PlayerInstance == null) return;
            if (PickupOrbit_VRC_Player_Pointer != IntPtr.Zero)
            {
                if (PickupOrbit_VRC_Player_Pointer == instance)
                {
                    VRCPickup[] pickups = UnityEngine.Object.FindObjectsOfType<VRCPickup>();

                    float degrees = 360 / pickups.Length;

                    for (int i = 0; i < pickups.Length; i++)
                    {
                        VRC_Pickup pickup = pickups[i];

                        VRCPlayerApi localPlayerApi = Networking.LocalPlayer;
                        if (Networking.GetOwner(pickup.gameObject) != localPlayerApi)
                            Networking.SetOwner(localPlayerApi, pickup.gameObject);

                        pickup.transform.position = new VRC.Player(instance).gameObject.transform.position + new Vector3(Mathf.Sin(Time.time * PickupOrbit.speed + degrees * i) * PickupOrbit.distance, PickupOrbit.height, Mathf.Cos(Time.time * PickupOrbit.speed + degrees * i) * PickupOrbit.distance);
                    }
                }
            }
            if (Mods.Min.SitOnHead.VRC_Player_Pointer != IntPtr.Zero)
            {
                if (Mods.Min.SitOnHead.VRC_Player_Pointer == instance)
                {
                    PlayerInstance.GetComponent<Collider>().enabled = false;
                    if (Status.SitOnType == 0)
                    {
                        PlayerInstance.transform.position = new VRC.Player(instance).Components.avatarAnimator.GetBoneTransform(HumanBodyBones.Head).position;
                    }
                    else if (Status.SitOnType == 1)
                    {
                        PlayerInstance.transform.position = new VRC.Player(instance).Components.avatarAnimator.GetBoneTransform(HumanBodyBones.LeftHand).position;
                    }
                    else
                    {
                        PlayerInstance.transform.position = new VRC.Player(instance).Components.avatarAnimator.GetBoneTransform(HumanBodyBones.RightHand).position;
                    }
                }
            }
            if (Status.isLineRenderESP)
            {
                if (instance != PlayerInstance.Pointer)
                {
                    VRC.Player player = new VRC.Player(instance);
                    LineRenderer lineRenderer = player.gameObject.GetComponent<LineRenderer>();
                    if (lineRenderer == null)
                    {
                        lineRenderer = player.gameObject.GetOrAddComponent<LineRenderer>();

                        lineRenderer.startWidth = 0.01f;
                        lineRenderer.endWidth = 0.01f;
                        // lineRenderer.startColor = Color.red;
                        // lineRenderer.endColor = Color.red;
                        lineRenderer.SetPositions(new Vector3[] { Vector3.zero, Vector3.zero });
                        lineRenderer.useWorldSpace = true;
                    }
                    if (lineRenderer != null)
                    {
                        Vector3[] vectors = new Vector3[2] {
                            PlayerInstance.transform.position,
                            player.transform.position
                        };
                        vectors[0].y += 0.25f;
                        vectors[1].y += 0.25f;
                        lineRenderer.SetPositions(vectors);
                    }
                }
            }
        }

        public static class PickupOrbit
        {
            public static float speed = 1f;

            public static float distance = 1f;

            public static float height = 1f;
        }

        public static IntPtr PickupOrbit_VRC_Player_Pointer = IntPtr.Zero;

        public static _VRC_Player_Update VRC_PlayerUpdate;
    }
}
