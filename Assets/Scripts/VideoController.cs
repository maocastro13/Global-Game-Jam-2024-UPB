using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private string nextScene;

    void Start()
    {
        // Asigna la función ChangeScene() al evento del final del video.
        videoPlayer.loopPointReached += ChangeScene;
    }

    // Cambia a la siguiente escena cuando el video termina.
    void ChangeScene(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextScene);
    }
}
