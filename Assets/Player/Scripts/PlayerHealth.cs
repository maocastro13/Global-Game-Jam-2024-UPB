using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        // Inicializa la vida del personaje a la vida m�xima
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        // Decrementa la vida del personaje por la cantidad de da�o recibido
        currentHealth -= amount;

        // Verifica si la vida del personaje ha llegado a cero
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Aqu� puedes poner el c�digo para manejar la muerte del personaje
        Debug.Log("Personaje ha muerto");
    }
}
