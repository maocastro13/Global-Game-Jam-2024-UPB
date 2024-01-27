using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    public Wall wall;  // Referencia a las paredes que deseas controlar
    public Wall1 wall1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Inicia el movimiento de las paredes cuando el jugador pase por el trigger
            wall.playerOn = true;
            wall1.playerOn = true;
        }
    }
}
