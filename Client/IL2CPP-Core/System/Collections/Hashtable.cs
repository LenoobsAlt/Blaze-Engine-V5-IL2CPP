using System;
using IL2CPP_Core.Objects;

namespace System.Collections
{
    public class IL2Hashtable : IL2Object
    {
        public IL2Hashtable(IntPtr ptr) : base(ptr) { }

        public IntPtr this[IntPtr key]
        {
            get => Instance_Class.GetProperty("Item").GetGetMethod().Invoke(this, new IntPtr[] { key }).Pointer;
            set => Instance_Class.GetProperty("Item").GetSetMethod().Invoke(this, new IntPtr[] { key, value });
        }

        //        public new IEnumerator<DictionaryEntry> GetEnumerator()
        //        {
        //            return new DictionaryEntryEnumerator(((IDictionary)this).GetEnumerator());
        //        }

        public new string ToString()
        {
            return Instance_Class.GetMethod(nameof(ToString)).Invoke(this)?.GetValue<IL2String>().ToString();
        }

        //        public object Clone()
        //        {
        //            return new Dictionary<object, object>(this);
        //        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass(typeof(Hashtable).Name, typeof(Hashtable).Namespace);
    }
}