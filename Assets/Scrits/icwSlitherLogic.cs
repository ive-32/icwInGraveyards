using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class icwSlitherLogic : MonoBehaviour
{
    public GameObject mainbody;
    public Tilemap tilemap;
    private const int iBodyPartsCount = 3;
    
    enum BodyTypes {Core, Primary, Secondary, Tentacle};
    class BodyPart
    {
        public Vector2 coord;
        public int type;
    }

    private List<GameObject> body = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        GameObject tmpbody;
        for (int i = 0; i < iBodyPartsCount; i++)
        {
            Vector3 pos = Random.insideUnitCircle.normalized * 0.5f;
            tmpbody = Instantiate(mainbody, transform.position + pos,Quaternion.identity);
            body.Add(tmpbody);
            if (i > 0)
            {
                DistanceJoint2D tmpdj2d;
                tmpdj2d = tmpbody.GetComponent<DistanceJoint2D>();
                tmpdj2d.connectedBody = body[0].GetComponent<Rigidbody2D>();
            }
        }
        Rigidbody2D rg2d;
        rg2d = body[0].GetComponent<Rigidbody2D>();
        rg2d.velocity = new Vector3(1, 1, 0);
        //transform.position = new Vector3(2, 2, 0);
    }

    void AttachtoTile()
    {
        for (int i = 0; i < iBodyPartsCount; i++)
        { 
            Vector3Int cellPosition = tilemap.WorldToCell(body[i].transform.position);
            body[i].transform.position = tilemap.CellToWorld(cellPosition); // + new Vector3(tilemap.cellSize.x  / 2, 0,0)  ;
        }
    }
    // Update is called once per frame
    void Update()
    {
        AttachtoTile();
        Rigidbody2D rg2d;
        rg2d = body[0].GetComponent<Rigidbody2D>();
        //rg2d.velocity = new Vector3(1, 1, 0);

    }
}
