using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemyFollow : MonoBehaviour
{

    [SerializeField] private GameObject enemy; 

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            enemy.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            enemy.SetActive(false);
        }
    }
}
