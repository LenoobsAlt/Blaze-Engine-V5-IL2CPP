using System;
using IL2CPP_Core.Objects;

namespace System.Net
{
    public class IL2WebClient : IL2Object
    {
		public IL2WebClient(IntPtr ptr) : base(ptr) { }
		public IL2WebClient() : base(IntPtr.Zero)
		{
			Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
			Instance_Class.GetMethod(".ctor").Invoke(Pointer);
		}

		public IntPtr DownloadData(string address)
		{
			ClearWebClientState();
			IntPtr result;
			try
			{
				IL2WebRequest webRequest;
				result = DownloadDataInternal(address, out webRequest);
			}
			finally
			{
				CompleteWebClientState();
			}
			return result;
		}

		private IntPtr DownloadDataInternal(string address, out IL2WebRequest request)
		{
			request = null;
			IntPtr result;
			try
			{
				IntPtr uri = GetUri(address);
				request = GetWebRequest(uri);
				result = DownloadBits(request);
			}
			catch (Exception ex)
			{
				AbortRequest(request);
				throw ex;
			}
			return result;
		}

		private void ClearWebClientState()
		{
			Instance_Class.GetMethod(nameof(ClearWebClientState)).Invoke(this);
		}

		private void CompleteWebClientState()
		{
			Instance_Class.GetMethod(nameof(CompleteWebClientState)).Invoke(this);
		}

		// More: , Stream writeStream, CompletionDelegate completionDelegate, AsyncOperation asyncOp
		private IntPtr DownloadBits(IL2WebRequest request)
		{
			return Instance_Class.GetMethod(nameof(DownloadBits)).Invoke(this, new IntPtr[] { request.Pointer, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, }).Pointer;
		}

		private IL2WebRequest GetWebRequest(IntPtr address)
		{
			return Instance_Class.GetMethod(nameof(GetWebRequest)).Invoke(this, new IntPtr[] { address })?.GetValue<IL2WebRequest>();
		}

		private IntPtr GetUri(string path)
		{
			return Instance_Class.GetMethod(nameof(GetUri), x => x.GetParameters()[0].Name == "path").Invoke(this, new IntPtr[] { new IL2String_utf16(path).Pointer }).Pointer;
		}

		private static void AbortRequest(IL2WebRequest request)
		{
			IntPtr ptr = IntPtr.Zero;
			if (request != null)
				ptr = request.Pointer;

			Instance_Class.GetMethod(nameof(AbortRequest)).Invoke(new IntPtr[] { ptr });
		}

		public static IL2Class Instance_Class = IL2CPP.AssemblyList["System"].GetClass("WebClient", "System.Net");
    }
}
