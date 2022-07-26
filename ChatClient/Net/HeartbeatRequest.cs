using ChatClient.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Net
{
    class HeartbeatRequest
    {
        public async Task<List<Message>> Heartbeat(string username)
        {
            string url = NetUtil.ServerURL + "/heartbeat/" + username;
            var response = await NetUtil.Client.GetAsync(url);
            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            return JsonConvert.DeserializeObject<List<Message>>(result, NetUtil.CamelCase);
        }
    }
}
