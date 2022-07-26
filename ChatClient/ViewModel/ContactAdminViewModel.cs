using ChatClient.Command;
using ChatClient.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatClient.ViewModel
{
    class ContactAdminViewModel : Notifier
    {
        public ContactAdminViewModel()
        {
            RequestAddContactCommand = new RequestAddContactCommand(this);
        }
        public ObservableCollection<ContactAdminMessage> ContactAdminMessages { get; set; } = new ObservableCollection<ContactAdminMessage>();
        public ICommand RequestAddContactCommand { get; set; }
        private string _contactUsername;

        public string ContactUsername
        {
            get { return _contactUsername; }
            set
            {
                _contactUsername = value;
                this.OnPropertyChanged("ContactUsername");
            }
        }
        

    }
}
