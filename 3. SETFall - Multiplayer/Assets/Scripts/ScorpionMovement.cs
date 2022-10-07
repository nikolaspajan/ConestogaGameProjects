using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionMovement : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody2D rb;
    float startPosX;
    bool isFacingLeft = true;
    public Animator animator;

    private void Start()
    {
        startPosX = this.transform.position.x;
    }
    private void FixedUpdate()
    {
        //move left then right after it hits a certain position
        if(isFacingLeft == true)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if(this.transform.position.x < startPosX - 1f)
            {
                isFacingLeft = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (this.transform.position.x > startPosX + 1f)
            {
                isFacingLeft = true;
            }
        }
        animator.SetBool("isFacingLeft", isFacingLeft);
    }
}
