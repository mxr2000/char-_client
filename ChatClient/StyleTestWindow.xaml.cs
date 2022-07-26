using ChatClient.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChatClient
{
    /// <summary>
    /// StyleTestWindow.xaml 的交互逻辑
    /// </summary>
    public partial class StyleTestWindow  
    {
        public StyleTestWindow()
        {
            InitializeComponent();
            ObservableCollection<Contact> contacts = new ObservableCollection<Contact>();
            Contact c1 = new Contact()
            {
                Username = "mxr",
                Name = "Miao Xinrun",
                ImgFormat = "png",
                UnseenMessageCount = 10
            };
            Contact c2 = new Contact()
            {
                Username = "mxr",
                Name = "Miao Xinrun",
                ImgFormat = "png",
                UnseenMessageCount = 10
            };
            Contact c3 = new Contact()
            {
                Username = "mxr",
                Name = "Miao Xinrun",
                ImgFormat = "png",
                UnseenMessageCount = 10
            };
            contacts.Add(c1);
            contacts.Add(c2);
            contacts.Add(c3);
            lb.ItemsSource = contacts;
            

            ObservableCollection<BackgroundTask> tasks = new ObservableCollection<BackgroundTask>();
            BackgroundTask task1 = new BackgroundTask() { Description = "file1.xml", Status = "downloading" };
            BackgroundTask task2 = new BackgroundTask() { Description = "file2.xml", Status = "downloading" };
            BackgroundTask task3 = new BackgroundTask() { Description = "file3.xml", Status = "downloading" };
            BackgroundTask task4 = new BackgroundTask() { Description = "mere file.xml", Status = "waiting" };
            tasks.Add(task1);
            tasks.Add(task2);
            tasks.Add(task3);
            tasks.Add(task4);
            lbMessages.ItemsSource = tasks;
        }
    }
}
