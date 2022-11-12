using System;
using System.Linq;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
    public sealed class GameObject : Object
    {
        public GameObject(IntPtr ptr) : base(ptr) { }

        public GameObject(string name) : base(IntPtr.Zero)
        {
            Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
            Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 1).Invoke(Pointer, new IntPtr[] { new IL2String_utf16(name).Pointer });
        }

        public Component AddComponent(Type type)
        {
            IntPtr typeObject = type.IL2Typeof();
            if (typeObject == IntPtr.Zero)
                return null;

            return Instance_Class.GetMethod(nameof(AddComponent), m => m.GetParameters().Length == 1).Invoke(this, new IntPtr[] { typeObject })?.GetValue<Component>();
        }
        public T AddComponent<T>() where T : Component => AddComponent(typeof(T))?.GetValue<T>();

        unsafe public static GameObject CreatePrimitive(PrimitiveType type)
        {
            return Instance_Class.GetMethod(nameof(CreatePrimitive)).Invoke(new IntPtr[] { new IntPtr(&type) })?.GetValue<GameObject>();
        }

        public T GetOrAddComponent<T>() where T : Component
        {
            Component component = GetComponent(typeof(T));
            if (component == null)
                component = AddComponent(typeof(T));
            return component?.GetValue<T>();
        }

        public T GetComponent<T>() where T : Component => GetComponent(typeof(T))?.GetValue<T>();
        public Component GetComponent(Type type)
        {
            Component[] components = GetComponents(type);

            if (components != null)
                if (components.Length > 0)
                    return components[0];

            return null;
        }

        public Component GetComponent(string type)
        {
            return Instance_Class.GetMethod("GetComponentByName").Invoke(this, new IntPtr[] { new IL2String_utf16(type).Pointer })?.GetValue<Component>();
        }

        public T GetComponentInChildren<T>() where T : Component => GetComponentInChildren(typeof(T))?.GetValue<T>();
        public T GetComponentInChildren<T>(bool includeInactive) where T : Component => GetComponentInChildren(typeof(T), includeInactive)?.GetValue<T>();
        public Component GetComponentInChildren(Type type) => GetComponentInChildren(type, false);
        unsafe public Component GetComponentInChildren(Type type, bool includeInactive)
        {
            IntPtr typeObject = type.IL2Typeof();
            if (typeObject == IntPtr.Zero)
                return null;

            return Instance_Class.GetMethod(nameof(GetComponentInChildren), x => x.GetParameters().Length == 2).Invoke(this, new IntPtr[] { typeObject, new IntPtr(&includeInactive) })?.GetValue<Component>();
        }

        public T[] GetComponents<T>() where T : Component
        {
            Component[] components = GetComponents(typeof(T));
            if (components == null || components.Length < 1)
                return new T[0];

            T[] ts = new T[components.Length];
            for (int i = 0; i < components.Length; i++)
            {
                ts[i] = components[i].GetValue<T>();
            }
            return ts;
        }
        public Component[] GetComponents(Type type)
        {
            IntPtr typeObject = type.IL2Typeof();
            if (typeObject == IntPtr.Zero)
                return null;

            IL2Object result = Instance_Class.GetMethod(nameof(GetComponents), x => x.GetParameters().Length == 1 && x.ReturnType.Name.EndsWith("[]")).Invoke(this, new IntPtr[] { typeObject });
            if (result == null)
                return null;

            return new IL2Array<IntPtr>(result.Pointer).ToArray<Component>();
        }

        public T[] GetComponentsInChildren<T>() where T : Component => GetComponentsInChildren<T>(false);
        public T[] GetComponentsInChildren<T>(bool includeInactive) where T : Component
        {
            Component[] components = GetComponentsInChildren(typeof(T), includeInactive);
            if (components == null || components.Length < 1)
                return new T[0];

            T[] ts = new T[components.Length];
            for (int i = 0; i < components.Length; i++)
            {
                ts[i] = components[i].GetValue<T>();
            }
            return ts;
        }
        public Component[] GetComponentsInChildren(Type type) => GetComponentsInChildren(type, false);
        unsafe public Component[] GetComponentsInChildren(Type type, bool includeInactive)
        {
            IntPtr typeObject = type.IL2Typeof();
            if (typeObject == IntPtr.Zero)
                return null;

            IL2Object result = Instance_Class.GetMethod(nameof(GetComponentsInChildren), x => x.GetParameters().Length == 2 && x.ReturnType.Name.EndsWith("[]")).Invoke(this, new IntPtr[] { typeObject, new IntPtr(&includeInactive) });
            if (result == null)
                return null;
            
            return new IL2Array<IntPtr>(result.Pointer).ToArray<Component>();
        }

        public static GameObject FindWithTag(string tag)
        {
            return Instance_Class.GetMethod(nameof(FindWithTag)).Invoke(new IntPtr[] { new IL2String_utf16(tag).Pointer })?.GetValue<GameObject>();
        }
        

        public static GameObject Find(string name)
        {
            return Instance_Class.GetMethod(nameof(Find)).Invoke(new IntPtr[] { new IL2String_utf16(name).Pointer })?.GetValue<GameObject>();
        }

        public Transform transform
        {
            get => Instance_Class.GetProperty(nameof(transform)).GetGetMethod().Invoke(this)?.GetValue<Transform>();
        }

        unsafe public int layer
        {
            get => Instance_Class.GetProperty(nameof(layer)).GetGetMethod().Invoke<int>(this).GetValue();
            set => Instance_Class.GetProperty(nameof(layer)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
        }

        unsafe public bool active
        {
            get => Instance_Class.GetProperty(nameof(active)).GetGetMethod().Invoke<bool>(this).GetValue();
            set => Instance_Class.GetProperty(nameof(active)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
        }

        unsafe public void SetActive(bool value)
        {
            Instance_Class.GetMethod(nameof(SetActive)).Invoke(this, new IntPtr[] { new IntPtr(&value) });
        }

        public bool activeSelf
        {
            get => Instance_Class.GetProperty(nameof(activeSelf)).GetGetMethod().Invoke<bool>(this).GetValue();
        }

        public bool activeInHierarchy
        {
            get => Instance_Class.GetProperty(nameof(activeInHierarchy)).GetGetMethod().Invoke<bool>(this).GetValue();
        }

        unsafe public void SetActiveRecursively(bool value)
        {
            Instance_Class.GetMethod(nameof(SetActiveRecursively)).Invoke(this, new IntPtr[] { new IntPtr(&value) });
        }

        unsafe public bool isStatic
        {
            get => Instance_Class.GetProperty(nameof(isStatic)).GetGetMethod().Invoke<bool>(this).GetValue();
            set => Instance_Class.GetProperty(nameof(isStatic)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
        }

        public string tag
        {
            get => Instance_Class.GetProperty(nameof(tag)).GetGetMethod().Invoke(this)?.GetValue<IL2String>().ToString();
            set => Instance_Class.GetProperty(nameof(tag)).GetSetMethod().Invoke(this, new IntPtr[] { new IL2String_utf16(value).Pointer });
        }

        public GameObject gameObject
        {
            get => Instance_Class.GetProperty(nameof(gameObject)).GetGetMethod().Invoke(this)?.GetValue<GameObject>();
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("GameObject", "UnityEngine");
    }
}
