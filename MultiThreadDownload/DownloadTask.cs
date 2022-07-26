using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadDownload
{
    class DownloadTask
    {
        public void Download()
        {
            int threadCount = 8;
            int finished = 0;
            string url = "http://39.104.25.156/images/default.jpg";
            long size = GetFileSize(url);
            SingleDownloadTask[] tasks = new SingleDownloadTask[threadCount];
            int singleSize = (int)(size / 8);
            for (int i = 0; i < threadCount; i++)
            {
                tasks[i] = new SingleDownloadTask()
                {
                    ID = i,
                    Begin = singleSize * i,
                    End = (i == threadCount - 1 ? (int)size - 1 : singleSize * (i + 1)) - 1
                };
            }
            foreach(var task in tasks)
            {
                Task.Run(() =>
                {
                    DownloadFileBlock(task, url);
                    finished++;
                    if(finished == threadCount)
                    {
                        finished++;
                        MergeFile(tasks);
                    }
                });
            }
        }

        long GetFileSize(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "HEAD";

            HttpWebResponse rep = (HttpWebResponse)req.GetResponse();
            long size = rep.ContentLength;
            rep.Close();
            return size;
        }

        public void DownloadFileBlock(SingleDownloadTask param, string url)
        {
            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            req.AddRange(param.Begin, param.End);
            var rep = req.GetResponse() as HttpWebResponse;
            var stream = rep.GetResponseStream();
            byte[] bytes = new byte[1024];
            var fileStream = new FileStream("file" + param.ID, FileMode.Create);
            while (true)
            {
                int count = stream.Read(bytes, 0, bytes.Length);
                if(count <= 0)
                {
                    break;
                }
                fileStream.Write(bytes, 0, count);
            }
            fileStream.Close();
            stream.Close();
            rep.Close();
            req.Abort();
        }

        public void MergeFile(SingleDownloadTask[] tasks)
        {
            var outStream = new FileStream("file.jpg", FileMode.Create);
            FileStream inStream;
            byte[] bytes = new byte[1024];
            for(int i = 0; i < tasks.Length; i++)
            {
                inStream = new FileStream("file" + i, FileMode.Open);
                while (true)
                {
                    int count = inStream.Read(bytes, 0, bytes.Length);
                    if(count <= 0)
                    {
                        break;
                    }
                    outStream.Write(bytes, 0, count);
                }
                inStream.Close();
            }
            outStream.Close();
        }
    }
}
