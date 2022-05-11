using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;


public class icwTileMapGenerator : MonoBehaviour
{
    public Tilemap floortilemap;
    public Tilemap objectstilemap;
    public Tilemap ligthingtilemap;
    public GameObject player;
    private List<TileBase> floor = new List<TileBase>();
    private List<TileBase> walls = new List<TileBase>();


    private void GetTilesByName(string tilename, List<TileBase> tilelist)
    {
        string[] tilenames = AssetDatabase.FindAssets(tilename, new[] { "Assets/Tiles" });
        if (tilelist == null) tilelist = new List<TileBase>();
        foreach (string tmptile in tilenames)
        {
            tilelist.Add((TileBase)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(tmptile), typeof(Tile)));
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
                floortilemap.SetTile(new Vector3Int(i, j), floor[tileindex]);
               
            }

        for (int i = -20; i < 20; i++)
            for (int j = -20; j < 20; j++)
            {
                int tileindex = Random.Range(0, walls.Count);
                if (Random.Range(0, 100) < 1) objectstilemap.SetTile(new Vector3Int(i, j), walls[tileindex]);
            }


        //floortile.SetTile(new Vector3Int(2,2),tile[0]);
        //floortile.

    }

    // Update is called once per frame
    void Update()
    {
        /*TileBase tb;
        Vector3 playercoord = player.transform.position;
        Vector3Int currtile = floortilemap.WorldToCell(playercoord);
        ligthingtilemap.ClearAllTiles();
        tb = floortilemap.GetTile(currtile);
        ligthingtilemap.SetTile(currtile, tb);*/
    }
}
