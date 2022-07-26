using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadDownload
{
    class SingleDownloadTask
    {
        public int ID { get; set; }
        public int Begin { get; set; }
        public int End { get; set; }
        public int Length { get { return End - Begin; } }

    }
}
