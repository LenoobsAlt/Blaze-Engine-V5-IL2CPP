using BE4v.Mods;
using BE4v.SDK;
using System;
using System.IO;
using System.Reflection;

namespace BE4v
{
    public static class BVault
    {
        public static void Save()
        {
            if (!Directory.Exists(SDKLoader.mainDir))
                Directory.CreateDirectory(SDKLoader.mainDir);

            string text = string.Empty;
            try
            {
                if (File.Exists(fileCfg))
                    text = File.ReadAllText(fileCfg);
            }
            catch { "Bad read a Config!".RedPrefix("Error"); }

            FieldInfo[] fields = typeof(Status).GetFields();
            text = text.PadRight(fields.Length * 4, '\u0001');
            int i = 1;
            char[] chars = text.ToCharArray();
            foreach (var val in fields)
            {
                if (val.FieldType == typeof(bool))
                    chars[SaveCreateIndex(i.ToString())] = ((bool)val.GetValue(null)).ToString() == "False" ? '\u0001' : '\u0003';
                else if (val.FieldType == typeof(int))
                {
                    int iVal = (int)val.GetValue(null);
                    if (iVal < 1 || iVal > 500)
                        iVal = 1;
                    chars[SaveCreateIndex(i.ToString())] = (char)iVal;
                }
                i++;
            }
            text = string.Empty;
            foreach(var c in chars)
                text += c;

            try
            {
                File.WriteAllText(fileCfg, text);
            }
            catch { "Bad save a Config!".RedPrefix("Error"); }
        }

        public static void Load()
        {
            if (!Directory.Exists(SDKLoader.mainDir))
                Directory.CreateDirectory(SDKLoader.mainDir);

            string text = string.Empty;
            try
            {
                if (File.Exists(fileCfg))
                    text = File.ReadAllText(fileCfg);
            }
            catch { "Bad read a Config!".RedPrefix("Error"); }

            int i = 0;
            FieldInfo[] fields = typeof(Status).GetFields();
            char[] chars = text.ToCharArray();
            foreach (var val in chars)
            {
                float f = i;
                if (((f + 1) / 4) == ((i + 1) / 4))
                {
                    string iStr = SaveCreateNamed(i);
                    int ii = Convert.ToInt32(iStr);
                    int iii = 1;
                    foreach(var field in fields)
                    {
                        if (iii++ == ii)
                        {
                            if (field.FieldType == typeof(bool))
                                field.SetValue(null, Convert.ToBoolean(val == '\u0001' ? "False" : "True"));
                            else if (field.FieldType == typeof(int))
                                field.SetValue(null, (int)val);
                            break;
                        }
                    }
                }
                i++;
            }
        }

        public static int SaveCreateIndex(string key)
        {
            return (Convert.ToInt32(key) * 4) - 1;
        }

        public static string SaveCreateNamed(int index)
        {
            return ((index + 1) / 4).ToString();
        }

        public static string fileCfg = SDKLoader.mainDir + "/BE4V_Config";
    }
}
