using System;
using System.Collections;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
    public class Transform : Component, IEnumerable
    {
        public Transform(IntPtr ptr) : base(ptr) { }

        public Vector3 forward
        {
            get => Instance_Class.GetProperty(nameof(forward)).GetGetMethod().Invoke<Vector3>(this).GetValue();
        }

        public Vector3 right
        {
            get => Instance_Class.GetProperty(nameof(right)).GetGetMethod().Invoke<Vector3>(this).GetValue();
        }

        unsafe public Vector3 position
        {
            get => Instance_Class.GetProperty(nameof(position)).GetGetMethod().Invoke<Vector3>(this).GetValue();
            set => Instance_Class.GetProperty(nameof(position)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
        }

        unsafe public Vector3 localPosition
        {
            get => Instance_Class.GetProperty(nameof(localPosition)).GetGetMethod().Invoke<Vector3>(this).GetValue();
            set => Instance_Class.GetProperty(nameof(localPosition)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
        }

        unsafe public Vector3 localEulerAngles
        {
            get => Instance_Class.GetProperty(nameof(localEulerAngles)).GetGetMethod().Invoke<Vector3>(this).GetValue();
            set => Instance_Class.GetProperty(nameof(localEulerAngles)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
        }

        unsafe public Quaternion rotation
        {
            get => Instance_Class.GetProperty(nameof(rotation)).GetGetMethod().Invoke<Quaternion>(this).GetValue();
            set => Instance_Class.GetProperty(nameof(rotation)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
        }

        unsafe public Vector3 localScale
        {
            get => Instance_Class.GetProperty(nameof(localScale)).GetGetMethod().Invoke<Vector3>(this).GetValue();
            set => Instance_Class.GetProperty(nameof(localScale)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
        }

        public Vector3 lossyScale
        {
            get => Instance_Class.GetProperty(nameof(lossyScale)).GetGetMethod().Invoke<Vector3>(this).GetValue();
        }

        public Transform Find(string name)
        {
            return Instance_Class.GetMethod(nameof(Find)).Invoke(this, new IntPtr[] { new IL2String_utf16(name).Pointer })?.GetValue<Transform>();
        }

        public void SetParent(Transform transform)
        {
            Instance_Class.GetMethod(nameof(SetParent), x => x.GetParameters().Length == 1).Invoke(this, new IntPtr[] { transform == null ? IntPtr.Zero : transform.Pointer });
        }

        public int childCount
        {
            get => Instance_Class.GetProperty(nameof(childCount)).GetGetMethod().Invoke<int>(this).GetValue();
        }

        public Transform parent
        {
            get => Instance_Class.GetProperty(nameof(parent)).GetGetMethod().Invoke(this)?.GetValue<Transform>();
            set => Instance_Class.GetProperty(nameof(parent)).GetSetMethod().Invoke(this, new IntPtr[] { value == null ? IntPtr.Zero : value.Pointer });
        }

        unsafe public Transform GetChild(int index)
        {
            return Instance_Class.GetMethod(nameof(GetChild)).Invoke(this, new IntPtr[] { new IntPtr(&index) })?.GetValue<Transform>();
        }

        unsafe public void SetSiblingIndex(int index)
        {
            Instance_Class.GetMethod(nameof(SetSiblingIndex)).Invoke(this, new IntPtr[] { new IntPtr(&index) });
        }

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        private sealed class Enumerator : IEnumerator
        {
            internal Enumerator(Transform outer)
            {
                this.outer = outer;
            }

            public object Current
            {
                get
                {
                    return outer.GetChild(currentIndex);
                }
            }

            public bool MoveNext()
            {
                int childCount = outer.childCount;
                return ++currentIndex < childCount;
            }

            public void Reset()
            {
                currentIndex = -1;
            }

            private Transform outer;

            private int currentIndex = -1;
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("Transform", "UnityEngine");
    }
}
