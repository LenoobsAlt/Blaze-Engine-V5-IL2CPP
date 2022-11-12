using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC.SDKBase;
using VRCSDK2;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

namespace BE4v.Utils
{
    public static class xGameUtils
    {
        public static class Murder
		{
			public static bool IsGameWorld
			{
                get
                {
					bool result = false;
                    try
                    {
						result = RoomManager.currentRoom?.id.Contains("wrld_858dfdfc-1b48-4e1e-8a43-f0edc611e5fe") == true;
					}
                    catch { }
					return result;
				}
			}
			/*
			public static void bringRevolver()
			{
				if (IsGameWorld)
				{
					List<GameObject> list = new List<GameObject>();
					GameObject[] array = Resources.FindObjectsOfTypeAll<GameObject>();
					foreach (GameObject gameObject in array)
					{
						if (gameObject.name.Contains("Revolver"))
						{
							list.Add(gameObject);
						}
					}
					foreach (GameObject gameObject2 in list)
					{
						bool flag3 = gameObject2.GetComponent<VRCPickup>();
						if (flag3)
						{
							Networking.SetOwner(VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0, gameObject2);
							gameObject2.transform.position = VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position + new Vector3(0f, 0.1f, 0f);
						}
					}
				}
			}

			public static void bringKnife()
			{
				if (IsGameWorld)
				{
					List<GameObject> list = new List<GameObject>();
					GameObject[] array = Resources.FindObjectsOfTypeAll<GameObject>();
					foreach (GameObject gameObject in array)
					{
						bool flag2 = gameObject.name.Contains("Knife");
						if (flag2)
						{
							list.Add(gameObject);
						}
					}
					foreach (GameObject gameObject2 in list)
					{
						if (gameObject2.GetComponent<VRCPickup>())
						{
							Networking.SetOwner(VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0, gameObject2);
							gameObject2.transform.position = VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position + new Vector3(0f, 0.1f, 0f);
						}
					}
				}
			}

			public static void bringLuger()
			{
				if (IsGameWorld)
				{
					List<GameObject> list = new List<GameObject>();
					GameObject[] array = Resources.FindObjectsOfTypeAll<GameObject>();
					foreach (GameObject gameObject in array)
					{
						bool flag2 = gameObject.name.Contains("Luger");
						if (flag2)
						{
							list.Add(gameObject);
						}
					}
					foreach (GameObject gameObject2 in list)
					{
						bool flag3 = gameObject2.GetComponent<VRCPickup>();
						if (flag3)
						{
							Networking.SetOwner(VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0, gameObject2);
							gameObject2.transform.position = VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position + new Vector3(0f, 0.1f, 0f);
						}
					}
				}
			}

			public static void bringFrag()
			{
				if (IsGameWorld)
				{
					List<GameObject> list = new List<GameObject>();
					GameObject[] array = Resources.FindObjectsOfTypeAll<GameObject>();
					foreach (GameObject gameObject in array)
					{
						bool flag2 = gameObject.name.Contains("Frag");
						if (flag2)
						{
							list.Add(gameObject);
						}
					}
					foreach (GameObject gameObject2 in list)
					{
						bool flag3 = gameObject2.GetComponent<VRCPickup>();
						if (flag3)
						{
							Networking.SetOwner(VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0, gameObject2);
							gameObject2.transform.position = VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position + new Vector3(0f, 0.1f, 0f);
						}
					}
				}
			}

			public static void bringShotgun()
			{
				if (IsGameWorld)
				{
					List<GameObject> list = new List<GameObject>();
					GameObject[] array = Resources.FindObjectsOfTypeAll<GameObject>();
					foreach (GameObject gameObject in array)
					{
						bool flag2 = gameObject.name.Contains("Shotgun");
						if (flag2)
						{
							list.Add(gameObject);
						}
					}
					foreach (GameObject gameObject2 in list)
					{
						bool flag3 = gameObject2.GetComponent<VRCPickup>();
						if (flag3)
						{
							Networking.SetOwner(VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0, gameObject2);
							gameObject2.transform.position = VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position + new Vector3(0f, 0.1f, 0f);
						}
					}
				}
			}
			*/
			public static void KillAll()
			{
				if (IsGameWorld)
				{
					GameObject[] array = Resources.FindObjectsOfTypeAll<GameObject>();
					foreach (GameObject gameObject in array)
					{
						if (gameObject.name.Contains("Game Logic"))
						{
							gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "KillLocalPlayer");
							break;
						}
					}
				}
			}

			public static void BlindAll()
			{
				if (IsGameWorld)
				{
					GameObject[] array = Resources.FindObjectsOfTypeAll<GameObject>();
					foreach (GameObject gameObject in array)
					{
						if (gameObject.name.Contains("Game Logic"))
						{
							gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "OnLocalPlayerBlinded");
							break;
						}
					}
				}
			}

			public static void Start()
			{
				if (IsGameWorld)
				{
					GameObject[] array = Resources.FindObjectsOfTypeAll<GameObject>();
					foreach (GameObject gameObject in array)
					{
						if (gameObject.name.Contains("Game Logic"))
						{
							gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "Btn_Start");
							break;
						}
					}
				}
			}

			public static void Abort()
			{
				if (IsGameWorld)
				{
					GameObject[] array = Resources.FindObjectsOfTypeAll<GameObject>();
					foreach (GameObject gameObject in array)
					{
						if (gameObject.name.Contains("Game Logic"))
						{
							gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "SyncAbort");
							break;
						}
					}
				}
			}

			public static void MurderWin()
			{
				if (IsGameWorld)
				{
					GameObject[] array = Resources.FindObjectsOfTypeAll<GameObject>();
					foreach (GameObject gameObject in array)
					{
						if (gameObject.name.Contains("Game Logic"))
						{
							gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "SyncVictoryM");
							break;
						}
					}
				}
			}

			public static void ByStandWin()
			{
				if (IsGameWorld)
				{
					GameObject[] array = Resources.FindObjectsOfTypeAll<GameObject>();
					foreach (GameObject gameObject in array)
					{
						if (gameObject.name.Contains("Game Logic"))
						{
							gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "SyncVictoryB");
							break;
						}
					}
				}
			}

		}
	}
}
