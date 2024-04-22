using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Accord.Video.FFMPEG;

namespace Wingine.Video
{
    [Serializable]
    public class VideoPlayer : MonoBehaviour
    {
        public string VideoName = "New Video";
        public string VideoData;
        public string VideoExtension;

        [ActionButton(true)]
        public Action GetVideoDataFromFile;

        [Header("Video Display Settings")]
        public int ResolutionWidth = 320;
        public int ResolutionHeight = 180;

        [Header("Video Settings")]
        [Range(0f, 1f)]
        public float Volume = 0.8f;
        public bool PlayOnAwake = false;
        public bool Loop = false;

        public VideoPlayer()
        {
            GetVideoDataFromFile = () =>
            {
                GetVideoData(fallback: true);
            };
        }


        void GetVideoData(string file = "", bool fallback = false)
        {
            if (File.Exists(file))
            {
                string videoFilePath = file;
                byte[] videoBytes = File.ReadAllBytes(videoFilePath);
                string base64EncodedVideo = Convert.ToBase64String(videoBytes);
                VideoData = base64EncodedVideo;
                VideoExtension = Path.GetExtension(videoFilePath);
            }
            else if (fallback)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Select Video File: ";
                ofd.Filter = "Video Files|*.mp4|All Files|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string videoFilePath = ofd.FileName;
                    byte[] videoBytes = File.ReadAllBytes(videoFilePath);
                    string base64EncodedVideo = Convert.ToBase64String(videoBytes);
                    VideoData = base64EncodedVideo;
                    VideoExtension = Path.GetExtension(videoFilePath);
                }
            }
        }


        private VideoFileReader videoReader;
        private int currentFrameIndex;
        private Bitmap currentFrame;

        string tmp = "";

        public void Play()
        {
            videoReader = new VideoFileReader();
            tmp = $"{DateTime.UtcNow.Ticks}_video_player_{GameObject.ID}{VideoExtension}";
            File.WriteAllBytes(tmp, Convert.FromBase64String(VideoData));
            videoReader.Open(tmp);
            currentFrameIndex = 0;
            currentFrame = GetFrame(currentFrameIndex);
        }

        public override void Awake()
        {
            base.Awake();

            if (PlayOnAwake)
            {
                Play();
            }
        }

        public override void Update()
        {
            base.Update();
            MoveToNextFrame();
        }

        public void Dispose()
        {
            videoReader.Close();
            videoReader.Dispose();
            currentFrame.Dispose();
        }

        private Bitmap GetFrame(int index)
        {
            return videoReader.ReadVideoFrame(index);
        }

        public Bitmap GetCurrentFrame()
        {
            return currentFrame;
        }

        public void MoveToNextFrame()
        {
            currentFrameIndex = (currentFrameIndex + 1) % ((int)videoReader.FrameCount);
            currentFrame.Dispose();
            currentFrame = GetFrame(currentFrameIndex);
        }

        public void MoveToPreviousFrame()
        {
            currentFrameIndex = (currentFrameIndex - 1 + ((int)videoReader.FrameCount)) % ((int)videoReader.FrameCount);
            currentFrame.Dispose();
            currentFrame = GetFrame(currentFrameIndex);
        }
    }
}
