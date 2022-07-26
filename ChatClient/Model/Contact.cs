using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Model
{
    class Contact : Notifier
    {
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

        private string _username;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                this.OnPropertyChanged("Username");
                this.OnPropertyChanged("ImagePath");
            }
        }

        public string ImgFormat { get; set; }

        private ObservableCollection<Message> messages = new ObservableCollection<Message>();

        public ObservableCollection<Message> HistoryMessages
        {
            get { return messages; }
            set
            {
                messages = value;
                this.OnPropertyChanged("HistoryMessages");
            }
        }

        public string ImagePath
        {
            get
            {
                return "pack://SiteOfOrigin:,,,/chat_" + Username + "." + ImgFormat;
            }
        }

        private int _unseenMessageCount;

        public int UnseenMessageCount
        {
            get { return _unseenMessageCount; }
            set
            {
                _unseenMessageCount = value;
                this.OnPropertyChanged("UnseenMessageCount");
            }
        }

    }
}
