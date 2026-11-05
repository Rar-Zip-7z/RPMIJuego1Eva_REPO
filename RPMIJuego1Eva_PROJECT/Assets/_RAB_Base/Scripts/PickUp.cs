using Unity.VisualScripting;
using UnityEngine;


/// <summary>
/// 
/// 
/// CAMBIAR MAXIMOS PARA EL SLOWEO DEL PICKUP CUANDO SUBE Y CUANDO BAJA
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// </summary>



public class PickUp : MonoBehaviour
{
    [Header("Rotation Parameters")]
    public float speedRotationX = 10; // INTENSIDAD DE ROTACION DEL EJE X
    public float speedRotationY = 20; // INTENSIDAD DE ROTACION DEL EJE Y
    public float speedRotationZ = 30; // INTENSIDAD DE ROTACION DEL EJE Z

    [Header("Movement Parameters")]
    public float maxMoveY = 0.75f;   // ALTURA MAXIMA Y    
    public float moveY = 0.05f;     // INTENSIDAD DE MOVIMIENTO EN EJE Y
    public float moveSlowY = 0.02f;
    public float direction = 1;     // POLARIZACION DE LA DIRECCIÓN
    public Transform posInicial;    // REFERENCIA A LA POSICION INICIAL DEL OBJETO
    

    // Update is called once per frame
    void Update()
    {
        MoveObject();
    }

    void MoveObject()
    {
        transform.Rotate(Vector3.right * speedRotationX * Time.deltaTime);   // EJE X * VELOCIDAD X * TEMPORIZADOR REAL
        transform.Rotate(Vector3.up * speedRotationY * Time.deltaTime);      // EJE Y * VELOCIDAD Y * TEMPORIZADOR REAL
        transform.Rotate(Vector3.forward * speedRotationZ * Time.deltaTime); // EJE Z * VELOCIDAD Z * TEMPORIZADOR REAL

        if (transform.position.y > (posInicial.position.y + maxMoveY) || transform.position.y < (posInicial.position.y - maxMoveY)) // COMPROBACION DE LIMITES DE ALTURA EN BASE A LA POSICION INICIAL
        {
            direction = direction * -1; // CAMBIO DE ORIENTACION SI SE CUMPLE UNA DE LAS DOS CONDICIONES
        }


        if (((posInicial.position.y - transform.position.y) * direction) < (maxMoveY * 0.001 * direction))
        {
            transform.Translate(Vector3.up * moveSlowY * direction, Space.World); // EJE Y * VELOCIDAD Y * DIRECCION * EN RELACION AL MUNDO, NO AL LOCAL
            //Debug.Log("UP SLOW MODE OBJECT: " + transform.position.y + " " + " INICIO: " + posInicial.position.y + " //// "+ (posInicial.position.y - transform.position.y) + " > " + (maxMoveY * 0.1 * direction));
        }
        
        else
        {
            transform.Translate(Vector3.up * moveY * direction, Space.World); // EJE Y * VELOCIDAD Y * DIRECCION * EN RELACION AL MUNDO, NO AL LOCAL
            //Debug.Log("NORMAL MODE MODE OBJECT: " + transform.position.y + " " + " INICIO: " + posInicial.position.y + " //// " + (posInicial.position.y - transform.position.y) + " < " + (maxMoveY * 0.1 * direction));                
        }

        
        



        /*if ((posInicial.position.y - transform.position.y <= maxMoveY))
        {
            transform.Translate(Vector3.up * moveY * direction, Space.World); // EJE Y * VELOCIDAD Y * DIRECCION * EN RELACION AL MUNDO, NO AL LOCAL
            Debug.Log("DOWN SLOW MODE POSICION DEL OBJECT: " + transform.position.y + " " + " POSICION INICIAL: " + posInicial.position.y);
        }*/


        
    }
}
