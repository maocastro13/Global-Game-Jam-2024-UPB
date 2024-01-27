using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent enemy;
    private float timer = 10f;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemy = this.GetComponent<NavMeshAgent>();
        enemy.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer > 0)
        {
            enemy.speed = timer;
            enemy.SetDestination(player.transform.position);
        }
        else
        {
            enemy.speed = 0;
            StartCoroutine(ActiveEnemy());
        }
        
    }

    IEnumerator ActiveEnemy()
    {
        timer = 10f;
        yield return null;
    }
}
