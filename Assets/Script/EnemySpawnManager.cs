using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{

    public GameObject EnemyPrefab;

    public GameBoundManager GameBoundManager;

    public void SpawnEnemy()
    {
        Vector3 OriginRay = GameBoundManager.GetGameAreaPoint(30);
        RaycastHit hit;
        if (Physics.Raycast(OriginRay, Vector3.down, out hit, 40))
        {
            if (hit.collider != null && hit.collider.CompareTag("Floor"))
            {
               Instantiate(EnemyPrefab, hit.point, new Quaternion(0,0,0,0));
            }
            else
            {
                SpawnEnemy();
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnEnemy();
        }
    }
}
