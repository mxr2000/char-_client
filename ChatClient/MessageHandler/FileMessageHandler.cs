using ChatClient.Model;
using ChatClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.MessageHandler
{
    class FileMessageHandler : IMessageHandler
    {
        private MainWindowViewModel vm;
        public FileMessageHandler(MainWindowViewModel vm)
        {
            this.vm = vm;
        }
        public void handle(Message message)
        {
            vm.ContactsViewModel.AddMessage(message, false);
        }
    }
}
