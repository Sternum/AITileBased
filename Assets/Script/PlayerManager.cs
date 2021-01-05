using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerManager : MonoBehaviour
{
    public NavMeshAgent NavMeshAgent;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, LayerMask.GetMask("Floor")))
            {
                if (hit.collider != null && hit.collider.CompareTag("Floor"))
                {
                    NavMeshAgent.destination = hit.point;
                }
            }
        }
    }
}
