using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupble : MonoBehaviour
{
    public Action<Pickupble> OnPicked;

    public int Score = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPicked?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
