using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRCLoader;
using VRCLoader.Utils;

namespace VRCLoader.Domain
{
    internal sealed class DomainManager : AppDomainManager, INetDomain
    {
        public DomainManager() { }
        public override void InitializeNewDomain(AppDomainSetup appDomainInfo) { InitializationFlags = AppDomainManagerInitializationOptions.RegisterWithHost; }

        public void Initialize() => VRCLoader.Load();
        public void OnApplicationStart() => VRCLoader._self.Start();
        public void MinHook_CreateInstance(IntPtr mVRC_CreateHook, IntPtr mVRC_RemoveHook, IntPtr mVRC_EnableHook, IntPtr mVRC_DisableHook) => MinHook.CreateInstance(mVRC_CreateHook, mVRC_RemoveHook, mVRC_EnableHook, mVRC_DisableHook);
        // public void MH_PatchController(ref bool status, ref IntPtr target, ref IntPtr desc) => MinHook.MH_PatchController(ref status, ref target, ref desc);
    }
}
