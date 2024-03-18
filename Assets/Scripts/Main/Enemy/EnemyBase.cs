using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    protected float health;
    protected float chasingSpeed = 2.0f, iddleSpeed = 0.5f, idleMovementDistance = 10;
    protected bool isTriggered = false, inIdleMovement, inChasing = false;
    protected Vector3 initialPosition;
    protected NavMeshAgent m_Agent;
    protected GameObject player;

    public void SetDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            SelfDestroy();
    }
    private void SelfDestroy()
    {
        Destroy(gameObject);
    }
    protected void EnemyMovement()
    {
        if (!isTriggered && !inIdleMovement)
            IdleMovement(false);
        if (isTriggered)
        {
            inIdleMovement = false;
        }
    }
    private void IdleMovement(bool needToStop)
    {
        inIdleMovement = true; //в движении
        m_Agent.SetDestination(NewDestinationIdle());
        inIdleMovement = false;//не в движении
    }
    private IEnumerator ChasingPlayer()
    {
        float startTime = Time.realtimeSinceStartup;
        while(Time.realtimeSinceStartup - startTime < 3)
        {
            SearchPlayer();
            m_Agent.SetDestination(player.transform.position);
            if (isTriggered)
            {
                startTime = Time.realtimeSinceStartup;
            }
            yield return null;
        }
        m_Agent.speed = iddleSpeed;
        IdleMovement(false);
        inChasing = false;
        yield return null;
    }
    private Vector3 NewDestinationIdle()
    {
        float newX = initialPosition.x + UnityEngine.Random.Range(-1 * idleMovementDistance, idleMovementDistance);
        float newZ = initialPosition.z + UnityEngine.Random.Range(-1 * idleMovementDistance, idleMovementDistance);
        return new Vector3(newX, initialPosition.y, newZ);
    }
    private bool SearchPlayer()
    {
        for (int i = -2; i <= 2; i++)
        {
            if (Raycast(new Vector3(
            (transform.forward.x + transform.right.x * i) / 2,
            transform.forward.y,
            (transform.forward.z + transform.right.z * i) / 2)))
            {
                isTriggered = true;
                return true;
            }
        }
        isTriggered = false;
        return false;
    }
    private bool Raycast(Vector3 direction)
    {
        Ray ray = new Ray(transform.position, direction);
        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData))
        {
            if (hitData.collider.name == "Player")
            {
                return true;
            }
        }
        return false;

    }
    protected void EnemyChasing()
    {
        if (!inChasing)
        {
            inChasing = true;
            
            if (SearchPlayer())
            {
                 m_Agent.speed = chasingSpeed;
                 StartCoroutine(ChasingPlayer());
            }
            else
            {
                inChasing = false;
            }
        }
        
    }
}
