#pragma once
#include <mscoree.h>


struct __declspec(uuid("E86B87C8-5FC2-442E-A2AB-EAB2E594FEAE")) INetDomain : IUnknown
{
    virtual void Initialize();
    virtual void OnApplicationStart();
    virtual void MinHook_CreateInstance(LPVOID mVRC_CreateHook, LPVOID mVRC_RemoveHook, LPVOID mVRC_EnableHook, LPVOID mVRC_DisableHook);
};


class MinimalHostControl : public IHostControl
{
public:
    MinimalHostControl()
    {
        m_refCount = 0;
        m_defaultDomainManager = NULL;
    }
    virtual ~MinimalHostControl()
    {
        if (m_defaultDomainManager != nullptr)
        {
            m_defaultDomainManager->Release();
        }
    }
    INetDomain* GetDomainManagerForDefaultDomain()
    {
        if (m_defaultDomainManager)
        {
            m_defaultDomainManager->AddRef();
        }
        return m_defaultDomainManager;
    }
    HRESULT STDMETHODCALLTYPE GetHostManager(REFIID riid, void** ppv)
    {
        *ppv = NULL;
        return E_NOINTERFACE;
    }

    HRESULT STDMETHODCALLTYPE SetAppDomainManager(DWORD dwAppDomainID, IUnknown* pUnkAppDomainManager)
    {
        HRESULT hr = S_OK;
        hr = pUnkAppDomainManager->QueryInterface(__uuidof(INetDomain), (PVOID*)&m_defaultDomainManager);
        return hr;
    }
    HRESULT STDMETHODCALLTYPE QueryInterface(const IID& iid, void** ppv)
    {
        if (!ppv) return E_POINTER;
        *ppv = this;
        AddRef();
        return S_OK;
    }
    ULONG STDMETHODCALLTYPE AddRef()
    {
        return InterlockedIncrement(&m_refCount);
    }
    ULONG STDMETHODCALLTYPE Release()
    {
        if (InterlockedDecrement(&m_refCount) == 0)
        {
            delete this;
            return 0;
        }
        return m_refCount;
    }
private:
    long m_refCount;
    INetDomain* m_defaultDomainManager;
};
