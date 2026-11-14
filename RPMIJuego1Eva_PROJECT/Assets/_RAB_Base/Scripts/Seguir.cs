using UnityEngine;

public class Seguir : MonoBehaviour
{
    [Header("Objetivo")]
    public Transform jugador;
    public Vector3 offsetAltura = new Vector3(0f, 1.5f, 0f); // Para apuntar al torso/cabeza y no a los pies

    [Header("Rotación con Cursor")]
    public float sensibilidadX = 4f;
    public float sensibilidadY = 4f;
    public float limiteVerticalMin = -20f; // Evita que la cámara atraviese el suelo
    public float limiteVerticalMax = 80f;  // Evita que la cámara dé la vuelta completa arriba

    [Header("Zoom Limitado")]
    public float velocidadZoom = 5f;
    public float distanciaActual = 5f;
    public float zoomMinimo = 2f;
    public float zoomMaximo = 12f;

    [Header("Suavizado")]
    public float suavizadoMovimiento = 10f;

    private float rotacionX = 0f;
    private float rotacionY = 0f;

    void Start()
    {
        // Ocultar y bloquear el cursor en el centro de la pantalla (opcional)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Inicializar ángulos con la rotación actual de la cámara
        Vector3 angulos = transform.eulerAngles;
        rotacionX = angulos.y;
        rotacionY = angulos.x;
    }

    void LateUpdate()
    {
        if (jugador == null) return;

        // 1. Leer movimiento del ratón
        rotacionX += Input.GetAxis("Mouse X") * sensibilidadX;
        rotacionY -= Input.GetAxis("Mouse Y") * sensibilidadY;

        // Limitar el ángulo vertical para que no dé la vuelta
        rotacionY = Mathf.Clamp(rotacionY, limiteVerticalMin, limiteVerticalMax);

        // 2. Leer rueda del ratón para el Zoom y limitarlo
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distanciaActual -= scroll * velocidadZoom;
        distanciaActual = Mathf.Clamp(distanciaActual, zoomMinimo, zoomMaximo);

        // 3. Calcular rotación y posición final
        Quaternion rotacion = Quaternion.Euler(rotacionY, rotacionX, 0f);
        Vector3 puntoObjetivo = jugador.position + offsetAltura;
        Vector3 posicionDeseada = puntoObjetivo - (rotacion * Vector3.forward * distanciaActual);

        // 4. Aplicar movimiento suave y mirar al jugador
        transform.position = posicionDeseada;
        transform.LookAt(puntoObjetivo);
    }
}