using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace Wingine.Audio
{
    [Serializable]
    public class AudioSource : MonoBehaviour
    {
        public string AudioName = "New Audio";
        public string AudioData;

        [ActionButton(true)]
        public Action GetAudioDataFromFile;

        [Header("Audio Settings")]
        public bool PlayOnAwake = false;
        public bool Loop = false;


        public AudioSource()
        {
            GetAudioDataFromFile = () =>
            {
                GetAudioData();
            };
        }


        void GetAudioData()
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Audio File: ";
            ofd.Filter = "Audio Files|*.mp3;*.wav;*.ogg;*.flac;*.aac;*.wma|All Files|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string audioFilePath = ofd.FileName; // Replace with your audio file path

                // Read the audio file into a byte array
                byte[] audioBytes = File.ReadAllBytes(audioFilePath);

                // Convert the byte array to a Base64-encoded string
                string base64EncodedAudio = Convert.ToBase64String(audioBytes);
                AudioData = base64EncodedAudio;
            }
        }

        public void Play()
        {
            try
            {
                var thd = new Thread(new ThreadStart(() =>
                {
                    PlayAudioFromBase64String(AudioData);
                }));

                thd.Start();
            }
            catch (Exception e)
            {
                Debug.Write($"Unable to play audio: {e.Message}\nat Audio Source\non GameObject '{GameObject.Name}'");
            }
        }

        public void Pause()
        {
            if (waveOut != null)
            {
                waveOut.Pause();
            }
        }

        bool fStop = false;
        public void Stop()
        {
            if(waveOut != null)
            {
                waveOut.Stop();
                fStop = true;
            }
        }

        public override void Awake()
        {
            fStop = false;

            if (PlayOnAwake)
            {
                Play();
            }
        }

        [NonSerialized]
        WaveOutEvent waveOut;
        internal void PlayAudioFromBase64String(string base64EncodedAudio)
        {
            if(waveOut != null)
            {
                waveOut.Stop();
                waveOut.Dispose();
            }

            // Convert the Base64-encoded string back to a byte array
            byte[] audioBytes = Convert.FromBase64String(base64EncodedAudio);

            // Create a MemoryStream from the byte array
            using (MemoryStream memoryStream = new MemoryStream(audioBytes))
            {
                // Create a WaveStream from the MemoryStream
                using (WaveStream waveStream = new Mp3FileReader(memoryStream))
                {
                    // Create a WaveOutEvent to play the audio
                    using (waveOut = new WaveOutEvent())
                    {
                        // Initiate the playback
                        waveOut.Init(waveStream);
                        waveOut.Play();

                        // Wait for the playback to complete
                        while (waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            if (!Runner.App.IsRunning)
                            {
                                waveOut.Stop();
                            }
                            System.Threading.Thread.Sleep(100);
                        }

                        if(Loop && !fStop && Runner.App.IsRunning)
                        {
                            Play();
                        }
                    }
                }
            }
        }
    }
}
