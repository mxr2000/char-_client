using ChatClient.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.ViewModel
{
    class TalksViewModel : Notifier
    {
        public TalksViewModel()
        {
            /*Contact u1 = new Contact()
            {
                Name = "Miao"
            };
            ObservableCollection<Message> u1m = new ObservableCollection<Message>();
            u1m.Add(new Message() { Content = "a"});
            u1m.Add(new Message() { Content = "b" });
            u1m.Add(new Message() { Content = "c" });
            u1.HistoryMessages = u1m;

            Contact u2 = new Contact()
            {
                Name = "Miao"
            };
            ObservableCollection<Message> u2m = new ObservableCollection<Message>();
            u2m.Add(new Message() { Content = "aa" });
            u2m.Add(new Message() { Content = "bb" });
            u2m.Add(new Message() { Content = "cc" });
            u2.HistoryMessages = u2m;

            Contacts = new ObservableCollection<Contact>();
            Contacts.Add(u1);
            Contacts.Add(u2);*/
        }
        
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
        public MessageHistoryViewModel MessageHistoryViewModel { get; protected set; } = new MessageHistoryViewModel();
        private Dictionary<string, Contact> contactsDict = new Dictionary<string, Contact>();
        public bool AddTalk(Message message)
        {
            string sender = message.Sender;
            if (contactsDict.ContainsKey(sender))
            {
                contactsDict[sender].HistoryMessages.Add(message);
                return true;
            }
            return false;
        }
        public bool AddSelfMessage(Message message)
        {
            string receiver = message.Receiver;
            if (contactsDict.ContainsKey(receiver))
            {
                contactsDict[receiver].HistoryMessages.Add(message);
                return true;
            }
            return false;
        }
        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
            contactsDict[contact.Username] = contact;
        }

        public int SelectedIndex
        {
            set
            {
                if(value >= 0 && value < Contacts.Count)
                {
                    Console.WriteLine(value);
                    MessageHistoryViewModel.Contact = Contacts[value];
                    Console.WriteLine();
                }
            }
        }

        private string _inputContent;

        public string InputContent
        {
            get { return _inputContent; }
            set
            {
                _inputContent = value;
                this.OnPropertyChanged("InputContent");
            }
        }


    }
}
