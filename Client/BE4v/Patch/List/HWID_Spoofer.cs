using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using IL2CPP_Core.Objects;
using BE4v.SDK;
using BE4v.Patch.Core;

namespace BE4v.Patch.List
{
    public class HWID_Spoofer : IPatch
    {
        public delegate IntPtr _UnityEngine_SystemInfo();
        public void Start()
        {
            IL2Method method = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("SystemInfo", "UnityEngine").GetProperty("deviceUniqueIdentifier").GetGetMethod();
            if (method != null)
            {
                new IL2Patch(method, (_UnityEngine_SystemInfo)UnityEngine_SystemInfo);
            }
            else
                throw new NullReferenceException();
        }

        static HWID_Spoofer()
        {
            string src = SDKLoader.mainDir + "/spoof-id.json";
            if (File.Exists(src))
            {
                _fakeDeviceId = new IL2String_utf8(File.ReadAllText(src));
            }
            if (string.IsNullOrWhiteSpace(_fakeDeviceId?.ToString()))
            {
                _fakeDeviceId = new IL2String_utf8(CalculateHash<SHA1>(Guid.NewGuid().ToString()));
                File.WriteAllText(src, _fakeDeviceId.ToString(), Encoding.UTF8);
            }
            _fakeDeviceId.Static = true;
        }


        public static IL2String _fakeDeviceId;
        private static IntPtr UnityEngine_SystemInfo()
        {
            return _fakeDeviceId.Pointer;
        }


        public static string CalculateHash<T>(string input) where T : HashAlgorithm
        {
            byte[] array = CalculateHash<T>(Encoding.UTF8.GetBytes(input));
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                stringBuilder.Append(array[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }

        public static byte[] CalculateHash<T>(byte[] buffer) where T : HashAlgorithm
        {
            byte[] result;
            using (T t = typeof(T).GetMethod("Create", new Type[0]).Invoke(null, null) as T)
            {
                result = t.ComputeHash(buffer);
            }
            return result;
        }

    }
}
