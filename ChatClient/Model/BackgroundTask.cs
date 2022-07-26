using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Model
{
    class BackgroundTask : Notifier
    {
        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                this.OnPropertyChanged("Description");
            }
        }

        private string _status;

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                this.OnPropertyChanged("Status");
            }
        }


    }
}
