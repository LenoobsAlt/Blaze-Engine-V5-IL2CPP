using System;
using System.Linq;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
    public sealed class Resources
    {
        public static T[] FindObjectsOfTypeAll<T>() where T : Object
        {
            Object[] objects = FindObjectsOfTypeAll(typeof(T));
            T[] result = new T[objects.Length];
            for (int i = 0; i < objects.Length; i++)
            {
                result[i] = objects[i].GetValue<T>();
            }
            return result;
        }
        public static Object[] FindObjectsOfTypeAll(Type type)
        {
            IntPtr typeObject = type.IL2Typeof();
            if (typeObject == IntPtr.Zero)
                return null;

            IL2Object @object = Instance_Class.GetMethod(nameof(FindObjectsOfTypeAll), x => x.ReturnType.Name == Object.Instance_Class.FullName + "[]").Invoke(new IntPtr[] { typeObject });
            if (@object == null)
                return null;

            return new IL2Array<IntPtr>(@object.Pointer).ToArray<Object>();
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("Resources", "UnityEngine");
    }
}
