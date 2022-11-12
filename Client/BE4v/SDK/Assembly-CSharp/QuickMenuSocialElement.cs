using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;
using Transmtn.DTO.Notifications;

public class QuickMenuSocialElement : MonoBehaviour
{
	public QuickMenuSocialElement(IntPtr ptr) : base(ptr) { }

	public enum IconType
	{
		None = -1,
		GenericNotification,
		Blocked,
		Muted,
		VoteToKick,
		Friend,
		FriendRequest,
		Invite,
		InviteWithPhoto,
		InviteResponse,
		InviteResponseWithPhoto,
		RequestInvite,
		RequestInviteWithPhoto,
		RequestInviteResponse,
		RequestInviteResponseWithPhoto
	}

	public enum ElementType
	{
		Empty,
		Notification,
		User
	}

	public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().First(x => x.BaseType == MonoBehaviour.Instance_Class && x.GetField(Notification.Instance_Class) != null);
}
