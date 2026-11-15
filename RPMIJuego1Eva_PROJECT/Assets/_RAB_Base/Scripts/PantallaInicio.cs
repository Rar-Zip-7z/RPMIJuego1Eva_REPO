using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class Pantallainicio : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject rawImageVideo;
    public GameObject menuCanvasObject;

    // Recuerda si ya vimos el vídeo de intro para no repetirlo al volver de Guide
    private static bool introYaVista = false;

    void Start()
    {
        if (introYaVista)
        {
            if (rawImageVideo != null) rawImageVideo.SetActive(false);
            if (menuCanvasObject != null) menuCanvasObject.SetActive(true);
            return;
        }

        if (menuCanvasObject != null) menuCanvasObject.SetActive(false);
        if (rawImageVideo != null) rawImageVideo.SetActive(true);

        if (videoPlayer != null)
        {
            videoPlayer.playbackSpeed = 1f;
            videoPlayer.prepareCompleted += OnVideoPrepared;
            videoPlayer.loopPointReached += OnVideoFinished;
            videoPlayer.Prepare();
        }
    }

    void OnVideoPrepared(VideoPlayer vp)
    {
        vp.Play();
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        introYaVista = true;
        if (rawImageVideo != null) rawImageVideo.SetActive(false);
        if (menuCanvasObject != null) menuCanvasObject.SetActive(true);
    }

    // Función que llamará el botón Guide
    public void IrAGuia()
    {
        SceneManager.LoadScene("EscenaGuia");
    }
}