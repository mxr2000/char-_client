using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace StyleTest
{
    class CustomDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TextTemplate { get; set; }
        public DataTemplate ImageTemplate { get; set; }
        public DataTemplate FileTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Message msg = (Message)item;
            if(msg.Type == "text")
            {
                return TextTemplate;
            }else if(msg.Type == "image")
            {
                return ImageTemplate;
            }
            else
            {
                return FileTemplate;
            }
        }
    }
}
