using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Model
{
    class Message 
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
    }
}
