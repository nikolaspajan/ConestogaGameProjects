using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2DController : MonoBehaviour
{
    public float movementSpeed = 6f;
    public float jumpForce = 14f;
    private Rigidbody2D rb;

    private bool grounded, isJumping;
    public Transform feet;
    public float checkRadius;
    public LayerMask findGround;
    private Animator animator;
    private bool facingLeft = true;
    public GameObject pauseUI;
    private bool isPaused = false;

    private float jumpTimeCounter;
    public float jumpTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        var movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

        if(movement < 0 && !facingLeft)
        {
            Flip();
        }
        else if(movement > 0 && facingLeft)
        {
            Flip();
        }

        if(movement != 0f)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        if (movement != 0 && isJumping == false && GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().Play();
        }

        if (movement == 0 && GetComponent<AudioSource>().isPlaying == true || grounded == false)
        {
            GetComponent<AudioSource>().Stop();
        }
    }

    void Update()
    {
        grounded = Physics2D.OverlapCircle(feet.position, checkRadius, findGround);
        animator.SetBool("Grounded", grounded);

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {            
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            FindObjectOfType<AudioManager>().Play("Jump");
        }

        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false){
                Time.timeScale = 0f;
                pauseUI.SetActive(true);
                isPaused = true;
            }
            else
            {
                Time.timeScale = 1f;
                pauseUI.SetActive(false);
                isPaused = false;
            }
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
