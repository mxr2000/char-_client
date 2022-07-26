using ChatClient.Model;
using ChatClient.Net;
using ChatClient.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatClient.Command
{
    class UploadImageCommand : ICommand
    {
        private MainWindowViewModel vm;
        private UploadRequest uploadRequest = new UploadRequest();
        private DownloadFileRequest downloadFileRequest = new DownloadFileRequest();
        private MessageRequest messageRequest = new MessageRequest();
        public UploadImageCommand(MainWindowViewModel vm)
        {
            this.vm = vm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "*.png|*.jpg";
            dialog.ShowDialog();
            Console.WriteLine(dialog.FileName);

            string content = vm.ContactsViewModel.TalksViewModel.InputContent;
            string sender = vm.User.Username;
            string receiver = vm.ContactsViewModel.TalksViewModel.MessageHistoryViewModel.Contact.Username;
            string type = "image";

            if (dialog.FileName.Length == 0)
                return;
            string[] ret = dialog.FileName.Split('\\');
            string fileName = ret[ret.Length - 1];

            uploadRequest.UploadFile(dialog.FileName, fileName);
            Message message = new Message()
            {
                Sender = sender,
                Receiver = receiver,
                Content = fileName,
                Type = type
            };
            messageRequest.SendMessage(message);

            if(!File.Exists("images\\" + fileName)){
                File.Copy(dialog.FileName, System.AppDomain.CurrentDomain.BaseDirectory + "\\images\\" + fileName);
                //downloadFileRequest.DownloadFile(fileName, "images\\" + fileName);
            }

            vm.ContactsViewModel.AddMessage(message, true);
        }
    }
}
