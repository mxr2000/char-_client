using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Net
{
    class NetUtil
    {
        public static string ServerURL = "http://127.0.0.1:8080";
        public static string FileServerURL = "http://39.104.25.156/files";
        public static JsonSerializerSettings CamelCase = new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() };
        public static HttpClient Client = new HttpClient();
        public static StringContent GetStringContent(String json)
        {
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
