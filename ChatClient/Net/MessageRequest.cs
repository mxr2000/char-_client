using ChatClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;

namespace ChatClient.Net
{
    class MessageRequest
    {
        
        public async void SendMessage(Message message)
        {
            string url = NetUtil.ServerURL + "/sendmessage";
            var data = NetUtil.GetStringContent(JsonConvert.SerializeObject(message, NetUtil.CamelCase));
            var response = await NetUtil.Client.PostAsync(url, data);
        }
        public async Task<List<Message>> GetUnhandledHistoryMessages(string username)
        {
            string url = NetUtil.ServerURL + "/acquireunhandledmessages/" + username;
            var response = await NetUtil.Client.GetAsync(url);
            string result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<Message>>(result, NetUtil.CamelCase);
        }

        public async Task<List<Message>> GetHistoryMessages(string username)
        {
            string url = NetUtil.ServerURL + "/acquirehistorymessages/" + username;
            var response = await NetUtil.Client.GetAsync(url);
            string result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<Message>>(result, NetUtil.CamelCase);
        }
        public async Task<List<Message>> GetHistoryMessagesWithContact(string user1, string user2)
        {
            string url = NetUtil.ServerURL + "/acquirehistorymessageswithcontact/" + user1 + "/" + user2;
            var response = await NetUtil.Client.GetAsync(url);
            string result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<Message>>(result, NetUtil.CamelCase);
        }


    }
}
