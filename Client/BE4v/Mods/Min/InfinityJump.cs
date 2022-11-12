using System;
using UnityEngine;
using VRC.Animation;
using BE4v.Mods.Core;

namespace BE4v.Mods.Min
{
    public class InfinityJump : IUpdate
    {
        private static float fPressedLast = 0f;
        public void Update()
        {
            try
            {
                if (!Status.isInfinityJump && !Status.isBHop && !Status.isJumpEffects) return;
                VRC.Player player = VRC.Player.Instance;
                if (player == null) return;
                var jump = player.GetComponent<GamelikeInputController>()?.inJump;
                if (jump != null)
                {
                    if (jump.button)
                    {
                        CharacterController controller = player.GetComponent<CharacterController>();
                        if (controller == null) return;
                        float fPressed = jump.timePressed;
                        if (!controller.isGrounded)
                        {
                            if (fPressed == fPressedLast && Status.isInfinityJump)
                            {
                                OnJump(player);
                            }
                            /*if (Status.isJumpEffects)
                            {
                                if (fPressed != fPressedLast)
                                {
                                    AdvancedEffects.CreateCylinderEffect(VRC.Player.Instance.transform.position, 5f);
                                }
                            }*/
                        }
                        else
                        {
                            if (fPressed == fPressedLast && Status.isBHop)
                            {
                                OnJump(player);
                            }
                        }
                        fPressedLast = fPressed;
                    }
                }
            }
            catch (Exception ex) { ("IJ::OnJump - Reason: " + ex.ToString()).RedPrefix("Exception"); }
        }

        public static void OnJump(VRC.Player player)
        {
            VRCMotionState motionState = player.GetComponent<VRCMotionState>();
            if (motionState == null) return;
            Vector3 vector = motionState.PlayerVelocity;
            vector.y = motionState.jumpPower;
            motionState.PlayerVelocity = vector;
        }
    }
}
