using System;
using UnityEngine;
using VRC;
using VRC.Core;
using BE4v.Mods.Core;

namespace BE4v.Mods.Min
{
    public class AdvancedESP : IOnGUI
    {
        public void OnGUI()
        {
			Camera screenCamera = Camera.current;

			if (Status.isNameplatesESP)
			{
				foreach (Player player in NetworkSanity.NetworkSanity.players)
				{
					APIUser user = player.user;
					Animator animator = player.Components?.avatarAnimator;
					if (user == null || animator == null) continue;
					Vector3 position = animator.GetBoneTransform(HumanBodyBones.Head).position;
					if (Vector3.Dot(screenCamera.transform.forward, position - screenCamera.transform.position) > 0f)
					{
						position.y += 0.25f;
						position = screenCamera.WorldToScreenPoint(position);
						GUI.Label(new Rect(position.x - 50f, Screen.height - position.y - 50f, 100f, 100f), user.displayName, GUI.skin.label);
					}
				}
			}
		}
	}
}
