using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
    public static class Time
    {
        public static float time
        {
            get => Instance_Class.GetProperty(nameof(time)).GetGetMethod().Invoke<float>().GetValue();
        }

        public static float timeSinceLevelLoad
        {
            get => Instance_Class.GetProperty(nameof(timeSinceLevelLoad)).GetGetMethod().Invoke<float>().GetValue();
        }

        public static float deltaTime
        {
            get => Instance_Class.GetProperty(nameof(deltaTime)).GetGetMethod().Invoke<float>().GetValue();
        }

        public static float fixedTime
        {
            get => Instance_Class.GetProperty(nameof(fixedTime)).GetGetMethod().Invoke<float>().GetValue();
        }

        public static float unscaledTime
        {
            get => Instance_Class.GetProperty(nameof(unscaledTime)).GetGetMethod().Invoke<float>().GetValue();
        }

        public static float fixedUnscaledTime
        {
            get => Instance_Class.GetProperty(nameof(fixedUnscaledTime)).GetGetMethod().Invoke<float>().GetValue();
        }

        public static float unscaledDeltaTime
        {
            get => Instance_Class.GetProperty(nameof(unscaledDeltaTime)).GetGetMethod().Invoke<float>().GetValue();
        }
        
        public static float fixedUnscaledDeltaTime
        {
            get => Instance_Class.GetProperty(nameof(fixedUnscaledDeltaTime)).GetGetMethod().Invoke<float>().GetValue();
        }

        unsafe public static float fixedDeltaTime
        {
            get => Instance_Class.GetProperty(nameof(fixedDeltaTime)).GetGetMethod().Invoke<float>().GetValue();
            set => Instance_Class.GetProperty(nameof(fixedDeltaTime)).GetSetMethod().Invoke(new IntPtr[] { new IntPtr(&value) });
        }

        public static float maximumDeltaTime
        {
            get => Instance_Class.GetProperty(nameof(maximumDeltaTime)).GetGetMethod().Invoke<float>().GetValue();
        }

        public static float smoothDeltaTime
        {
            get => Instance_Class.GetProperty(nameof(smoothDeltaTime)).GetGetMethod().Invoke<float>().GetValue();
        }

        unsafe public static float timeScale
        {
            get => Instance_Class.GetProperty(nameof(timeScale)).GetGetMethod().Invoke<float>().GetValue();
            set => Instance_Class.GetProperty(nameof(timeScale)).GetSetMethod().Invoke(new IntPtr[] { new IntPtr(&value) });
        }

        public static int frameCount
        {
            get => Instance_Class.GetProperty(nameof(frameCount)).GetGetMethod().Invoke<int>().GetValue();
        }

        public static int renderedFrameCount
        {
            get => Instance_Class.GetProperty(nameof(renderedFrameCount)).GetGetMethod().Invoke<int>().GetValue();
        }

        public static float realtimeSinceStartup
        {
            get => Instance_Class.GetProperty(nameof(realtimeSinceStartup)).GetGetMethod().Invoke<float>().GetValue();
        }

        public static int captureFramerate
        {
            get => Instance_Class.GetProperty(nameof(captureFramerate)).GetGetMethod().Invoke<int>().GetValue();
        }

        public static bool inFixedTimeStep
        {
            get => Instance_Class.GetProperty(nameof(inFixedTimeStep)).GetGetMethod().Invoke<bool>().GetValue();
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("Time", "UnityEngine");
    }
}
