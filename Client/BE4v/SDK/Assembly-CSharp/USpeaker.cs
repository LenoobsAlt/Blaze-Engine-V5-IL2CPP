using System;
using System.Linq;
using IL2CPP_Core.Objects;
using MoPhoGames.USpeak.Core;
using UnityEngine;

public class USpeaker : MonoBehaviour
{
    public USpeaker(IntPtr ptr) : base(ptr) { }

    unsafe public static float LocalGain
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(LocalGain));
            if (field == null)
            {
                (field = Instance_Class.GetFields().Skip(3).FirstOrDefault()).Name = nameof(LocalGain);
                if (field == null)
                    return default;
            }
            return field.GetValue<float>().GetValue();
        }
        set
        {
            IL2Field field = Instance_Class.GetField(nameof(LocalGain));
            if (field == null)
            {
                (field = Instance_Class.GetFields().Skip(3).FirstOrDefault()).Name = nameof(LocalGain);
                if (field == null)
                    return;
            }
            field?.SetValue(new IntPtr(&value));
        }
    }
    
    public struct EncodeInfo
    {
        public USpeakFrameContainer frameContainer;

        public float[] pcmData;

        public float pcmDataLength;

        public ushort frameIndex;

        public static IL2Class Instance_Class = USpeaker.Instance_Class.GetNestedTypes()
            .FirstOrDefault(x => x.GetFields().Length == 4
                && x.GetField(y => y.ReturnType.Name == typeof(float).FullName) != null
                && x.GetField(y => y.ReturnType.Name == typeof(float[]).FullName) != null
                && x.GetField(y => y.ReturnType.Name == typeof(ushort).FullName) != null
            );
    }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClass(VRC.Player.Instance_Class.GetField("_USpeaker")?.ReturnType.Name);
}