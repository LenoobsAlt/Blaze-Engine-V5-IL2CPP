using System;
using UnityEngine;
using UnityEngine.XR;
using VRC;
using VRC.Animation;
using BE4v.MenuEdit;
using BE4v.Mods.Core;
using CustomQuickMenu.Menus;

namespace BE4v.Mods.Min
{
    public class FlyHack : IUpdate
    {
        public static void ToggleType()
        {
            Status.isFlyType = !Status.isFlyType;
            BE4VMenu.FlyType.Refresh();
        }
        
        public static void Toggle()
        {
            Status.isFly = !Status.isFly;
            if (!Status.isFly)
            {
                Physics.gravity = Vector3.up * -9.5f;
                Player.Instance.GetComponent<Collider>().enabled = true;
            }
            else
            {
                Physics.gravity = Vector3.zero;
            }
            MainMenu.FlyToggle.Refresh();
        }

        public void Update()
        {
            if (Threads.isCtrl)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Toggle();
                    return;
                }
            }

            if (!Status.isFly) return;
            Player player = Player.Instance;
            if (player == null) return;
            float MultiSpeed = Input.GetKey(KeyCode.LeftShift) ? 2.5F : 1F;
            float calcTimes = MultiSpeed * Time.deltaTime * fNoClipSpeed * (Status.isSpeedHack ? Status.iSpeedHackSpeed : 1f);

            player.GetComponent<Collider>().enabled = false;
            if (Status.isFlyType)
            {
                Transform transform = Camera.main.transform;
                Vector3 moveControl = player.transform.position;
                Vector3 moveControl2 = moveControl;
                // NoClipMode
                if (Input.GetKey(KeyCode.E))
                {
                    moveControl += Vector3.up * calcTimes;
                }
                else if (Input.GetKey(KeyCode.Q))
                {
                    moveControl -= Vector3.up * calcTimes;
                }

                #region Vertical
                float fVertical = Input.GetAxis("Vertical");
                if (Math.Abs(fVertical) > 0f) moveControl += calcTimes * transform.forward * fVertical;
                #endregion
                #region Horizontal
                float fHorizontal = Input.GetAxis("Horizontal");
                if (Math.Abs(fHorizontal) > 0f) moveControl += calcTimes * transform.right * fHorizontal;
                #endregion
                if (moveControl != moveControl2)
                    player.transform.position = moveControl;
            }
            else
            {
                Transform playerTransform = Player.Instance.transform;
                Vector3 moveControl = playerTransform.position;
                Vector3 moveControl2 = moveControl;

                if (XRDevice.isPresent)
                {
                    if (Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") < 0f)
                    {
                        moveControl -= Vector3.up * calcTimes;
                    }
                    if (Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") > 0f)
                    {
                        moveControl += Vector3.up * calcTimes;
                    }
                    if (Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal") < 0f)
                    {
                        moveControl -= playerTransform.right * calcTimes;
                    }
                    if (Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal") > 0f)
                    {
                        moveControl += playerTransform.right * calcTimes;
                    }
                    if (Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical") < 0f)
                    {
                        moveControl -= playerTransform.forward * calcTimes;
                    }
                    if (Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical") > 0f)
                    {
                        moveControl += playerTransform.forward * calcTimes;
                    }
                }

                if (Input.GetKey(KeyCode.Q))
                {
                    moveControl -= Vector3.up * calcTimes;
                }
                if (Input.GetKey(KeyCode.E))
                {
                    moveControl += Vector3.up * calcTimes;
                }
                if (Input.GetKey(KeyCode.W))
                {
                    moveControl += playerTransform.forward * calcTimes;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    moveControl -= playerTransform.forward * calcTimes;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    moveControl -= playerTransform.right * calcTimes;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    moveControl += playerTransform.right * calcTimes;
                }

                if (moveControl != moveControl2)
                    player.transform.position = moveControl;

                /*
                player.GetComponent<Collider>().enabled = true;
                if (Input.GetKey(KeyCode.Q))
                {
                    Physics.gravity = Vector3.down * 9.5f;
                    iCountBalance = 10;
                }
                else if (Input.GetKey(KeyCode.E))
                {
                    Physics.gravity = Vector3.up * 9.5f;
                    iCountBalance = 10;
                }
                else if (iCountBalance >= 0)
                {
                    VRCMotionState motionState = player.GetComponent<VRCMotionState>();
                    if (motionState.PlayerVelocity[1] != 0.0f)
                    {
                        iCountBalance = 10;
                        Physics.gravity = new Vector3(0, -motionState.PlayerVelocity[1] * 2.0f);
                    }
                    else
                    {
                        iCountBalance = -1;
                        Physics.gravity = Vector3.zero;
                    }
                }
                */
            }
        }

        // NoClip Speed [Default: 4.0f]
        public static float fNoClipSpeed = 4.0f;

        public static int iCountBalance = -1;
    }
}
