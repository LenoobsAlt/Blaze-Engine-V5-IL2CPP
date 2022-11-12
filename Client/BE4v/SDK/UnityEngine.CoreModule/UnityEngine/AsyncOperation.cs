using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
    public class AsyncOperation : YieldInstruction
    {
        public AsyncOperation(IntPtr ptr) : base(ptr) { }

        unsafe public static void InternalDestroy(IntPtr ptr)
        {
            Instance_Class.GetMethod(nameof(InternalDestroy)).Invoke(new IntPtr[] { new IntPtr(&ptr) });
        }

        public bool isDone
        {
            get => Instance_Class.GetProperty(nameof(isDone)).GetGetMethod().Invoke<bool>(this).GetValue();
        }
        
        public float progress
        {
            get => Instance_Class.GetProperty(nameof(progress)).GetGetMethod().Invoke<float>(this).GetValue();
        }

        public bool allowSceneActivation
        {
            get => Instance_Class.GetProperty(nameof(allowSceneActivation)).GetGetMethod().Invoke<bool>(this).GetValue();
        }

        public void InvokeCompletionEvent()
        {
            Instance_Class.GetMethod(nameof(InvokeCompletionEvent)).Invoke();
        }
        
        /*public event Action<AsyncOperation> completed
        {
            add
            {
            }
            remove
            {
            }
        }*/

        unsafe public IntPtr m_Ptr
        {
            get => Instance_Class.GetField(nameof(m_Ptr)).GetValue<IntPtr>(this).GetValue();
            set => Instance_Class.GetField(nameof(m_Ptr)).SetValue(this, new IntPtr(&value));
        }

        // private Action<AsyncOperation> m_completeCallback;

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("AsyncOperation", "UnityEngine");
    }
}
