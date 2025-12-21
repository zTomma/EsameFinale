using UnityEngine;
using UnityEngine.Video;

public class CinemaStopper : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    public void StopVideo()
    {
        Debug.Log("CLICK -> StopVideo chiamata");

        if (videoPlayer != null)
        {
            videoPlayer.Stop();
        }
        else
        {
            Debug.LogWarning("VideoPlayer NON assegnato");
        }
    }
}