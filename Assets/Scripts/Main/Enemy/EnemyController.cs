using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : EnemyBase
{
    void Start()
    {
        health = 100;
        initialPosition = transform.position;
        m_Agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        InvokeRepeating("EnemyChasing", 1, Time.deltaTime);
        InvokeRepeating("EnemyMovement", 1, Random.Range(5, 20));
    }

    void Update()
    {
        
    }

}
