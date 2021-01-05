using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using Debug = UnityEngine.Debug;

public class EnemySense : MonoBehaviour
{

    private Transform Player;

    public float FieldOfView = 120.0f;

    public NavMeshAgent NavMeshAgent;

    public EnemyController EnemyController;
    
    // Update is called once per frame
    void Update()
    {
        if (Player != null && CanSeePlayer())
        {
            EnemyController.Stop();
            RotateTowardPlayer();
            NavMeshAgent.destination = Player.position;
        }
        else
        {
            EnemyController.Start();
        }
    }

    private bool CanSeePlayer()
    {
        Vector3 playerDirection = (Player.position - transform.position).normalized;
        Vector3 ForwardNormalized = transform.forward.normalized;

        float dot = Vector3.Dot(playerDirection, ForwardNormalized);
        float angle = Mathf.Acos(dot) * (180 / Mathf.PI);

        if (angle < (FieldOfView / 2))
        {
            RaycastHit hit;
            if (Physics.Linecast(transform.position, Player.position, out hit))
            {
                if (hit.collider != null && hit.collider.CompareTag("Player"))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void RotateTowardPlayer()
    {
        transform.forward = (Player.position - transform.position).normalized;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player = other.GetComponent<Transform>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player = null;
        }
    }
}
