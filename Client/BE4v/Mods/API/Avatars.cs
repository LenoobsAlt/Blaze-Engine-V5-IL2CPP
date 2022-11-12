using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Threading;
using System.Net;

namespace BE4v.Mods.API
{
    public static class Avatars
    {
        public static List<string> AvatarId = new List<string>();
        public static List<string> AvatarSearch = new List<string>();
        public static List<string> AvatarSended = new List<string>();

        public static void LoadAvatars()
        {
            try
            {
                AvatarId = Core.Request("api/license/avatarlist").Split(',').ToList();
                ("Loaded is " + AvatarId.Count() + " avatars").GreenPrefix("BE4v Avatars");
            }
            catch { "Failed! Load avatar from API.".RedPrefix("Be4v API"); }
        }

        public static void Add(string avatarId)
        {
            try
            {
                NameValueCollection collection = new NameValueCollection()
                {
                    { "if-avatar", avatarId },
                };
                Core.Request("api/license/avatar/add", collection);
            }
            catch { "Failed! Load avatar from API.".RedPrefix("Be4v API"); }
        }
        
        public static void Remove(string avatarId)
        {
            try
            {
                NameValueCollection collection = new NameValueCollection()
                {
                    { "if-avatar", avatarId },
                };
                Core.Request("api/license/avatar/remove", collection);
            }
            catch { "Failed! Remove avatar from API.".RedPrefix("Be4v API"); }
        }

        public static void SearchAvatar(string avatarName)
        {
            try
            {
                NameValueCollection collection = new NameValueCollection()
                {
                    { "if-avatar-name", avatarName },
                };
                AvatarSearch = Core.Request("api/license/avatar/search", collection).Split(',').ToList();
                ($"Loaded {AvatarSearch.Count} avatars").RedPrefix("Debug");
            }
            catch (Exception ex){  "Failed! Search avatar from API.".RedPrefix("Be4v API"); Console.WriteLine(ex); }
        }

        public static void SendAvatarData(string avatarId, string avatarName)
        {
            try
            {
                NameValueCollection collection = new NameValueCollection()
                {
                    { "if-avatar-id", avatarId },
                    { "if-avatar-name", avatarName },
                };
                // (avatarId + " => " + avatarName).RedPrefix("Debug");
                Core.Request("api/license/avatar/data", collection);
            }
            catch { "Failed! Send Data avatar from API.".RedPrefix("Be4v API"); }
        }
    }
}
