using UnityEngine;

public class MovimientoPaloma : MonoBehaviour
{
    public Transform jugador;

    void Update()
    {
        transform.position = jugador.position;
        transform.rotation = jugador.rotation;
    }
}