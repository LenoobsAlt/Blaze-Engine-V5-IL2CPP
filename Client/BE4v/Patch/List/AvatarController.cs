using System;
using System.Collections.Generic;
using System.Threading;
using IL2CPP_Core.Objects;
using BE4v.SDK;
using BE4v.Patch.Core;
using BE4v.Mods.API;
using VRC.Core;
using VRC.UI;
using UnityEngine;
using UnityEngine.UI;

namespace BE4v.Patch.List
{
    public class AvatarController : IPatch
    {
        public delegate void _OnEnable(IntPtr instance);
        public delegate void _Update(IntPtr instance);
        public delegate void _OnDisable(IntPtr instance);

        public void Start()
        {
            // -------------- PageAvatar::OnEnable --------------
            IL2Method method = PageAvatar.Instance_Class.GetMethod("OnEnable");
            if (method != null)
            {
                IL2Patch patch = new IL2Patch(method, (_OnEnable)OnEnable);
                __OnEnable = patch.CreateDelegate<_OnEnable>();
            }
            else
                throw new NullReferenceException("PageAvatar::OnEnable");

            // -------------- PageAvatar::Update --------------
            method = PageAvatar.Instance_Class.GetMethod("Update");
            if (method != null)
            {
                IL2Patch patch = new IL2Patch(method, (_Update)Update);
                __Update = patch.CreateDelegate<_Update>();
            }
            else
                throw new NullReferenceException("PageAvatar::Update");

            // -------------- PageAvatar::OnDisable --------------
            method = PageAvatar.Instance_Class.GetMethod("OnDisable");
            if (method != null)
            {
                IL2Patch patch = new IL2Patch(method, (_OnDisable)OnDisable);
                __OnDisable = patch.CreateDelegate<_OnDisable>();
            }
            else
                throw new NullReferenceException("PageAvatar::OnDisable");
        }

        private static void OnEnable(IntPtr instance)
        {
            if (instance == IntPtr.Zero) return;
            __OnEnable(instance);
            if (License.IsLicense == true)
            {
                UnlimitedAvatars.OnEnable(instance);
                SearchAvatars.OnEnable(instance);
            }
        }

        private static void OnDisable(IntPtr instance)
        {
            if (instance == IntPtr.Zero) return;
            if (License.IsLicense == true)
            {
                SearchAvatars.OnDisable(instance);
            }
            __OnDisable(instance);
        }

        private static void Update(IntPtr instance)
        {
            if (instance == IntPtr.Zero) return;
            if (License.IsLicense == true)
            {
                UnlimitedAvatars.Update();
                SearchAvatars.Update();
            }
            __Update(instance);
        }

        public static void UpdateAvatarList(UiAvatarList list, List<string> avatarList = null)
        {
            if (list == null)
                return;

            if (avatarList == null)
                avatarList = Avatars.AvatarId;

            list.specificListValues.Clear();
            list.ClearList();
            list.specificListIds = avatarList.ToArray();
            list.expandedHeight = 850f;
            list.extendRows = 4;
            list.Refresh();
        }

        public static _OnEnable __OnEnable;
        public static _Update __Update;
        public static _OnDisable __OnDisable;

        private static Transform searchButton;
        private static Transform searchButtonOriginal;

        public static class SearchAvatars
        {
            public static void OnEnable(IntPtr instance)
            {
                if (favList != null)
                {
                    favList.gameObject.SetActive(false);
                    UnityEngine.Object.Destroy(favList.gameObject, 300f);
                    favList = null;
                }
                if (searchButton != null)
                {
                    searchButton.gameObject.SetActive(true);
                    searchButton.GetComponentInChildren<Button>(true).interactable = true;
                }
                if (searchButtonOriginal != null)
                {
                    searchButtonOriginal.gameObject.SetActive(false);
                }
            }

            public static void Update()
            {
                if (isSearch == false)
                {
                    if (iCount == 20)
                    {
                        if (favList != null)
                        {
                            favList.gameObject.SetActive(false);
                            UnityEngine.Object.Destroy(favList.gameObject, 300f);
                            favList = null;
                        }
                        favList = Utils.Avatars.AddNewList("Search avatar", 0, false);
                    }

                    if (--iCount < 1)
                    {
                        isSearch = null;
                        UpdateAvatarList(favList, Avatars.AvatarSearch);
                    }
                }
            }

            public static void OnDisable(IntPtr instance)
            {
                if (favList != null)
                {
                    favList.gameObject.SetActive(false);
                    UnityEngine.Object.Destroy(favList.gameObject, 300f);
                    favList = null;
                }
                if (searchButton != null)
                {
                    searchButton.gameObject.SetActive(false);
                }
                if (searchButtonOriginal != null)
                {
                    searchButtonOriginal.gameObject.SetActive(true);
                }
                isSearch = null;
            }

            public static void ShowDialog()
            {
                VRCUiPopupManager.Instance.ShowUnityInputPopupWithCancel("Search avatar", "", UnityEngine.UI.InputField.InputType.Standard, false, "Search avatar", OnSubmitDelegate, null, "Enter avatar name");
            }

            unsafe public static void OnSubmit(IntPtr a, IntPtr b, IntPtr c)
            {
                string avatarName = new IL2String(a).ToString();
                if (string.IsNullOrEmpty(avatarName))
                {
                    "Avatar name is null or empty".RedPrefix("Search Avatar");
                    return;
                }
                isSearch = true;
                new Thread(() =>
                {
                    Avatars.SearchAvatar(avatarName);
                    iCount = 20;
                    isSearch = false;
                }).Start();
            }

            private static IL2Delegate field_OnSubmit = null;
            public static IL2Delegate OnSubmitDelegate
            {
                get
                {
                    if (field_OnSubmit == null)
                    {
                        field_OnSubmit = IL2Delegate.CreateDelegate((Action<IntPtr, IntPtr, IntPtr>)OnSubmit, IL2Action<IntPtr, IntPtr, IntPtr>.Instance_Class);
                        field_OnSubmit.Static = true;
                    }
                    return field_OnSubmit;
                }
            }

            internal static UiAvatarList favList = null;

            public static bool? isSearch = null;
            public static int iCount = 0;
        }

        public static class UnlimitedAvatars
        {
            public static void OnEnable(IntPtr instance)
            {
                if (favList != null)
                    return;

                pageAvatar = new PageAvatar(instance);
                Transform changeButton = pageAvatar.transform.Find("Change Button");
                if (changeButton == null)
                {
                    "Fav not found #0".RedPrefix("[Error]");
                    return;
                }
                favButton = UnityEngine.Object.Instantiate(changeButton, changeButton.parent);
                if (favButton == null)
                {
                    "Fav not found #1".RedPrefix("[Error]");
                    return;
                }
                favButton.name = "ToggleFavorite";
                favButton.gameObject.SetActive(false);
                favButton.GetComponent<Button>().interactable = false;
                favButton.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
                favButton.GetComponent<Button>().onClick.AddListener(onClickFavButton);

                avatarModel = pageAvatar.transform.Find("AvatarPreviewBase");
                if (avatarModel == null)
                {
                    "Fav not found #2".RedPrefix("[Error]");
                    return;
                }
                baseAvatarModelPosition = avatarModel.localPosition;
                baseButtonFavPosition = changeButton.localPosition;
                favList = Utils.Avatars.AddNewList("Favorite (BlazeEngine)", 0);

                favButton.GetComponent<Button>().interactable = true;

                favButton.gameObject.SetActive(true);
                favButton.localPosition = baseButtonFavPosition + new Vector3(0, 80, 0);
                avatarModel.localPosition = baseAvatarModelPosition + new Vector3(0, 60, 0);
                avatarModel.localScale *= 0.8f;

                UpdateAvatarList(favList);

                searchButtonOriginal = GameObject.Find("UserInterface/MenuContent/Backdrop/Header/Tabs/ViewPort/Content/Search/")?.transform;
                if (searchButtonOriginal != null)
                {
                    searchButton = UnityEngine.Object.Instantiate(searchButtonOriginal, searchButtonOriginal.parent);
                    if (searchButton != null)
                    {
                        searchButton.name = "Search Be4v";
                        searchButton.GetComponentInChildren<Button>(true).interactable = true;
                        searchButton.GetComponentInChildren<Button>(true).onClick = new Button.ButtonClickedEvent();
                        searchButton.GetComponentInChildren<Button>(true).onClick.AddListener(SearchAvatars.ShowDialog);
                    }
                    else
                    {
                        "Search not found #1".RedPrefix("[Error]");
                    }
                }
                else
                {
                    "Search not found #0".RedPrefix("[Error]");
                }
            }

            public static void Update()
            {
                ApiAvatar apiAvatar = pageAvatar?.avatar?.apiAvatar;
                if (apiAvatar != null)
                {
                    if (Input.GetKey(KeyCode.LeftControl))
                    {
                        favButton.GetComponentInChildren<Text>().text = "<color=red>Download .vrca</color>";
                        return;
                    }

                    if (Avatars.AvatarId.Contains(apiAvatar.id))
                    {
                        if (!apiAvatar.releaseStatus.Equals("public") && apiAvatar.authorId != APIUser.CurrentUser.id)
                            favButton.GetComponentInChildren<Text>().text = "<color=red>Unfavorite</color>";
                        else
                            favButton.GetComponentInChildren<Text>().text = "Unfavorite";
                        return;
                    }

                    if (apiAvatar.authorId == APIUser.CurrentUser.id)
                    {
                        if (apiAvatar.releaseStatus.Equals("public"))
                            favButton.GetComponentInChildren<Text>().text = "Make Private";
                        else
                            favButton.GetComponentInChildren<Text>().text = "Make Public";
                        return;
                    }

                    favButton.GetComponentInChildren<Text>().text = "Favorite";
                }
            }

            public static void onClickFavButton()
            {
                ApiAvatar apiAvatar = pageAvatar?.avatar?.apiAvatar;
                if (apiAvatar != null)
                {
                    if (Input.GetKey(KeyCode.LeftControl))
                    {
                        string url = apiAvatar.assetUrl;
                        if (Utils.Avatars.IsValidUrl(url))
                        {
                            url = url.Replace("https://api.vrchat.cloud/", "https://vrchat.com/");
                            Utils.Avatars.OpenUrlBrowser(url);
                        }
                        return;
                    }

                    if (Avatars.AvatarId.Contains(apiAvatar.id))
                    {
                        RemoveFavorite(apiAvatar.id);
                        return;
                    }

                    if (apiAvatar.authorId == APIUser.CurrentUser.id)
                    {
                        if (apiAvatar.releaseStatus.Equals("public"))
                            apiAvatar.releaseStatus = "private";
                        else
                            apiAvatar.releaseStatus = "public";
                        apiAvatar.SaveReleaseStatus();
                        return;
                    }

                    AddFavorite(apiAvatar.id);
                }
            }

            public static void AddFavorite(string avatarId)
            {
                if (Avatars.AvatarId.Contains(avatarId))
                    return;

                Avatars.AvatarId.Insert(0, avatarId);
                UpdateAvatarList(favList);
                new Thread(() => { Avatars.Add(avatarId); }).Start();
            }

            public static void RemoveFavorite(string avatarId)
            {
                if (!Avatars.AvatarId.Contains(avatarId))
                    return;

                Avatars.AvatarId.Remove(avatarId);
                UpdateAvatarList(favList);
                new Thread(() => { Avatars.Remove(avatarId); }).Start();
            }

            internal static PageAvatar pageAvatar;
            internal static UiAvatarList favList;

            private static Transform avatarModel;
            private static Transform favButton;

            private static Vector3 baseAvatarModelPosition;
            private static Vector3 baseButtonFavPosition;
        }
    }
}
