using System.Collections.Generic;
using UnityEngine;

public class Drownedinwater : MonoBehaviour
{
    //Declarando variables 
    public bool isOnWater3Platform = false;
    public float timeOnPlatform = 0f;
    public float MaximumTimeOnPlatform = 3f;
    public float health = 100f;
    private List<string> touchedWater = new List<string>();


    private void Update()
    {
        if (isOnWater3Platform)
        {
            timeOnPlatform += Time.deltaTime;
            Live(33.3f * Time.deltaTime);

            if (timeOnPlatform >= MaximumTimeOnPlatform)
            {
              
                timeOnPlatform = 0f; // Reinicia el contador de tiempo
            }
            else
            {
                timeOnPlatform = 0f;
            }

        }
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Dentro del ontrigger");
            //Mira si el objeto entro en contacto con el Tag de agua 
            string tagWater= gameObject.tag;

            if (!touchedWater.Contains(tagWater))
            {
                touchedWater.Add(tagWater); //add tag of water of the list

                //ActiveHandreTrigrer
                HandleTrigger(tagWater);
            }
        }
    }

  void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("The player has stopped touching the water ");

           //Check the water objects in the list and take action accordingly
            foreach(string tagWater in touchedWater)
            {
                HandleTriggerExit(tagWater);
            }

            //Clean the list 
            touchedWater.Clear();
        }
    }

    void HandleTrigger(string tagWater)
    {
        Debug.Log("El jugador ha tocado el agua con tag: " +tagWater);
        // Coloca aquí el código que desees ejecutar cuando el jugador toque el agua
        //Verificando tags
     if (tagWater == "Water1")
        {
            Debug.Log("aqui va la llamada de la funcion del sonido Water1");
        }
     else if( tagWater == "Water2")
        {
            Debug.Log("aquí va la llamada de la funcion del sonido Water2");
        }
     else if(tagWater == "Water3")
        {

            Debug.Log("aqui va la llamada de la funcion del sonido y  la llamada a la la funcion que resetea la vida del jugador ");
            isOnWater3Platform = true;
            Live(33.3f);
        }
    }

    
    void HandleTriggerExit(string tagWater)
    {
        
        Debug.Log("El jugador ha dejado de tocar el agua con tag: " + tagWater);

        if (tagWater == "Water1")
        {
            Debug.Log("aqui va la llamada de la funcion del sonido cuando deja de tocar Water1 ");
        }
        else if (tagWater == "Water2")
        {
            Debug.Log("aqui va la llamada de la funcion del sonido cuando deja de tocar Water2 ");
        }
        else if (tagWater == "Water3")
        {
            Debug.Log("aqui va la llamada de la funcion del sonido cuando deja de tocar Water3");
            isOnWater3Platform = false;
        }
    }

    void Live(float amount)
    {
        health -= Mathf.RoundToInt(amount); 
        Debug.Log("Vida del jugador reducida a: " + health);

        if(health <= 0)
        {
            Debug.Log("Vida del jugador reseteada");
            //se agrega lo que pasa cuando el jugador muere 
        }
       
    }
}
