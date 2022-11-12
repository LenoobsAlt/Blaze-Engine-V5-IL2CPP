using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace BE4v.Mods.API
{
    public static class Core
    {
        public static string Request(string url, NameValueCollection collection = null)
        {
            string result = string.Empty;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = _api_url;
                if (collection == null)
                    collection = new NameValueCollection();

                collection.Add("if-key", License.GetLicense);

                byte[] bytes = webClient.UploadValues(url, collection);
                result = Encoding.UTF8.GetString(bytes);
            }
            if (!string.IsNullOrEmpty(result))
            {
                if (result[0] == '\n')
                    result.Remove(0, 1);
            }
            return result;
        }

        public static string _api_url = "https://client.icefrag.ru/";
    }
}
