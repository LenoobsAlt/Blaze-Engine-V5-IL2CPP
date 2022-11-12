using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace BE4v.SDK
{
    public static class SDKLoader
    {
        /*
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);

        */
        public static string mainDir = Path.Combine(Environment.CurrentDirectory, "BlazeEngine");

        public static void Start()
        {
            // LoadLibrary("VRCTool.dll");

            Console.WriteLine("Welcome to BE4v");
            Console.WriteLine("GitHub: https://github.com/BlazeBest/BlazeEngine-IL2CPP");
            Console.WriteLine("Donate: https://client.icefrag.ru/donate");
            Console.WriteLine("Discord: https://discord.gg/8mMGM43");
            Console.WriteLine("Developer: BlazeBest#1284");

            if (!Directory.Exists(mainDir))
                Directory.CreateDirectory(mainDir);
        }

        public static void Finish()
        {
            new Thread(() => { BVault.Load(); }).Start();
        }
    }
}

public static class FileDebug
{
    public static Texture2D createReadabeTexture2D(Texture2D texture2d)
    {
        RenderTexture renderTexture = RenderTexture.GetTemporary(texture2d.width, texture2d.height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
        Graphics.Blit(texture2d, renderTexture);

        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = renderTexture;

        Texture2D readableTextur2D = new Texture2D(texture2d.width, texture2d.height);
        readableTextur2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        readableTextur2D.Apply();

        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(renderTexture);

        return readableTextur2D;

    }

    public static void AddFileDebug(string file, string text)
    {
        try
        {
            using (StreamWriter streamWriter = File.AppendText(file))
            {
                streamWriter.WriteLine(text);
            }
        }
        catch
        {
            Console.WriteLine("Error: 0x00D");
        }
    }
    public static void debugGameObject(string file, GameObject gameObject)
    {
        try
        {
            using (StreamWriter streamWriter = File.CreateText(file))
            {
                streamWriter.WriteLine(debugGetInfoGameObject(gameObject, 0));
            }
        }
        catch
        {
            Console.WriteLine("Error: 0x00D");
        }
    }

    public static string debugGetInfoGameObject(GameObject gameObject, int Index)
    {
        string result = string.Empty;
        if (gameObject == null)
            return result;

        string IndexChar = string.Empty.AddChar('\t', Index);

        result += IndexChar + "{\n";
        IndexChar = string.Empty.AddChar('\t', ++Index);
        result += IndexChar + "\"Name\":\"" + gameObject.name + "\"\n";
        result += IndexChar + "\"Components\":\n";
        result += IndexChar + "{\n";
        IndexChar = string.Empty.AddChar('\t', ++Index);
        foreach (Component component in gameObject.GetComponents<Component>())
        {
            result += IndexChar + "\"" + component.ToString() + "\"\n";
        }
        IndexChar = string.Empty.AddChar('\t', --Index);
        result += IndexChar + "}\n";
        if (gameObject.transform.childCount > 0)
        {
            result += IndexChar + "\"GameObjects\":\n";
            result += IndexChar + "[\n";
            foreach (Transform transform in gameObject.transform)
            {
                result += debugGetInfoGameObject(transform.gameObject, Index + 1);
            }
            result += IndexChar + "]\n";
        }
        IndexChar = string.Empty.AddChar('\t', --Index);
        result += IndexChar + "},\n";
        return result;
    }

    public static string AddChar(this string str, char chr, int Index)
    {
        return str += string.Empty.PadRight(Index, chr);
    }
}