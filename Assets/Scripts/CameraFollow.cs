using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Referencia al objeto que queremos seguir
    public float smoothSpeed = 0.125f; // Velocidad de suavizado
    public Vector3 offset; // Desplazamiento de la c�mara respecto al objeto seguido
    public int limitsLeft;
    public int limitRight;

    void FixedUpdate()
    {
        if (target.position.x > -limitsLeft && target.position.x < limitRight)
        {
            Vector3 desiredPosition = target.position + offset; // Posici�n deseada de la c�mara
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Posici�n suavizada
            transform.position = smoothedPosition; // Asignamos la posici�n suavizada a la c�mara
        }
        
    }
}