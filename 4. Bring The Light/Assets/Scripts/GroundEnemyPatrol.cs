using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyPatrol : MonoBehaviour
{
    public float speed;
    public float howFar;
    private bool goingRight;
    private Rigidbody2D rb;
    private float initalPos;

    private void Start()
    {
        goingRight = true;
        rb = GetComponent<Rigidbody2D>();
        initalPos = transform.position.x;
    }

    private void Update()
    {
        if (goingRight == true)
        {
            rb.velocity = new Vector2(speed, 0);
            if (transform.position.x >= initalPos + howFar)
            {
                goingRight = false;
                Flip();
            }
        } 
        else
        {
            rb.velocity = new Vector2(-speed, 0);
            if (transform.position.x <= initalPos - howFar)
            {
                goingRight = true;
                Flip();
            }
        }
    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
    }
}
