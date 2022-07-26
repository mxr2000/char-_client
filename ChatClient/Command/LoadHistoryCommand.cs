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
    class LoadHistoryCommand : ICommand
    {
        MainWindowViewModel vm;
        MessageRequest messageRequest = new MessageRequest();
        public LoadHistoryCommand(MainWindowViewModel vm)
        {
            this.vm = vm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            string user1 = vm.User.Username;
            string user2 = vm.ContactsViewModel.TalksViewModel.MessageHistoryViewModel.Contact.Username;
            var list = await
                messageRequest.GetHistoryMessagesWithContact(user1, user2);

            vm.ContactsViewModel.TalksViewModel.MessageHistoryViewModel.Contact.HistoryMessages.Clear();
            foreach(var item in list)
            {
                vm.ContactsViewModel.TalksViewModel.MessageHistoryViewModel.Contact.HistoryMessages.Add(item);
            }
        }
    }
}
