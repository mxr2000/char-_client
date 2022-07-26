using ChatClient.Model;
using ChatClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.MessageHandler
{
    class ContactOnlineHandler : IMessageHandler
    {
        private MainWindowViewModel vm;
        public ContactOnlineHandler(MainWindowViewModel vm)
        {
            this.vm = vm;
        }
        public void handle(Message message)
        {
            Console.WriteLine(message.Sender + " has just been online");
        }
    }
}
