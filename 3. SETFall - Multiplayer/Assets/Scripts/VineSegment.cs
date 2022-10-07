using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineSegment : MonoBehaviour
{
    public GameObject connectedAbove, connectedBelow;

    void Start()
    {
        // Connect the vine segements to each other, check to see if they are there and if they are connect them
        connectedAbove = GetComponent<HingeJoint2D>().connectedBody.gameObject;
        VineSegment aboveSegment = connectedAbove.GetComponent<VineSegment>();
        if (aboveSegment != null)
        {
            aboveSegment.connectedBelow = gameObject;
            float vineSpriteBottom = connectedAbove.GetComponent<SpriteRenderer>().bounds.size.y;
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, vineSpriteBottom * -1);
        }
        else
        {
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, 0);
        }
    }
}
