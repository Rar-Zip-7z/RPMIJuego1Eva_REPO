using System.Diagnostics;
using UnityEngine;

public class TerminarLvL : MonoBehaviour
{

    public PlayerInteractor playerIntScript; //Ref al script que contiene los puntos y los winpoints. Para poder acceder a su valor
    public int anillas;
    public int anillasTotal;

    // Update is called once per frame
    void Start() {
        
    }

    void Update()
    {
        anillas = playerIntScript.currentAnilla;
        anillasTotal = playerIntScript.anillaMax;        

        if (anillas == anillasTotal) { 
            gameObject.SetActive(false);            
        }

    }
}
