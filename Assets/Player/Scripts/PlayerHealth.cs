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

    private void Die()
    {
        // Aquí puedes poner el código para manejar la muerte del personaje
        Debug.Log("Personaje ha muerto");
    }
}
