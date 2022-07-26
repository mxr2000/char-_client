using ChatClient.Model;
using ChatClient.Net;
using ChatClient.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatClient
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();

            //UserRequest request = new UserRequest();
            //request.Login("a", "b");

            this.DataContext = new MainWindowViewModel();
        }



        private async void Print()
        {
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://39.104.25.156/");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        private async void DownloadPicture()
        {
            HttpClient client = new HttpClient();
            FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\image.jpg", FileMode.CreateNew);
            byte[] bytes = await client.GetByteArrayAsync("http://39.104.25.156/images/default.jpg");
            fs.Write(bytes, 0, bytes.Length);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ChangeText();
        }

        private async void ChangeText()
        {
            await Task.Run(()=>
            {
                Thread.Sleep(10000);
            });
            btnAdd.Content = "a";
        }
    }
}
