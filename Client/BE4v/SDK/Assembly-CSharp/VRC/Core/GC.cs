using System;
using System.Linq;
using IL2CPP_Core.Objects;

namespace VRC.Core
{
    public static class GC
    {
		unsafe public static void Collect(bool unusedAssets = true, bool compacting = false)
		{
			IL2Method method = Instance_Class.GetMethod(nameof(Collect));
			if (method == null)
            {
				(method = Instance_Class.GetMethods(x => x.GetParameters().Length == 2).FirstOrDefault()).Name = nameof(Collect);
				if (method == null)
					return;
			}

			method.Invoke(new IntPtr[] { new IntPtr(&unusedAssets), new IntPtr(&compacting) });
		}

		unsafe public static void MaybeCollect(bool unusedAssets = true, bool compacting = false)
		{
			IL2Method method = Instance_Class.GetMethod(nameof(MaybeCollect));
			if (method == null)
			{
				(method = Instance_Class.GetMethods(x => x.GetParameters().Length == 2).LastOrDefault()).Name = nameof(MaybeCollect);
				if (method == null)
					return;
			}

			method.Invoke(new IntPtr[] { new IntPtr(&unusedAssets), new IntPtr(&compacting) });
		}

		unsafe public static void EnsureHeapSize(int megabytes)
		{
			IL2Method method = Instance_Class.GetMethod(nameof(EnsureHeapSize));
			if (method == null)
			{
				(method = Instance_Class.GetMethods(x => x.GetParameters().Length == 1).FirstOrDefault()).Name = nameof(EnsureHeapSize);
				if (method == null)
					return;
			}

			method.Invoke(new IntPtr[] { new IntPtr(&megabytes) });
		}

		unsafe public static void AllocateMegabytes(int megaBytes)
		{
			IL2Method method = Instance_Class.GetMethod(nameof(AllocateMegabytes));
			if (method == null)
			{
				(method = Instance_Class.GetMethods(x => x.GetParameters().Length == 1).LastOrDefault()).Name = nameof(AllocateMegabytes);
				if (method == null)
					return;
			}

			method.Invoke(new IntPtr[] { new IntPtr(&megaBytes) });
		}


		public static IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClass("GC", "VRC.Core");
    }
}