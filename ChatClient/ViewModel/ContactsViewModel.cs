using ChatClient.Model;
using ChatClient.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.ViewModel
{
    class ContactsViewModel : Notifier
    {
        public ObservableCollection<Contact> Contacts { get; protected set; } = new ObservableCollection<Contact>();
        public Dictionary<string, Contact> contactsDict { get; set; } = new Dictionary<string, Contact>();
        public ContactRequest contactRequest = new ContactRequest();
        public TalksViewModel TalksViewModel { get; protected set; } = new TalksViewModel();
        public int SelectedIndex
        {
            set
            {
                if(value >= 0 && value < Contacts.Count)
                {
                    Contact contact = Contacts[value];
                    if (!TalksViewModel.Contacts.Contains(contact))
                    {
                        TalksViewModel.AddContact(contact);
                    }
                    TalksViewModel.MessageHistoryViewModel.Contact = contact;
                }
            }
        }

        public async void LoadContacts(string username)
        {
            var results = await contactRequest.GetAllContacts(username);
            foreach(var contact in results)
            {
                Contacts.Add(contact);
            }
        }

        public void AddMessage(Message message, bool self)
        {
            if (self)
            {
                if (!TalksViewModel.AddSelfMessage(message))
                {
                    TalksViewModel.AddContact(contactsDict[message.Receiver]);
                    TalksViewModel.AddSelfMessage(message);
                }
            }
            else
            {
                if (!TalksViewModel.AddTalk(message))
                {
                    TalksViewModel.AddContact(contactsDict[message.Sender]);
                    TalksViewModel.AddTalk(message);
                }
            }
            
        }


        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
            contactsDict[contact.Username] = contact;
        }
    }
}
