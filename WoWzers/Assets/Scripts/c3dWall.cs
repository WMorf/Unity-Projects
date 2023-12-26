using UnityEngine;
using UnityEngine.Tilemaps;

public class c3dWall : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject cubePrefab;

    void Start()
    {
        foreach (var position in tilemap.cellBounds.allPositionsWithin)
        {
            Vector3Int localPlace = new Vector3Int(position.x, position.y, position.z);

            if (!tilemap.HasTile(localPlace)) continue;

            //TileBase tile = tilemap.GetTile(localPlace);


            Vector3 place = tilemap.CellToWorld(localPlace);
            Instantiate(cubePrefab, place, Quaternion.identity);
        }
    }

}