using System;
using System.Linq;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
    public class Object : IL2Object
    {
        public Object(IntPtr ptr) : base(ptr) { }

        public int GetInstanceID()
        {
            return Instance_Class.GetMethod(nameof(GetInstanceID)).Invoke<int>(this).GetValue();
        }
        
        public static T Instantiate<T>(T original, Transform parent) where T : Object
        {
            return Instantiate(original.GetValue<Object>(), parent, false)?.GetValue<T>();
        }
        public static Object Instantiate(Object original, Transform parent) => Instantiate(original, parent, false);
        public static T Instantiate<T>(Object original, Transform parent, bool instantiateInWorldSpace) where T : Object
        {
            return Instantiate(original, parent, instantiateInWorldSpace)?.GetValue<T>();
        }
        unsafe public static Object Instantiate(Object original, Transform parent, bool instantiateInWorldSpace)
        {
            return Instance_Class.GetMethod(nameof(Instantiate),
                x => x.GetParameters().Length == 3
                && x.GetParameters()[2].ReturnType.Name == typeof(bool).FullName
                && x.ReturnType.Name == Instance_Class.FullName).Invoke(new IntPtr[] { original.Pointer, parent.Pointer, new IntPtr(&instantiateInWorldSpace) })?.GetValue<Object>();
        }

        public static T FindObjectOfType<T>() where T : Object
        {
            var result = FindObjectsOfType(typeof(T));
            if (result != null)
                if (result.Length > 0)
                    return result[0].GetValue<T>();

            return null;
        }

        public static T[] FindObjectsOfType<T>() where T : Object
        {
            Object[] result = FindObjectsOfType(typeof(T));

            if (result != null)
                if (result.Length > 0)
                    return result.Select(x => x.GetValue<T>()).ToArray();

            return new T[0];
        }

        public static Object FindObjectOfType(Type type)
        {
            var result = FindObjectsOfType(type);
            if (result != null)
                if (result.Length > 0)
                    return result[0];

            return null;
        }
        public static Object[] FindObjectsOfType(Type type)
        {
            IntPtr typeObject = CastUtils.IL2Typeof(type);
            if (typeObject == IntPtr.Zero)
                return null;

            IL2Object result = Instance_Class.GetMethod(nameof(FindObjectsOfType), x => x.GetParameters().Length == 1).Invoke(new IntPtr[] { typeObject });
            if (result == null)
                return null;

            return new IL2Array<IntPtr>(result.Pointer).ToArray<Object>();
        }


        public static void DestroyImmediate(Object obj)
        {
            Instance_Class.GetMethod(nameof(DestroyImmediate), x => x.GetParameters().Length == 1).Invoke(new IntPtr[] { obj == null ? IntPtr.Zero : obj.Pointer });
        }

        public void Destroy() => Destroy(this, 0f);
        public void Destroy(float time) => Destroy(this, time);
        public static void Destroy(Object obj) => Destroy(obj, 0f);
        unsafe public static void Destroy(Object obj, float time)
        {
            if (obj == null || time < 0)
                return;

            Instance_Class.GetMethod(nameof(Destroy), m => m.GetParameters().Length == 2).Invoke(new IntPtr[] { obj.Pointer, new IntPtr(&time) });
        }

        unsafe public static Object FindObjectFromInstanceID(int instanceID)
        {
            return Instance_Class.GetMethod(nameof(FindObjectFromInstanceID)).Invoke(new IntPtr[] { new IntPtr(&instanceID) })?.GetValue<Object>();
        }

        public static void DontDestroyOnLoad(Object target)
        {
            Instance_Class.GetMethod(nameof(DontDestroyOnLoad)).Invoke(new IntPtr[] { target.Pointer });
        }
        unsafe public HideFlags hideFlags
        {
            get => Instance_Class.GetProperty(nameof(hideFlags)).GetGetMethod().Invoke<HideFlags>(this).GetValue();
            set => Instance_Class.GetProperty(nameof(hideFlags)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
        }
        public string name
        {
            get => Instance_Class.GetProperty(nameof(name)).GetGetMethod().Invoke(this)?.GetValue<IL2String>().ToString();
            set => Instance_Class.GetProperty(nameof(name)).GetSetMethod().Invoke(this, new IntPtr[] { new IL2String_utf16(value).Pointer });
        }

        public new string ToString()
        {
            return Instance_Class.GetMethod(nameof(ToString)).Invoke(this)?.GetValue<IL2String>().ToString();
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("Object", "UnityEngine");
    }
}
