using UnityEngine;
using TMPro; //Librería que permite trabajar con objetos de Text Mesh Pro

public class AnillaManager : MonoBehaviour
{
    public TMP_Text anillaText; //Ref al texto que indica los puntos, para poder modificar el texto
    public PlayerInteractor playerIntScript; //Ref al script que contiene los puntos y los winpoints. Para poder acceder a su valor

    // Update is called once per frame
    void Update()
    {
        //Actualizar constantemente el valor de puntos
        //Points: points/winpoints
        anillaText.text = "Points: " + playerIntScript.currentAnilla.ToString() + "/" + playerIntScript.anillaMax.ToString();
        
    }
}
