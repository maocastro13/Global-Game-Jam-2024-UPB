using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float speed = 10.0f; // Velocidad de movimiento de las paredes
    public Vector3 direction; // Dirección de movimiento
    public float destroyPoint; // Punto de destrucción
    public bool playerOn = false;
    void Update()
    {
        // Mueve las paredes
        if (playerOn)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
        

        // Destruye las paredes si han alcanzado el punto de destrucción
        if (transform.position.z <= destroyPoint)
        {
            Destroy(gameObject);
        }
    }
}
