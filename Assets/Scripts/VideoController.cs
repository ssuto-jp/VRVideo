using UnityEngine;

namespace RenderHeads.Media.AVProVideo
{
    public class VideoController : MonoBehaviour
    {
        [SerializeField] private MediaPlayer mediaPlayer;

        private string videoPath;
        private MediaPlayer.FileLocation videoLocation = MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder;

        private void Start()
        {
            videoPath = "AVProVideoSamples/" + MenuButton.videoName + ".mp4";
            PlayVideo(videoPath);
        }

        private void PlayVideo(string path)
        {
            if (path != null)
                mediaPlayer.OpenVideoFromFile(videoLocation, path, true);
        }
    }
}

