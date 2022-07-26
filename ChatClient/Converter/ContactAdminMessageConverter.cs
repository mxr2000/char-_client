using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ChatClient.Converter
{
    [ValueConversion(typeof(string), typeof(string))]
    public class ContactAdminMessageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string type = (string)value;
            if(type == "usernotfound")
            {
                return "用户未找到";
            }
            else if(type == "requestrejected")
            {
                return "拒绝了你的请求";
            }
            else if(type == "requestpassed")
            {
                return "同意了你的请求";
            }
            else
            {
                return "未知类型消息";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
