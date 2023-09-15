using NAudio.Wave;
using System;
using System.Threading;

namespace Wingine
{
    [Serializable]
    public class AudioSource : IComponent
    {
        public string Audio;

        [NonSerialized]
        WaveOutEvent outputDevice;

        string audioFilePath = @"C:\Users\PC USER\Desktop\Jump.wav";

        public void Play()
        {
            new Thread(new ThreadStart(() => { outputDevice.Play(); }));
        }

        public void Pause()
        {
            outputDevice.Pause();
        }

        public void Stop()
        {
            outputDevice.Stop();
        }

        public override void Begin()
        {
            outputDevice = new WaveOutEvent();
            audioFilePath = @"C:\Users\PC USER\Desktop\Jump.wav";
            using (var audioFile = new AudioFileReader(audioFilePath))
            {
                outputDevice.Init(audioFile);
            }
        }

        public override void Tick()
        {

        }
    }
}
