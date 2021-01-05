using Script;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public float TileHeight = 2.0f;
    public float TileWidth = 2.0f;

    public PlayerManager PlayerManager;
    
    public Tile CheckWhereIsPlayer()
    {
        Vector3 playerPosition = PlayerManager.GetComponent<Transform>().position;

        float X = Mathf.Floor(playerPosition.x / TileHeight) * TileHeight;
        float Y = Mathf.Floor(playerPosition.z / TileWidth) * TileWidth;
        
        Tile tile = new Tile
        {
            xMin = X,
            zMin = Y,
            xMax = X + TileHeight,
            zMax = Y + TileWidth
        };

        return tile;
    }
}
