using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorGuia : MonoBehaviour
{
    public Image cartelActual;
    public Image imagenBotonFlecha;

    public Sprite[] listaCarteles;
    public Sprite[] listaFlechas;

    private int indice = 0;

    void Start()
    {
        ActualizarPantalla();
    }

    public void PasarCartel()
    {
        Debug.Log("¡Se ha hecho clic en la flecha!"); 
        indice++;

        if (indice < listaCarteles.Length)
        {
            ActualizarPantalla();
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    void ActualizarPantalla()
    {
        if (cartelActual != null && indice < listaCarteles.Length)
        {
            cartelActual.sprite = listaCarteles[indice];
        }

        if (imagenBotonFlecha != null && indice < listaFlechas.Length)
        {
            imagenBotonFlecha.sprite = listaFlechas[indice];
        }
    }
}