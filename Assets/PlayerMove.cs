using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float velocity = 5f; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Obtener la entrada para el movimiento
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Calcular la direccion del movimiento
        Vector3 direccion = new Vector3(moveHorizontal, 0f, moveVertical);

        //Mover el objeto en la direccion calculada
        transform.Translate(direccion * velocity * Time.deltaTime);
    }


   
}


