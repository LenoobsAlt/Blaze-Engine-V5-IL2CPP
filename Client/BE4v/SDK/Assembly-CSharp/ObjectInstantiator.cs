using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;
using BE4v.SDK;

public class ObjectInstantiator : MonoBehaviour
{
    public ObjectInstantiator(IntPtr ptr) : base(ptr) { }

    public static string[] adminOnlyPrefabs
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(adminOnlyPrefabs));
            if (field == null)
                (field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(string[]).FullName && new IL2Array<IntPtr>(x.GetValue().Pointer).Length == 1)).Name = nameof(adminOnlyPrefabs);
            IL2Object result = field?.GetValue();
            if (result == null)
                return null;

            IL2String[] array = new IL2Array<IntPtr>(result.Pointer).ToArray<IL2String>();
            return array.Select(x => x.ToString()).ToArray();
        }
        set
        {
            IL2Field field = Instance_Class.GetField(nameof(adminOnlyPrefabs));
            if (field == null)
                (field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(string[]).FullName && new IL2Array<IntPtr>(x.GetValue().Pointer).Length == 1)).Name = nameof(adminOnlyPrefabs);

            int len = value.Length;
            IL2Array<IntPtr> array = new IL2Array<IntPtr>(len, IL2String.Instance_Class);
            for(int i=0;i<len;i++)
            {
                array[i] = new IL2String_utf8(value[i]).Pointer;
            }
            field?.SetValue(IntPtr.Zero, array.Pointer);
        }
    }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("_InstantiateObject") != null);
}
