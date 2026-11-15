using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.Video;

public class Pantallainicio : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject rawImageVideo;
    public GameObject menuCanvasObject;

    
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

    
    public void IrAGuia()
    {
        SceneManager.LoadScene(15);
    }

    public void IrTuto()
    {
        SceneManager.LoadScene(16);
    }

    public void ExitGame()
    {
        //Acción que cierra la build sin usar Alt + F4
        Debug.Log("El botón de salir del juego funciona.");
        Application.Quit(); //Acción que cierra el juego
    }
}