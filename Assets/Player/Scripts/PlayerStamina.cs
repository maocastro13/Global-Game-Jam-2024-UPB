using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    private float maxStamina = 100f;
    public float currentStamina;

    private void Start()
    {
        currentStamina = maxStamina;
    }

    private void Update()
    {
        if(currentStamina < 2f)
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().runSpeed = 2f;

            Debug.Log("Se agoto la stamina");
        }
    }
}
