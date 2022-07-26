using ChatClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ChatClient.Selector
{
    public class MessageTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TextMessageDataTemplate { get; set; }
        public DataTemplate ImageMessageDataTemplate { get; set; }
        public DataTemplate FileMessageDataTemplate { get; set; }
        public DataTemplate AudioRequestDataTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Message msg = (Message)item;
            if(msg.Type == "text")
            {
                return TextMessageDataTemplate;
            }
            else if(msg.Type == "image")
            {
                return ImageMessageDataTemplate;
            }
            else if(msg.Type == "audio")
            {
                return AudioRequestDataTemplate;
            }
            else
            {
                return FileMessageDataTemplate;
            }
        }
    }
}
