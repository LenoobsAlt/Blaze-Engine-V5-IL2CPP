using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using BE4v.Mods.Core;
using VRC.DataModel;
using VRC.UI.Core;
using VRC.UI.Elements;
using VRC.UI.Elements.Menus;
using IL2Photon.Pun;
using IL2Photon.Realtime;
using IL2ExitGames.Client.Photon;

namespace BE4v.Mods.Min
{
    public static class ConsoleResource
    {
        public static IEnumerable<string> SplitCommandLine(string commandLine)
        {
            bool inQuotes = false;

            return commandLine.Split(c =>
            {
                if (c == '\"')
                    inQuotes = !inQuotes;

                return !inQuotes && c == ' ';
            })
                              .Select(arg => arg.Trim().TrimMatchingQuotes('\"'))
                              .Where(arg => !string.IsNullOrEmpty(arg));
        }

        public static IEnumerable<string> Split(this string str,
                                        Func<char, bool> controller)
        {
            int nextPiece = 0;

            for (int c = 0; c < str.Length; c++)
            {
                if (controller(str[c]))
                {
                    yield return str.Substring(nextPiece, c - nextPiece);
                    nextPiece = c + 1;
                }
            }

            yield return str.Substring(nextPiece);
        }

        public static string TrimMatchingQuotes(this string input, char quote)
        {
            if ((input.Length >= 2) &&
                (input[0] == quote) && (input[input.Length - 1] == quote))
                return input.Substring(1, input.Length - 2);

            return input;
        }
    }

    public class ClientConsole : IUpdate
    {
        public static bool isLog = false;
        public static bool isTest = false;

        public static string worldId = "wrld_a5be505e-3578-42eb-a40f-6ae98f27877e";

        public static void Start()
        {
            new Thread(() => { while (true) { UpdateCommand(); } }).Start();
        }

        public static string[] args = new string[0];
        public static void UpdateCommand()
        {
            string consoleRead = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(consoleRead)) return;
            try
            {
                args = ConsoleResource.SplitCommandLine(consoleRead).ToArray();
            }
            catch { return; }

            switch (args[0])
            {
                case "clear":
                    {
                        Console.Clear();
                        break;
                    }
                case "help":
                    {
                        Console.WriteLine("~~~ [ HELP For BE4v ] ~~~");
                        Console.WriteLine("- connect World_Id:InstanceId (Not worked)");
                        Console.WriteLine("- avatar [avatar_id]  - change avatar by Avatar_ID");
                        Console.WriteLine("- avatarlist - Player List with AvatarId");
                        break;
                    }
                case "gg":
                    {
                        NotifySystem.Notify.isEnabled = !NotifySystem.Notify.isEnabled;
                        break;
                    }
                case "log":
                    {
                        isLog = !isLog;
                        if (isLog)
                        {
                            Console.WriteLine("Logs enabled!");
                        }
                        else
                        {
                            Console.WriteLine("Logs disabled!");
                        }
                        break;
                    }
                case "test":
                    {
                        isTest = !isTest;
                        if (isTest)
                        {
                            Console.WriteLine("isTest enabled!");
                        }
                        else
                        {
                            Console.WriteLine("isTest disabled!");
                        }
                        break;
                    }
                /*
            case "log2":
                {
                    isLogDetail = !isLogDetail;
                    if (isLogDetail)
                    {
                        Console.WriteLine("Logs detail enabled!");
                    }
                    else
                    {
                        Console.WriteLine("Logs detail disabled!");
                    }
                    break;
                }
                */
                default: return;
            }
            args = new string[0];
        }

        public void Update()
        {
            if (args == null || args.Length < 1) return;
            switch (args[0])
            {
                case "avatar":
                    {
                        if (args.Length > 1)
                        {
                            try
                            {
                                Utils.Avatars.ChangeAvatarById(args[1]);
                            }
                            catch { "Error changing avatar!".RedPrefix("Exception"); }
                        }
                        break;
                    }
                case "avatarlist":
                    {
                        if (NetworkSanity.NetworkSanity.players != null && NetworkSanity.NetworkSanity.players.Length > 0)
                        {
                            foreach (var player in NetworkSanity.NetworkSanity.players)
                            {
                                try
                                {
                                    Console.WriteLine($"{player.user.displayName.PadRight(40, ' ')} (AvatarId: {player.Components.AvatarModel.id})");
                                }
                                catch { }
                            }
                        }
                        break;
                    }
                case "scan":
                    {
                        /*

                        string displayName = UserUtils.QM_GetSelectedUserName();
                        if (!string.IsNullOrEmpty(displayName))
                        {
                            VRC.Player selectedPlayer = UserUtils.GetPlayerByName(displayName);
                            if (selectedPlayer != null)
                            {
                                FileDebug.debugGameObject("debug_SelectedPlayer.json", selectedPlayer.gameObject);
                            }
                        }
                        // For find DisplayName : For ForceCloneAvatar
                        // FileDebug.debugGameObject("debug_QuickMenu.json", go);
                        /*
                        if (go == null)
                            Console.WriteLine("Go is null");
                        var selectedMenu = go?.GetComponentInChildren<SelectedUserMenuQM>(true);
                        if (selectedMenu == null)
                            Console.WriteLine("selectedMenu: Null");
                        else
                        {
                            var user = selectedMenu._iUser;
                            if (user == null)
                                Console.WriteLine("_iUser: Null");
                            else
                            {
                                var userId = user.UserId;
                                if (userId == null)
                                    Console.WriteLine("_iUser: Null");
                                else if (string.IsNullOrEmpty(userId))
                                    Console.WriteLine("_iUser: Empty");
                                Console.WriteLine("test " + userId);
                            }
                        }
                        // (GameObject.Find("Buttons_QuickActions").transform.parent.name + "/(../ for Buttons_QuickActions)").RedPrefix("SCAN");

                        /*
                        using(StreamWriter stream = File.CreateText("test.txt"))
                        {
                            foreach (var behaviour in behaviours)
                            {
                                if (behaviour.name == "Canvas_QuickMenu(Clone)")
                                { 
                                }
                                stream.WriteLine(behaviour.name + "\n");
                            }
                        }
                        */
                        FileDebug.debugGameObject("debug_QuickMenu.json", UnityEngine.Resources.FindObjectsOfTypeAll<QuickMenu>().First().gameObject);
                        // Console.WriteLine(VRC.UI.PageUserInfo.userInfoScreenPath);
                        break;
                    }
                    /*
                case "udon":
                    {
                        if (args.Length > 1)
                        {
                            if (args[1] == "list")
                            {
                                try
                                {
                                    UdonBehaviour[] udons = UnityEngine.Object.FindObjectsOfType<UdonBehaviour>();
                                    foreach (var x in udons)
                                    {
                                        Console.WriteLine("- [" + x.gameObject.name + "] -");
                                        string[] programs = x.GetPrograms();
                                        Console.WriteLine("{");
                                        foreach (var y in programs)
                                        {
                                            Console.WriteLine("\t- " + y);
                                        }
                                        Console.WriteLine("}");
                                    }
                                }
                                catch { "Udon is bad!".RedPrefix("WARN"); }
                            }
                            else if (args[1] == "trigger")
                            {
                                if (args.Length > 2)
                                {
                                    GameObject gameObject = GameObject.Find(args[2]);
                                    if (gameObject == null)
                                    {
                                        Console.WriteLine(args[2] + " not found!");
                                        break;
                                    }
                                    if (args.Length > 3)
                                    {
                                        Network.RPC(VRC_EventHandler.VrcTargetType.All, gameObject, "UdonSyncRunProgramAsRPC", new IntPtr[] { new IL2String(args[3]).ptr });
                                    }
                                }
                            }
                        }
                        break;
                    }
                    */
                    /*
                case "portal":
                    {
                        if (args.Length > 1)
                        {
                            if (args[1] == "create")
                            {
                                if (args.Length > 2)
                                {
                                    string[] worldData = args[2].Split(':');
                                    UserUtils.SpawnPortal(VRCPlayer.Instance.transform, worldData[0], (worldData.Length > 1) ? worldData[1] : instanceId);
                                    ($"Created portal: {worldId}:" + ((worldData.Length > 1) ? worldData[1] : instanceId)).RedPrefix("Create portal");
                                }
                            }
                        }
                        break;
                    }
                case "gc":
                    {
                        AutoClearRAM.Clear();
                        break;
                    }
                */
            }
            args = new string[0];
        }
    }
}
