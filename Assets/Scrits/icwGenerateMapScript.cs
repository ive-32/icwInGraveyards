using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class icwGenerateMapScript : MonoBehaviour
{
    public GameObject square;     //Array of floor prefabs.
    private Transform boardHolder;
    void BoardSetup()
    {
        boardHolder = new GameObject("board").transform;

        GameObject instance = Instantiate(square, new Vector3(0, 0, 0f), Quaternion.identity) as GameObject;

        //Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
        instance.transform.SetParent(boardHolder);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
