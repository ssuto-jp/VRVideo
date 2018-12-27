using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace RenderHeads.Media.AVProVideo
{
    public class VideoController : MonoBehaviour
    {
        [SerializeField] private MediaPlayer mediaPlayer;
        [SerializeField] private Slider videoSeekSlider;

        private string videoPath;
        private MediaPlayer.FileLocation videoLocation = MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder;
        private float setVideoSeekSliderValue;

        private void Start()
        {
            videoPath = "AVProVideoSamples/" + MenuButton.videoName + ".mp4";
            PlayVideo(videoPath);
        }

        private void Update()
        {
            if (mediaPlayer.Info != null && mediaPlayer.Info.GetDurationMs() > 0f)
            {
                float time = mediaPlayer.Control.GetCurrentTimeMs();
                float duration = mediaPlayer.Info.GetDurationMs();
                float d = Mathf.Clamp(time / duration, 0.0f, 1.0f);

                setVideoSeekSliderValue = d;
                videoSeekSlider.value = d;
            }
        }

        private void PlayVideo(string path)
        {
            if (path != null)
                mediaPlayer.OpenVideoFromFile(videoLocation, path, true);
        }

        public void OnPlayButton()
        {
            mediaPlayer.Control.Play();
        }

        public void OnPauseButton()
        {
            mediaPlayer.Control.Pause();
        }

        public void OnRewindButton()
        {
            mediaPlayer.Control.Rewind();
        }

        public void OnVideoSeekSlider()
        {
            if (videoSeekSlider && videoSeekSlider.value != setVideoSeekSliderValue)
            {
                mediaPlayer.Control.Seek(videoSeekSlider.value * mediaPlayer.Info.GetDurationMs());
            }
        }

        public void OnFinishedPlaying()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}

