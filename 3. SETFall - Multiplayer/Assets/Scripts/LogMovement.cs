using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMovement : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody2D rb;

    private void FixedUpdate()
    {
    //moves the log to the left
    rb.velocity = new Vector2(-speed, rb.velocity.y);
    }
}
