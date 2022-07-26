using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Model
{
    class AudioModule
    {
        WaveIn waveIn;
        WaveOut waveOut;
        BufferedWaveProvider waveProvider;
        bool goon = false;

        UdpClient udpSender;
        UdpClient receiver;
        IPEndPoint endPoint;
        IPEndPoint receiverPoint;

        public void BeginMonitoring(int recordingDevice)
        {

            udpSender = new UdpClient();
            endPoint = new IPEndPoint(IPAddress.Any, 20000);
            receiverPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10000);
            udpSender.Connect(receiverPoint);


            waveIn = new WaveIn();
            waveIn.DeviceNumber = recordingDevice;
            waveIn.DataAvailable += OnDataAvailable;
            waveIn.WaveFormat = new WaveFormat(44100, 1);
            waveIn.StartRecording();

            Task.Run(StartWaveProvider);
        }

        void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            byte[] buffer = e.Buffer;
            int bytesRecorded = e.BytesRecorded;
            udpSender.Send(buffer, bytesRecorded);

        }

        
        public void StartWaveProvider()
        {
            receiver = new UdpClient();
            receiver.Client.Bind(endPoint);
            waveOut = new WaveOut();
            waveProvider = new BufferedWaveProvider(new WaveFormat(44100, 1));
            waveOut.Init(waveProvider);
            waveOut.Play();
            while (true)
            {
                byte[] buffer = receiver.Receive(ref endPoint);
                waveProvider.AddSamples(buffer, 0, buffer.Length);
            }
        }
    }
}
