using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class EAC_TypeD
{
	public static IL2Class Instance_Class = IL2CPP.AssemblyList["Epic.OnlineServices"].GetClasses().FirstOrDefault(x => x.GetField(y => y.Name == "AntiCheat") != null);
}
public enum EAC_Type
{
	Core,
	Auth,
	Friends,
	Presence,
	UserInfo,
	HttpSerialization,
	Ecom,
	P2P,
	Sessions,
	RateLimiter,
	PlayerDataStorage,
	Analytics,
	Messaging,
	Connect,
	Overlay,
	Achievements,
	Stats,
	Ui,
	Lobby,
	Leaderboards,
	Keychain,
	IdentityProvider,
	TitleStorage,
	Mods,
	AntiCheat,
	Reports,
	Sanctions,
	ProgressionSnapshots,
	Kws,
	Rtc,
	RTCAdmin,
	Inventory,
	ReceiptValidator,
	CustomInvites,
	AllCategories = 2147483647
}
