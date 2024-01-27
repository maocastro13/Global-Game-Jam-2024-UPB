using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        // Inicializa la vida del personaje a la vida máxima
        currentHealth = maxHealth;
    }

    float timerStop = 0f;
    float timeSeconds = 3f;

    private void Update()
    {
        if(GameObject.Find("Player").GetComponent<PlayerMovement>().isPlayerStop == true)
        {
            timerStop = timerStop + Time.deltaTime;

            if(timerStop > timeSeconds)
            {
                timeSeconds = timeSeconds + 1f;
                TakeDamage(20);
            }
        }
        else
        {
            timerStop = 0f;
            timeSeconds = 3f;
            GainLife(2);
        }
    }

    public void TakeDamage(int amount)
    {
        // Decrementa la vida del personaje por la cantidad de daño recibido
        currentHealth -= amount;

        // Verifica si la vida del personaje ha llegado a cero
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void GainLife(int amount)
    {
        if(currentHealth < 100)
        {
            // Incremente la vida del personaje si se empieza a mover
            currentHealth += amount;
        }
    }

    public void Die()
    {
        // Aquí puedes poner el código para manejar la muerte del personaje
        Debug.Log("Personaje ha muerto");
        GameObject.Find("GameManager").GetComponent<GameManager>().isLivePlayer = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            Die();
        }
    }
}
