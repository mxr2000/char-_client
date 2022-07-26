using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Model
{
    class ContactAdminMessage : Notifier
    {
        private string _username;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                this.OnPropertyChanged("Username");
            }
        }

        private string _type;

        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                this.OnPropertyChanged("Type");
            }
        }



    }
}
