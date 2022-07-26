using ChatClient.Model;
using ChatClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.MessageHandler
{
    class TalkMessageHandler : IMessageHandler
    {
        private MainWindowViewModel vm;
        public TalkMessageHandler(MainWindowViewModel vm)
        {
            this.vm = vm;
        }
        public void handle(Message message)
        {
            string username = message.Sender;
            vm.ContactsViewModel.AddMessage(message, false);
        }
    }
}
