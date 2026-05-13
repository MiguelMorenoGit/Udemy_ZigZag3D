using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{
    public Transform objetivo; // El objeto que la cámara seguirá
    private Vector3 diferencia;

    private void Awake()
    {
        diferencia = transform.position - objetivo.position; // Calcula la diferencia inicial entre la cámara y el objetivo
    }

    // LateUpdate se llama después de que todos los objetos hayan sido actualizados, lo que es ideal para seguir a un objetivo
    private void LateUpdate()
    {
        transform.position = objetivo.position + diferencia;
    }
}
