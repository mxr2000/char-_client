using ChatClient.Model;
using ChatClient.Net;
using ChatClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatClient.Command
{
    class MultiThreadDownloadFileCommand : ICommand
    {
        private MainWindowViewModel vm;
        public MultiThreadDownloadFileCommand(MainWindowViewModel vm)
        {
            this.vm = vm;
        }
        public event EventHandler CanExecuteChanged;
        int index;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string fileName = (string)parameter;
            index = vm.BackgroundTaskViewModel.BackgroundTasks.Count;
            for(int i = 0; i < 8; i++)
            {
                vm.BackgroundTaskViewModel.BackgroundTasks.Add(new Model.BackgroundTask()
                {
                    Description = fileName + "-part" + (i + 1),
                    Status = "unfinished"
                });
            }
            BackgroundTask mergeTask;
            vm.BackgroundTaskViewModel.BackgroundTasks.Add(mergeTask = new Model.BackgroundTask()
            {
                Description = fileName + "-merge",
                Status = "waiting"
            });
            MultiThreadDownloadTask task = new MultiThreadDownloadTask();
            task.Prepare(NetUtil.FileServerURL + "/" + fileName, fileName);
            task.DownloadFiles(vm.BackgroundTaskViewModel.BackgroundTasks, mergeTask, index);
        }
    }
}
