using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform player;
    public NavMeshAgent enemy;
    //public bool followPlayer = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemy = this.GetComponent<NavMeshAgent>();
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if(followPlayer == true)
        //{
            enemy.SetDestination(player.transform.position);
        //}
    }
}
