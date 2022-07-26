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
    class OpenAudioChatWindowCommand : ICommand
    {
        MainWindowViewModel vm;
        AudioRequest audioRequest = new AudioRequest();
        AudioModule module = new AudioModule();
        public OpenAudioChatWindowCommand(MainWindowViewModel vm)
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
            string sender = vm.User.Username;
            string receiver = vm.ContactsViewModel.TalksViewModel.MessageHistoryViewModel.Contact.Username;
            audioRequest.SendRequest(sender, receiver);

            module.BeginMonitoring(0);
        }
    }
}
