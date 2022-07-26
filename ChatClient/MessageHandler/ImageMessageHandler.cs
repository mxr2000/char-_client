using ChatClient.Model;
using ChatClient.Net;
using ChatClient.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.MessageHandler
{
    class ImageMessageHandler : IMessageHandler
    {
        private MainWindowViewModel vm;
        DownloadFileRequest downloadFileRequest = new DownloadFileRequest();
        public ImageMessageHandler(MainWindowViewModel vm)
        {
            this.vm = vm;
        }
        public void handle(Message message)
        {
            string fileName = message.Content;
            if(!File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "\\images\\" + fileName))
            {
                downloadFileRequest.DownloadFile(fileName, System.AppDomain.CurrentDomain.BaseDirectory + "\\images\\" + fileName);
                vm.ContactsViewModel.AddMessage(message, false);
            }
            vm.ContactsViewModel.AddMessage(message, false);
        }
    }
}
