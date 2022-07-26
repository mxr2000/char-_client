using ChatClient.Model;
using ChatClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.MessageHandler
{
    class ContactOfflineHandler : IMessageHandler
    {
        private MainWindowViewModel vm;
        public ContactOfflineHandler(MainWindowViewModel vm)
        {
            this.vm = vm;
        }

        public void handle(Message message)
        {
            
        }
    }
}
