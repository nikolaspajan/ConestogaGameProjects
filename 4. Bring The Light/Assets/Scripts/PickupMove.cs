using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMove : MonoBehaviour
{
    private float initalPos;
    private bool goingUp;
    public float moveSpace;

    private void Start()
    {
        goingUp = true;
        initalPos = transform.position.y;
    }
    private void Update()
    {
        if (goingUp == true)
        {
            transform.Translate(Vector2.up * Time.deltaTime);

            if (transform.position.y >= initalPos + moveSpace)
            {
                goingUp = false;
            }
        }

        if (goingUp == false)
        {
            transform.Translate(Vector2.down * Time.deltaTime);

            if (transform.position.y <= initalPos - moveSpace)
            {
                goingUp = true;
            }
        }
    }
}
