using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRC;
using VRC.Core;
using VRC.UI;
using UnityEngine;
using UnityEngine.UI;

namespace BE4v.Utils
{
    public static class Avatars
    {

        public static bool IsValidUrl(string url) => !string.IsNullOrEmpty(url) && url.Length < 90 && url.StartsWith("https://api.vrchat.cloud/api/1/file/file_") && url.EndsWith("/file");
        public static bool IsValidId(string AvatarId) => !string.IsNullOrEmpty(AvatarId) && AvatarId.Length == 41 && AvatarId.StartsWith("avtr_") && AvatarId[13] == '-' && AvatarId[18] == '-' && AvatarId[23] == '-' && AvatarId[28] == '-';
        public static void OpenUrlBrowser(string url) => System.Diagnostics.Process.Start(url);

        public static void ChangeAvatarById(string AvatarId)
        {
            /*
             * FULL Code
            string text = "avatars/" + AvatarId;
            ApiModelContainer<ApiAvatar> apiModelContainer = new ApiModelContainer<ApiAvatar>();
            apiModelContainer.OnSuccess = delegate (ApiContainer c)
            {
                new PageAvatar
                {
                    avatar = new SimpleAvatarPedestal
                    {
                        apiAvatar = new ApiAvatar
                        {
                            id = AvatarId
                        }
                    }
                }.ChangeToSelectedAvatar();
            };
            apiModelContainer.OnError = delegate (ApiContainer c)
            {
                ConsoleUtils.ConsoleMessage(ConsoleColor.Red, "Avatar", "Error when set avatar: " + c.Error);
            };
            API.SendRequest(text, HTTPMethods.Get, apiModelContainer, null, true, true, 3600f, 2, null);
            *
            */
            PageAvatar pageAvatar = GameObject.Find("Screens").transform.Find("Avatar").GetComponent<PageAvatar>();
            pageAvatar.avatar.apiAvatar = new ApiAvatar
            {
                id = AvatarId
            };
            pageAvatar.ChangeToSelectedAvatar();

        }
        public static void ChangeAvatar(ApiAvatar avatar)
        {
            PageAvatar pageAvatar = GameObject.Find("Screens").transform.Find("Avatar").GetComponent<PageAvatar>();
            pageAvatar.avatar.apiAvatar = avatar;
            pageAvatar.ChangeToSelectedAvatar();
        }

        public static UiAvatarList AddNewList(string title, int index, bool changeTitle = true)
        {
            UiAvatarList[] uiAvatarLists = UnityEngine.Object.FindObjectsOfType<UiAvatarList>();
            
            if (uiAvatarLists.Length == 0)
            {
                "uiAvatarLists == 0!".RedPrefix("[Error]");
                return null;
            }

            UiAvatarList gameFavList = null;
            foreach (UiAvatarList list in uiAvatarLists)
            {
                // list.name.RedPrefix("Debug");
                if (list.name.Contains("Personal"))
                {
                    gameFavList = list;
                    break;
                }
            }

            if (gameFavList == null)
            {
                "gameFavList not found!".RedPrefix("[Error]");
                return null;
            }
            UiAvatarList newList = UnityEngine.Object.Instantiate(gameFavList, gameFavList.transform.parent);

            newList.name = title;

            newList.transform.SetSiblingIndex(index);
            newList.category = UiAvatarList.Category.SpecificList;

            if (changeTitle)
                newList.GetComponentInChildren<Button>(true).GetComponentInChildren<Text>().text = title;

            newList.gameObject.SetActive(true);

            return newList;
        }
    }
}
