// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"
#include <iostream>
#include <metahost.h>
#include <CorError.h>
#pragma comment(lib, "mscoree.lib")
#include <sstream>

#include "min_host.h"
#include "include/MinHook.h"
#pragma comment(lib, "libMinHook-x64-v141-mdd.lib")


int main()
{
    MH_Initialize();

    ICLRMetaHost* meta_host = NULL;
    ICLRRuntimeInfo* runtime_info = NULL;
    ICLRRuntimeHost* runtime_host = NULL;
    DWORD return_val;
    HRESULT hr;

    if (!AllocConsole())
    {
        MessageBoxA(NULL, "failed to init console", "failure", MB_OK);
        return 1;
    }
    FILE* fDummy;
    freopen_s(&fDummy, "CONIN$", "r", stdin);
    freopen_s(&fDummy, "CONOUT$", "w", stderr);
    freopen_s(&fDummy, "CONOUT$", "w", stdout);

    CLRCreateInstance(CLSID_CLRMetaHost, IID_ICLRMetaHost, ((LPVOID*)&meta_host));
    meta_host->GetRuntime(L"v4.0.30319", IID_ICLRRuntimeInfo, (LPVOID*)&runtime_info);
    runtime_info->GetInterface(CLSID_CLRRuntimeHost, IID_ICLRRuntimeHost, (LPVOID*)&runtime_host);
    ICLRControl* pCLRControl = nullptr;
    hr = runtime_host->GetCLRControl(&pCLRControl);

    MinimalHostControl* host_control = host_control = new MinimalHostControl();
    hr = runtime_host->SetHostControl(host_control);

    LPCWSTR assemblyName = L"VRCLoader";
    LPCWSTR appDomainManagerTypename = L"VRCLoader.Domain.DomainManager";
    hr = pCLRControl->SetAppDomainManagerType(assemblyName, appDomainManagerTypename);
    runtime_host->Start();

    INetDomain* net_domain = host_control->GetDomainManagerForDefaultDomain();

    net_domain->Initialize();

    net_domain->MinHook_CreateInstance(
        MH_CreateHook,
        MH_RemoveHook,
        MH_EnableHook,
        MH_DisableHook);

    net_domain->OnApplicationStart();

    

    runtime_info->Release();
    meta_host->Release();
    runtime_host->Release();
    net_domain->Release();

    return 0;
}


BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
        main();
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

