using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class SimpleAudioGain : MonoBehaviour
{
    public SimpleAudioGain(IntPtr ptr) : base(ptr) { }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("OnAudioFilterRead") != null && x.GetField(y => y.ReturnType.Name == "UnityEngine.AudioSource") != null);
}