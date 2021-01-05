using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent NavMeshAgent;

    public TileManager TileManager;

    public Tile LastKnownPlayerTile;

    private bool IsPatrol = false;
    
    // Update is called once per frame

    private void Awake()
    {
        if (TileManager == null)
        {
            TileManager = FindObjectOfType<TileManager>();
        }
    }

    void Update()
    {
        if (!IsPatrol)
        {
            GenerateRandomPatrolPoint();
        }
        else
        {
            if (NavMeshAgent.remainingDistance <= NavMeshAgent.stoppingDistance)
            {
                IsPatrol = false;
            }
        }
    }

    private void GenerateRandomPatrolPoint()
    {
        LastKnownPlayerTile = TileManager.CheckWhereIsPlayer();
        float X = Random.Range(LastKnownPlayerTile.xMin, LastKnownPlayerTile.xMax);
        float Z = Random.Range(LastKnownPlayerTile.zMin, LastKnownPlayerTile.zMax);
        
        Vector3 OriginRay = new Vector3(X, 20.0f, Z);

        RaycastHit hit;
        if (Physics.Raycast(OriginRay, Vector3.down, out hit, 40.0f))
        {
            if (hit.collider != null && hit.collider.CompareTag("Floor"))
            {
                NavMeshAgent.destination = hit.point;
                IsPatrol = true;
            }
        }
    }

    public void Stop()
    {
        enabled = false;
        IsPatrol = false;
    }

    public void Start()
    {
        enabled = true;
        
    }
}
