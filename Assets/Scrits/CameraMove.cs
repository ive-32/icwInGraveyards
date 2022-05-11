using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;
    private Vector3 newposition;
    private Vector3 currentposition;
    private Vector3 diffposition;

    private bool bMoving = false;
    public float fcameraspeed = 3f;
    //Vector3 
    private void Start()
    {
        newposition = transform.position;
        currentposition = transform.position;
        bMoving = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        currentposition = transform.position;
        if ((player.position - currentposition).magnitude > 6) 
        { newposition = player.position; newposition.z = -5; 
          diffposition = (player.position - currentposition); diffposition.z = 0;  }
        bMoving = (Vector3.Distance(newposition,currentposition)>0.5);
        if (bMoving) transform.position += diffposition * fcameraspeed * Time.deltaTime;
    }
}
