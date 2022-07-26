using ChatClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.MessageHandler
{
    interface IMessageHandler
    {
        void handle(Message message);
    }
}
