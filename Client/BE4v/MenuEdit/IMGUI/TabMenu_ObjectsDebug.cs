using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BE4v.Utils;
using BE4v.Mods;
using BE4v.Mods.Core;
using BE4v.Mods.Min;

namespace BE4v.MenuEdit.IMGUI
{
    public class TabMenu_ObjectsDebug : IUpdate, IOnGUI
    {
        public static bool isPressed = false;

        public static Transform[] transforms = new Transform[0];

        public void Update()
        {
            if (Status.devMenuStatus != 1) return;
            isPressed = Input.GetKey(KeyCode.Tab);
            if (isPressed)
            {
                if (InstanceID == 0)
                    if (transforms == null || transforms.Length == 0)
                        transforms = UnityEngine.Object.FindObjectsOfType<Transform>().Where(x => x.parent == null).ToArray();
            }
            else
            {
                if (InstanceID == 0)
                    if (transforms == null || transforms.Length > 0)
                        transforms = new Transform[0];
            }
        }

        int screenHeight = 0;
        int screenWidth = 0;
        public bool OnSize()
        {
            screenHeight = Screen.height;
            screenWidth = Screen.width;

            if (screenHeight < 1 || screenHeight < 1) return false;
            // rectText = new Rect(screenWidth - 370, screenHeight - 230, 350, 200);

            return true;
        }

        public void OnGUI()
        {
            if (Status.devMenuStatus != 1) return;
            NotifySystem.Notify.OnGUI();
            if (!isPressed) return;
            if (!OnSize())
            {
                return;
            }
            GUI.backgroundColor = new Color(255, 0, 0);

            int SizeX1 = screenWidth - (iLeftMargin * 2);

            rectStatus = new Rect(120, iTopMargin, 40, 20);
            rectName = new Rect(iLeftMargin, iTopMargin, SizeX1, 20);

            GUI.Label(new Rect(120, iTopMargin, 100, 20), "<b>Status</b>");
            GUI.Label(new Rect(160, iTopMargin, SizeX1, 20), "<b>Object Name</b>");
            try
            {
                if (InstanceID == 0)
                {
                    CreateRootList();
                }
                else
                {
                    rectName.y = (rectStatus.y += 20);
                    if (GUI.Button(rectStatus, "") || GUI.Button(rectName, new IL2String_utf16("../")))
                    {
                        Transform transform = UnityEngine.Object.FindObjectFromInstanceID(InstanceID)?.GetValue<Transform>();
                        if (transform == null || transform.parent == null)
                        {
                            InstanceID = 0;
                        }
                        else
                        {
                            InstanceID = transform.parent.GetInstanceID();
                        }
                        return;
                    }
                    CreateSelectList();
                }
            }
            catch (Exception ex)
            {
                ex.ToString().RedPrefix("Exception");
            }
        }
        
        public static void CreateRootList()
        {
            foreach (Transform xform in transforms)
            {
                AddItemMenu(xform);
            }
        }
        
        public static void CreateSelectList()
        {
            Transform transform = UnityEngine.Object.FindObjectFromInstanceID(InstanceID)?.GetValue<Transform>();
            if (transform != null)
            {
                foreach (Transform t in transform)
                {
                    AddItemMenu(t);
                }
            }
        }

        public static void AddItemMenu(Transform transform)
        {
            rectName.y = (rectStatus.y += 20);

            if (GUI.Button(rectStatus, transform.gameObject.active.ToString()))
            {
                transform.gameObject.active = !transform.gameObject.active;
            }
            if (GUI.Button(rectName, transform.gameObject.name))
            {
                InstanceID = transform.GetInstanceID();
            }
        }

        private static int InstanceID = 0;

        private static Rect rectStatus;

        private static Rect rectName;

        private static readonly int iTopMargin = 160;

        private static readonly int iLeftMargin = 160;
    }
}
