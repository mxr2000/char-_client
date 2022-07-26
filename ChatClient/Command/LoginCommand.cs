using ChatClient.Converter;
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
    class LoginCommand : ICommand
    {
        LoginWindowViewModel vm;
        UserRequest userRequest = new UserRequest();
        
        public LoginCommand(LoginWindowViewModel vm)
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
            User user = await userRequest.Login(vm.Username, vm.Password);
            if(user != null)
            {
                MainWindow mainWindow = new MainWindow();
                MainWindowViewModel mainWindowViewModel = new MainWindowViewModel()
                {
                    User = user
                };
                mainWindowViewModel.StartHeartbeatTimer();
                mainWindowViewModel.GetAllContacts();
                mainWindowViewModel.GetAllUnhandledHistoryMessages();
                ImagePathConverter.dict = mainWindowViewModel.ContactsViewModel.contactsDict;
                mainWindow.DataContext = mainWindowViewModel;
                mainWindow.Show();
            }
            else
            {
                vm.ErrorInfo = "Log in failed";
            }
        }
    }
}
