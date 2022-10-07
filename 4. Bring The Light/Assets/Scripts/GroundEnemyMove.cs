using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyMove : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float agroRange;
    [SerializeField] float moveSpeed;

    private Rigidbody2D rb;
    private bool facingLeft = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if(distToPlayer < agroRange)
        {
            ChasePlayer();
        }
        else
        {
            StopChase();
        }
    }
    private void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
        }
    }
    private void StopChase()
    {
        rb.velocity = Vector2.zero;
    }
    private void FixedUpdate()
    {
        var movement = rb.velocity.x;

        if (movement < 0 && !facingLeft)
        {
            Flip();
        }
        else if (movement > 0 && facingLeft)
        {
            Flip();
        }
    }
    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingLeft = !facingLeft;
    }
}
