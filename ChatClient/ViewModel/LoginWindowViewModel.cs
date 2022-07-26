using ChatClient.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatClient.ViewModel
{
    class LoginWindowViewModel : Notifier
    {
        private string _username = "mxr";

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                this.OnPropertyChanged("Username");
            }
        }
        private string _password = "123456";

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                this.OnPropertyChanged("Password");
            }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                this.OnPropertyChanged("Name");
            }
        }
        private string _imagePath;

        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;
                this.OnPropertyChanged("ImagePath");
            }
        }
        private string _errotInfo;

        public string ErrorInfo
        {
            get { return _errotInfo; }
            set
            {
                _errotInfo = value;
                this.OnPropertyChanged("ErrorInfo");
            }
        }

        public ICommand LoginCommand { get; set; }

        public LoginWindowViewModel()
        {
            LoginCommand = new LoginCommand(this);
        }

    }
}
