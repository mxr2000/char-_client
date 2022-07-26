using ChatClient.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.ViewModel
{
    class MessageHistoryViewModel : Notifier
    {
        private ObservableCollection<Message> messages;

        public ObservableCollection<Message> Messages
        {
            get { return messages; }
            set
            {
                messages = value;
                this.OnPropertyChanged("Messages");
            }
        }


        private Contact contact;

        public Contact Contact
        {
            get { return contact; }
            set
            {
                contact = value;
                Messages = contact.HistoryMessages;
                this.OnPropertyChanged("Contact");
            }
        }


    }
}
