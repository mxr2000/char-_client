using ChatClient.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.ViewModel
{
    class BackgroundTaskViewModel : Notifier
    {
        public ObservableCollection<BackgroundTask> BackgroundTasks { get; protected set; } = new ObservableCollection<BackgroundTask>();

    }
}
