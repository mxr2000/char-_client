using ChatClient.Model;
using ChatClient.Net;
using ChatClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatClient.Command
{
    class SendMessageCommand : ICommand
    {
        private MainWindowViewModel vm;
        private MessageRequest messageRequest = new MessageRequest();
        public SendMessageCommand(MainWindowViewModel vm)
        {
            this.vm = vm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string content = vm.ContactsViewModel.TalksViewModel.InputContent;
            string sender = vm.User.Username;
            string receiver = vm.ContactsViewModel.TalksViewModel.MessageHistoryViewModel.Contact.Username;
            string type = "text";
            Message message = new Message()
            {
                Sender = sender,
                Receiver = receiver,
                Type = type,
                Content = content
            };
            messageRequest.SendMessage(message);
            vm.ContactsViewModel.AddMessage(message, true);
        }
    }
}
