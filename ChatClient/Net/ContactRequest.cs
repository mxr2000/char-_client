using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using ChatClient.Model;

namespace ChatClient.Net
{
    class ContactRequest
    {
        public async Task<List<Contact>> GetAllContacts(string username)
        {
            string url = NetUtil.ServerURL + "/acquireallcontacts/" + username;
            var response = await NetUtil.Client.GetAsync(url);
            string result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<Contact>>(result, NetUtil.CamelCase);
        }

        
    }
}
