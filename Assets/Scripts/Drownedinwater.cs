using System.Collections.Generic;
using UnityEngine;

public class Drownedinwater : MonoBehaviour
{
    //Declarando variables 
    public bool isOnWater3Platform = false;
    public float timeOnPlatform = 0f;
    public float MaximumTimeOnPlatform = 3f;
    public float health = 100f;
    public bool isRight=true;



    private List<string> touchedWater = new List<string>();


    private void Update()
    {
        if (isOnWater3Platform)
        {
            timeOnPlatform += Time.deltaTime; // Contando los segundos que se queda en la plataforma 

            // Resta 33.3 puntos de vida por cada segundo en la plataforma Water3
            healthPlayer(33.3f * Time.deltaTime);

            if (timeOnPlatform >= MaximumTimeOnPlatform)
            {
                // Puedes agregar acciones adicionales cuando el jugador ha estado en la plataforma durante 3 segundos
                // Por ejemplo, reiniciar el nivel, mostrar un mensaje, etc.
                Debug.Log("El jugador ha estado en la plataforma Water3 durante 3 segundos");
                Die();
            }
        }
        else
        {
            // Regenera la vida del jugador inmediatamente al salir del área del trigger
            Regenerate(100f);
            timeOnPlatform = 0f; // Reinicia el contador de tiempo al salir del área del trigger
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
            if (isRight) GestionSonidoAgua.Instance.EntraZonaAgua(GestionSonidoAgua.Instance.aguaLejosDerecho, GestionSonidoAgua.Instance.aguaLejosDerechoBools);
            else GestionSonidoAgua.Instance.EntraZonaAgua(GestionSonidoAgua.Instance.aguaLejosIzquierdo, GestionSonidoAgua.Instance.aguaLejosIzquierdoBools);

        }
     else if( tagWater == "Water2")
        {
            Debug.Log("aquí va la llamada de la funcion del sonido Water2");
            if (isRight) GestionSonidoAgua.Instance.EntraZonaAgua(GestionSonidoAgua.Instance.aguaCercaDerecho, GestionSonidoAgua.Instance.aguaCercaDerechoBools);
            else GestionSonidoAgua.Instance.EntraZonaAgua(GestionSonidoAgua.Instance.aguaCercaIzquierdo, GestionSonidoAgua.Instance.aguaCercaIzquierdoBools);
        }
     else if(tagWater == "Water3")
        {
            Debug.Log("aqui va la llamada de la funcion del sonido y  la llamada a la la funcion que resetea la vida del jugador ");
            if (isRight) GestionSonidoAgua.Instance.EntraZonaAgua(GestionSonidoAgua.Instance.ahogandoseDerecho, GestionSonidoAgua.Instance.ahogandoseDerechoBools);
            else GestionSonidoAgua.Instance.EntraZonaAgua(GestionSonidoAgua.Instance.ahogandoseIzquierdo, GestionSonidoAgua.Instance.ahogandoseIzquierdoBools);
            isOnWater3Platform = true;
        }
    }

    
    void HandleTriggerExit(string tagWater)
    {
        
        Debug.Log("El jugador ha dejado de tocar el agua con tag: " + tagWater);

        if (tagWater == "Water1")
        {
            Debug.Log("aqui va la llamada de la funcion del sonido cuando deja de tocar Water1 ");
            if (isRight) GestionSonidoAgua.Instance.SalirZonaAgua(GestionSonidoAgua.Instance.aguaLejosDerecho, GestionSonidoAgua.Instance.aguaLejosDerechoBools);
            else GestionSonidoAgua.Instance.SalirZonaAgua(GestionSonidoAgua.Instance.aguaLejosIzquierdo, GestionSonidoAgua.Instance.aguaLejosIzquierdoBools);
        }
        else if (tagWater == "Water2")
        {
            Debug.Log("aqui va la llamada de la funcion del sonido cuando deja de tocar Water2 ");
            if (isRight) GestionSonidoAgua.Instance.SalirZonaAgua(GestionSonidoAgua.Instance.aguaCercaDerecho, GestionSonidoAgua.Instance.aguaCercaDerechoBools);
            else GestionSonidoAgua.Instance.SalirZonaAgua(GestionSonidoAgua.Instance.aguaCercaIzquierdo, GestionSonidoAgua.Instance.aguaCercaIzquierdoBools);
        }
        else if (tagWater == "Water3")
        {
            Debug.Log("aqui va la llamada de la funcion del sonido cuando deja de tocar Water3");
            isOnWater3Platform = false;
            if (isRight) GestionSonidoAgua.Instance.SalirZonaAgua(GestionSonidoAgua.Instance.ahogandoseDerecho, GestionSonidoAgua.Instance.ahogandoseDerechoBools);
            else GestionSonidoAgua.Instance.SalirZonaAgua(GestionSonidoAgua.Instance.ahogandoseIzquierdo, GestionSonidoAgua.Instance.ahogandoseIzquierdoBools);
        }
    }

  

    public void healthPlayer(float amountDisminucion)
    {

        health -= amountDisminucion;
        Debug.Log("Vida del jugador reducida a: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Regenerate(float amount)
    {
        if (isOnWater3Platform)
        {
            health = Mathf.Min(health + amount, 100f); // Regenera la vida del jugador al 100%
            Debug.Log("Vida del jugador regenerada a: " + health);
        }
    }

    void Die()
    {
        // Coloca aquí el código para manejar la muerte del jugador
        Debug.Log("El jugador ha muerto");
        // Puedes agregar lógica adicional aquí, como reiniciar el nivel, mostrar un mensaje, etc.
    }


}
