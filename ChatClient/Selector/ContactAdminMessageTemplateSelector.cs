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
    class ContactAdminMessageTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ReplyDataTemplate { get; set; }
        public DataTemplate PlainDataTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            ContactAdminMessage msg = (ContactAdminMessage)item;
            if(msg.Type == "request")
            {
                return ReplyDataTemplate;
            }
            else
            {
                return PlainDataTemplate;
            }
        }
    }
}
