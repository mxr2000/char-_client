using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Net
{
    class AudioRequest
    {
        public void SendRequest(string sender, string receiver)
        {
            string url = NetUtil.ServerURL + "/testaudio/" + sender + "/" + receiver;
             NetUtil.Client.GetAsync(url);

        }
    }
}
