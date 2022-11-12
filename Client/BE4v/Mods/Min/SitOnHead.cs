using System;
using UnityEngine;
using VRC;
using BE4v.Mods.Core;
using VRC.SDK3.Dynamics.Contact.Components;
using CustomQuickMenu.Menus;

namespace BE4v.Mods.Min
{
    public static class SitOnHead
    {
        public enum SitOnType : int
        {
            Head = 0,
            LeftHand,
            RightHand
        }

        public static Player SelectUser
        {
            get
            {
                if (VRC_Player_Pointer == IntPtr.Zero)
                    return null;

                return new Player(VRC_Player_Pointer);
            }
            set
            {
                if (Player.Instance == null) return;
                if (Player.Instance == value) return;
                if (value == null)
                {
                    Collider collider = VRCPlayer.Instance.GetComponent<Collider>();
                    if (collider != null)
                        collider.enabled = true;
                    if (SelectedMenu.SitOnHeadToggle.button != null)
                        SelectedMenu.SitOnHeadToggle.button._Text = "Sit on";
                    VRC_Player_Pointer = IntPtr.Zero;
                }
                else
                {
                    if (SelectedMenu.SitOnHeadToggle.button != null)
                        SelectedMenu.SitOnHeadToggle.button._Text = "Get up";
                    VRC_Player_Pointer = value.Pointer;
                }
            }
        }

        public static IntPtr VRC_Player_Pointer = IntPtr.Zero;
    }
}
