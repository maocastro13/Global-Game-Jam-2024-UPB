using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            // Si el jugador colisiona con las paredes, establece su vida en 0
            GetComponent<PlayerHealth>().TakeDamage(100);
        }
        if (other.gameObject.tag == "Wall1")
        {
            GetComponent<PlayerHealth>().TakeDamage(100);
        }
    }
}
