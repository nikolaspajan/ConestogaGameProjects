using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{
    public Rigidbody2D hook;
    public GameObject[] vineSegments;
    public int numLinks = 4;

    void Start()
    {
        //the vine that creates the vine segments
        Rigidbody2D prevBod = hook;
        for (int i = 0; i < numLinks; i++)
        {
            int index = Random.Range(0, vineSegments.Length);
            GameObject newSegmenet = Instantiate(vineSegments[index]);
            newSegmenet.transform.parent = transform;
            newSegmenet.transform.position = transform.position;
            HingeJoint2D hj = newSegmenet.GetComponent<HingeJoint2D>();
            hj.connectedBody = prevBod;
            prevBod = newSegmenet.GetComponent<Rigidbody2D>();
        }
    }
}
