using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;

public class PickupManager : MonoBehaviour
{
    public int NumberOfitemsToPickup = 2;

    public Pickupble PickupPrefab;

    public float GroundOffset = 2.0f;

    public GameBoundManager GameBoundManager;

    public EnemySpawnManager EnemySpawnManager;

    public ScoreController ScoreController;
    
    private List<Pickupble> Pickupbles;

    private const float RayHeight = 40.0f;
    private void Awake()
    {
         Pickupbles = new List<Pickupble>();
    }

    private void Start()
    {
        SpawnManyItems();
    }
    public void SpawnManyItems()
    {
        for (int i = 0; i < NumberOfitemsToPickup; i++)
        {
            SpawnItem();
        }
    }
    
    private void SpawnItem()
    {
        Vector3 OriginRay = GameBoundManager.GetGameAreaPoint(RayHeight);
        RaycastHit hit;
        if (Physics.Raycast(OriginRay, Vector3.down, out hit, RayHeight * 1.5f))
        {
            if (hit.collider != null && hit.collider.CompareTag("Floor"))
            {
                Vector3 pos = new Vector3(hit.point.x, hit.point.y + GroundOffset, hit.point.z);
                Pickupble pick = Instantiate(PickupPrefab, pos, new Quaternion(0,0,0,0));
                Pickupbles.Add(pick);
                pick.OnPicked += OnPicked;
            }
            else
            {
                SpawnItem();
            }
        }
    }

    private void OnPicked(Pickupble obj)
    {
        obj.OnPicked -= OnPicked;
        ScoreController.UpdateScore(obj.Score);
        Pickupbles.Remove(obj);
        CheckCondition();
    }

    public void CheckCondition()
    {
        if (Pickupbles.Count <= 0)
        {
            SpawnManyItems();
            EnemySpawnManager.SpawnEnemy();
        }
    }
}