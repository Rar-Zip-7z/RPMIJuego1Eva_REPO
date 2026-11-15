
using System.Security.Cryptography;
using UnityEngine;

public class zz_Palom : MonoBehaviour
{
    public Transform player;
    public Transform camara;
    public Vector3 offset;

    void LateUpdate()
    {
        // Mantener la paloma directamente encima del jugador
        transform.position = player.position + Vector3.up * offset.y;

        // Obtener la dirección horizontal hacia la que mira la cámara
        Vector3 direccion = camara.forward;
        direccion.y = 0f;
        direccion.Normalize();

        // Orientar la paloma de espaldas a la cámara
        if (direccion.sqrMagnitude > 0.001f)
        {
            transform.rotation = Quaternion.LookRotation(direccion);
        }
    }
}
