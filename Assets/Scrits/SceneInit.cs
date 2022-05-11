using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEditor;
using UnityEngine.Tilemaps;

public class SceneInit : MonoBehaviour
{
    private List<Sprite> floor = new List<Sprite>();
    private List<Sprite> walls = new List<Sprite>();
    public GameObject floorPrefab;
    public Tilemap grid;

    private void GetTilesByName(string tilename, List<Sprite> tilelist)
    {
        string[] tilenames = AssetDatabase.FindAssets(tilename, new[] { "Assets/Textures" });
        if (tilelist == null) tilelist = new List<Sprite>();
        foreach (string tmptile in tilenames)
        {
            tilelist.Add((Sprite)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(tmptile), typeof(Sprite)));
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        GetTilesByName("Floor", floor);
        GetTilesByName("Wall", walls);


        for (int i = -20; i < 20; i++)
            for (int j = -20; j < 20; j++)
            {
                int tileindex = Random.Range(0, floor.Count);
                if (Random.Range(0, 100) > 3) tileindex = 0;
                floorPrefab.GetComponent<SpriteRenderer>().sprite = floor[tileindex];
                Instantiate(floorPrefab, grid.GetCellCenterWorld(new Vector3Int(i, j, 0)) , Quaternion.identity);
            }

        for (int i = -20; i < 20; i++)
            for (int j = -20; j < 20; j++)
            {
                int tileindex = Random.Range(0, walls.Count);
                if (Random.Range(0, 100) < 1)
                {
                    floorPrefab.GetComponent<SpriteRenderer>().sprite = walls[tileindex];
                    floorPrefab.layer = 1;
                    Instantiate(floorPrefab, grid.GetCellCenterWorld(new Vector3Int(i, j, 0)), Quaternion.identity);
                }
            }
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
