using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
    public static class ImageConversion
    {
        public static byte[] EncodeToPNG(this Texture2D tex)
        {
            IL2Object result = Instance_Class.GetMethod(nameof(EncodeToPNG)).Invoke(new IntPtr[] { tex == null ? IntPtr.Zero : tex.Pointer });
            if (result == null)
                return null;

            return new IL2Array<byte>(result.Pointer).GetAsByteArray();
        }
        
        public static void EncodeToPNG_Save(this Texture2D tex, string szFile)
        {
            IntPtr ptr = Instance_Class.GetMethod(nameof(EncodeToPNG)).Invoke(new IntPtr[] { tex == null ? IntPtr.Zero : tex.Pointer }).Pointer;
            System.IO.IL2File.WriteAllBytes(szFile, ptr);
        }

        unsafe public static bool LoadImage(this Texture2D tex, byte[] data)
        {
            IL2Array<byte> array = null;
            if (data != null)
            {
                array = new IL2Array<byte>(data.Length, IL2Byte.Instance_Class);
                for (int i = 0; i < data.Length; i++)
                {
                    array[i] = data[i];
                }
            }
            return Instance_Class.GetMethod(nameof(LoadImage), x => x.GetParameters().Length == 2).Invoke<bool>(new IntPtr[] { tex == null ? IntPtr.Zero : tex.Pointer, array == null ? IntPtr.Zero : array.Pointer }).GetValue();
        }
        
        public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.ImageConversionModule"].GetClass("ImageConversion", "UnityEngine");
    }
}
