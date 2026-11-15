using UnityEngine;

public class MusicaPersistente : MonoBehaviour
{
    private static MusicaPersistente instancia;

    void Awake()
    {
        // Si aún no existe la música persistente, la guardamos y evitamos que se destruya
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Si volvemos al menú y se intenta crear una segunda música, destruimos la copia nueva
            Destroy(gameObject);
        }
    }
}