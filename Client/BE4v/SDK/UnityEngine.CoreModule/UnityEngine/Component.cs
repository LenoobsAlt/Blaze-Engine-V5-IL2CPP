using System;
using IL2CPP_Core.Objects;


namespace UnityEngine
{
    public class Component : Object
    {
        public Component(IntPtr ptr) : base(ptr) { }

        public Transform transform
        {
            get => Instance_Class.GetProperty(nameof(transform)).GetGetMethod().Invoke(this)?.GetValue<Transform>();
        }

        public T GetComponentInChildren<T>() where T : Component => GetComponentInChildren(typeof(T))?.GetValue<T>();
        public T GetComponentInChildren<T>(bool includeInactive) where T : Component => GetComponentInChildren(typeof(T), includeInactive).GetValue<T>();
        public T[] GetComponentsInChildren<T>() where T : Component => gameObject?.GetComponentsInChildren<T>();
        public T[] GetComponentsInChildren<T>(bool includeInactive) where T : Component => gameObject?.GetComponentsInChildren<T>(includeInactive);
        public Component GetComponentInChildren(Type type) => GetComponentInChildren(type, false);
        public Component GetComponentInChildren(Type type, bool includeInactive) => gameObject?.GetComponentInChildren(type, includeInactive);
        public Component[] GetComponentsInChildren(Type type) => gameObject?.GetComponentsInChildren(type);
        public Component[] GetComponentsInChildren(Type type, bool includeInactive) => gameObject?.GetComponentsInChildren(type, includeInactive);
        public T GetComponent<T>() where T : Component => gameObject?.GetComponent<T>();
        public T[] GetComponents<T>() where T : Component => gameObject?.GetComponents<T>();
        public Component GetComponent(Type type) => gameObject?.GetComponent(type);
        public Component GetComponent(string type) => gameObject?.GetComponent(type);
        public Component[] GetComponents(Type type) => gameObject?.GetComponents(type);

        public string tag
        {
            get => gameObject.tag;
            set => gameObject.tag = value;
        }

        public GameObject gameObject
        {
            get => Instance_Class.GetProperty(nameof(gameObject)).GetGetMethod().Invoke(this)?.GetValue<GameObject>();
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("Component", "UnityEngine");
    }
}
