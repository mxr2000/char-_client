using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ChatClient.Model;
using Newtonsoft.Json;

namespace ChatClient.Net
{
    class UserRequest
    {
        public async Task<User> Login(string username, string password)
        {
            var client = new HttpClient();
            LoginUser user = new LoginUser() { username = username, password = password };
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            string url = NetUtil.ServerURL + "/login";
            Console.WriteLine(url);
            var response = await client.PostAsync(url, data);
            string result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<User>(result, NetUtil.CamelCase);
        }
    }
}
