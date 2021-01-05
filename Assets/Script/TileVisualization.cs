using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class TileVisualization : MonoBehaviour
{

    public TileManager TileManager;

    public GameObject TileBorder;
    
    private Tile currentTile;
    
    void OnDrawGizmos()
    {
        currentTile = TileManager.CheckWhereIsPlayer();

        RaycastHit hit;
        
        Vector3 RayOrigin = new Vector3(currentTile.xMin, transform.position.y, currentTile.zMin);
        
        Gizmos.color = Color.red;
        
        if (Physics.Raycast(RayOrigin, Vector3.down, out hit, 30))
        {
            if (hit.collider != null)
            {
                Gizmos.DrawSphere(hit.point, 0.5f);
            }
        }
        
        RayOrigin = new Vector3(currentTile.xMin, transform.position.y, currentTile.zMax);

        if (Physics.Raycast(RayOrigin, Vector3.down, out hit, 30))
        {
            if (hit.collider != null)
            {
                Gizmos.DrawSphere(hit.point, 0.5f);
            }
        }
        
        RayOrigin = new Vector3(currentTile.xMax, transform.position.y, currentTile.zMax);

        if (Physics.Raycast(RayOrigin, Vector3.down, out hit, 30))
        {
            if (hit.collider != null)
            {
                Gizmos.DrawSphere(hit.point, 0.5f);
            }
        }
        RayOrigin = new Vector3(currentTile.xMax, transform.position.y, currentTile.zMin);

        if (Physics.Raycast(RayOrigin, Vector3.down, out hit, 30))
        {
            if (hit.collider != null)
            {
                Gizmos.DrawSphere(hit.point, 0.5f);
            }
        }

    }
}
