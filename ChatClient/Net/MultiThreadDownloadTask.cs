using ChatClient.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Net
{
    class MultiThreadDownloadTask
    {
        int threadCount = 8;
        int finished = 0;
        SingleDownloadTask[] tasks;
        string url;
        string fileName;
        public void Prepare(string url, string fileName)
        {
            long size = GetFileSize(url);
            this.url = url;
            this.fileName = fileName;
            tasks = new SingleDownloadTask[threadCount];
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
        }

        public void DownloadFiles(ObservableCollection<BackgroundTask> backgroundTasks, BackgroundTask mergeTask, int index)
        {
            for(int i = 0;  i< tasks.Length; i++)
            {
                var task = tasks[i];
                var background = backgroundTasks[index + i];
                Task.Run(() =>
                {
                    
                    DownloadFileBlock(task, url);
                    background.Status = "finished";
                    finished++;
                    if (finished == threadCount)
                    {
                        finished++;
                        MergeFile(tasks, mergeTask);
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
            Console.WriteLine("downoading" + param.Begin);
            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            req.AddRange(param.Begin, param.End);
            var rep = req.GetResponse() as HttpWebResponse;
            var stream = rep.GetResponseStream();
            byte[] bytes = new byte[1024];
            var fileStream = new FileStream("temp\\" + fileName + param.ID, FileMode.Create);
            while (true)
            {
                int count = stream.Read(bytes, 0, bytes.Length);
                if (count <= 0)
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

        public void MergeFile(SingleDownloadTask[] tasks, BackgroundTask backgroundTask)
        {
            backgroundTask.Status = "merging";
            var outStream = new FileStream("files\\" + fileName, FileMode.Create);
            FileStream inStream;
            byte[] bytes = new byte[1024];
            for (int i = 0; i < tasks.Length; i++)
            {
                inStream = new FileStream("file" + i, FileMode.Open);
                while (true)
                {
                    int count = inStream.Read(bytes, 0, bytes.Length);
                    if (count <= 0)
                    {
                        break;
                    }
                    outStream.Write(bytes, 0, count);
                }
                inStream.Close();
            }
            outStream.Close();
            backgroundTask.Status = "finished";
        }
    }
}
