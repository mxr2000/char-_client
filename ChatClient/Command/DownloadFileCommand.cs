using ChatClient.Net;
using ChatClient.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatClient.Command
{
    class DownloadFileCommand : ICommand
    {
        MainWindowViewModel vm;
        DownloadFileRequest downloadFileRequest = new DownloadFileRequest();
        int index;
        public DownloadFileCommand(MainWindowViewModel vm)
        {
            this.vm = vm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            string fileName = (string)parameter;
            string filePath = "files\\" + fileName;
            if (!File.Exists(filePath))
            {
                index = vm.BackgroundTaskViewModel.BackgroundTasks.Count;
                vm.BackgroundTaskViewModel.BackgroundTasks.Add(new Model.BackgroundTask()
                {
                    Description = fileName,
                    Status = "downloading"
                });
                downloadFileRequest.DownloadFile(fileName, filePath);
                vm.BackgroundTaskViewModel.BackgroundTasks[index].Status = "finished";
            }

        }
    }
}
