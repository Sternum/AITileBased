using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameBoundManager : MonoBehaviour
{
    public float Size = 30.0f;

    private Bounds Bounds;

    private void Awake()
    {
        Bounds = new Bounds(transform.position, new Vector3(Size, 10, Size));
    }
    
    public Vector3 GetGameAreaPoint(float yOffset)
    {
        float X = Random.Range(Bounds.min.x, Bounds.max.x);
        float Z = Random.Range(Bounds.min.z, Bounds.max.z);
        return new Vector3(X, yOffset, Z);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(Size, 10.0f, Size));
    }
}
