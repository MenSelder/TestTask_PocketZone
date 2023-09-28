using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemysList = new List<GameObject>();

    [SerializeField] private Tilemap tileMap;
    [SerializeField] private Tilemap tileMapDecorations;

    private List<Vector3> availablePlaces;
    private int enemyAmount = 3;

    private void Start()
    {
        FindLocationsOfTiles();
        Spawn();
    }

    private int GetRanodIndex(ICollection collection) => Random.Range(0, collection.Count); 

    private void FindLocationsOfTiles()
    {
        availablePlaces = new List<Vector3>();

        for (int i = tileMap.cellBounds.xMin; i < tileMap.cellBounds.xMax; i++)
        {
            for (int j = tileMap.cellBounds.yMin; j < tileMap.cellBounds.yMax; j++)
            {
                Vector3Int localPlace = new Vector3Int(i, j);
                Vector3 place = tileMap.CellToWorld(localPlace);
                if (tileMap.HasTile(localPlace))
                {
                    availablePlaces.Add(place);
                }
            }
        }
    }

    private void Spawn()
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            var place = availablePlaces[GetRanodIndex(availablePlaces)];

            int rndIdx = GetRanodIndex(enemysList);
            var prefab = enemysList[rndIdx];

            Instantiate(prefab, new Vector3(place.x + 0.5f, place.y + 0.5f, place.z), Quaternion.identity, transform);
        }
    }
}
