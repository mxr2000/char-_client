using ChatClient.Command;
using ChatClient.MessageHandler;
using ChatClient.Model;
using ChatClient.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace ChatClient.ViewModel
{
    class MainWindowViewModel : Notifier
    {
        public MainWindowViewModel()
        {
            messageHandlers["text"] = new TalkMessageHandler(this);
            messageHandlers["contactonlie"] = new ContactOnlineHandler(this);
            messageHandlers["contactoffline"] = new ContactOfflineHandler(this);
            messageHandlers["image"] = new ImageMessageHandler(this);
            messageHandlers["file"] = new FileMessageHandler(this); 

            SendMessageCommand = new SendMessageCommand(this);
            UploadFileCommand = new UploadFileCommand(this);
            UploadImageCommand = new UploadImageCommand(this);
            DownloadFileCommand = new DownloadFileCommand(this);
            MultiThreadDownloadFileCommand = new MultiThreadDownloadFileCommand(this);
            LoadHistoryCommand = new LoadHistoryCommand(this);
            OpenAudioChatWindowCommand = new OpenAudioChatWindowCommand(this);
        }
        private User user;

        public User User
        {
            get { return user; }
            set
            {
                user = value;
                this.OnPropertyChanged("User");
                ContactsViewModel.contactsDict[user.Username] = new Contact
                {
                    Username = user.Username,
                    Name = user.Name,
                    ImgFormat = user.ImgFormat
                };
            }
        }

        //public TalksViewModel TalksViewModel { get; protected set; } = new TalksViewModel();
        public ContactsViewModel ContactsViewModel { get; protected set; } = new ContactsViewModel();
        public BackgroundTaskViewModel BackgroundTaskViewModel { get; protected set; } = new BackgroundTaskViewModel();
        public ContactAdminViewModel ContactAdminViewModel { get; protected set; } = new ContactAdminViewModel();

        public Dictionary<string, IMessageHandler> messageHandlers = new Dictionary<string, IMessageHandler>();
        public void StartHeartbeatTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }

        public async void GetAllContacts()
        {
            var contacts = await contactRequest.GetAllContacts(User.Username);
            foreach(var con in contacts)
            {
                ContactsViewModel.AddContact(con);
            }
        }

        public async void GetAllUnhandledHistoryMessages()
        {
            var msgs = await messageRequest.GetUnhandledHistoryMessages(user.Username);
            foreach(var msg in msgs)
            {
                if(msg.Sender == user.Username)
                {
                    ContactsViewModel.AddMessage(msg, true);
                }
                else
                {
                    ContactsViewModel.AddMessage(msg, false);
                }
                
            }
        }

        HeartbeatRequest heartbeatRequest = new HeartbeatRequest();
        ContactRequest contactRequest = new ContactRequest();
        MessageRequest messageRequest = new MessageRequest();
        private async void Timer_Tick(object sender, EventArgs e)
        {
            var messages = await heartbeatRequest.Heartbeat(user.Username);
            foreach(var msg in messages)
            {
                messageHandlers[msg.Type].handle(msg);
            }
        }

        public ICommand SendMessageCommand { get; set; }
        public ICommand UploadImageCommand { get; set; }
        public ICommand UploadFileCommand { get; set; }
        public ICommand DownloadFileCommand { get; set; }
        public ICommand MultiThreadDownloadFileCommand { get; set; }
        public ICommand LoadHistoryCommand { get; set; }
        public ICommand OpenAudioChatWindowCommand { get; set; }
    }
}
