using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Referencia al objeto que queremos seguir
    public float smoothSpeed = 0.125f; // Velocidad de suavizado
    public Vector3 offset; // Desplazamiento de la cámara respecto al objeto seguido

    void FixedUpdate()
    {
        
        if ((target.position.x > -11 && target.position.x < 11) || (target.position.y > -1 && target.position.x > -11 && target.position.x < 11))
        {
            Vector3 desiredPosition = target.position + offset; // Posición deseada de la cámara
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Posición suavizada
            transform.position = smoothedPosition; // Asignamos la posición suavizada a la cámara
        }
      
    }
}
