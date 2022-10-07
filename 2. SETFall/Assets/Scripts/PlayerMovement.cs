using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public float movementSpeed = 3f;
    private Rigidbody2D rb;
    private HingeJoint2D hj;
    public float swingForce = 20f;
    public bool attached = false;
    public Transform attachedToVine;
    public float jumpForce = 5f;
    float movementX;
    public Transform feet;
    public LayerMask groundLayer;
    public Animator animator;

    private void Awake()
    {
        //set these on awake
        rb = gameObject.GetComponent<Rigidbody2D>();
        hj = gameObject.GetComponent<HingeJoint2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if players enter a tarpit slow them down, play a sound and lose points
        if (collision.gameObject.CompareTag("TarPit"))
        {
            FindObjectOfType<Audio>().Play("TarPit");
            LevelManagerScript.instance.DecreasePointsRandom();
            movementSpeed = 1f;
        }
        
        //if players aren't already attached connect to the vine and play a sound
        if (!attached)
        {
            if (collision.gameObject.CompareTag("Vine"))
            {
                FindObjectOfType<Audio>().Play("VineSwing");
                Attach(collision.gameObject.GetComponent<Rigidbody2D>());
            }
        }       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //if the player leaves the tarpit stop the sound and return them to normal speed
        if (collision.gameObject.CompareTag("TarPit"))
        {
            FindObjectOfType<Audio>().Stop("TarPit");
            movementSpeed = 3f;
        }
    }
    private void Update()
    {
       //get the movement values
       vineKeyboardInputs();

       movementX = Input.GetAxisRaw("Horizontal");

       //if space is pressed run jump
       if (Input.GetButtonDown("Jump") && Grounded())
       {
            Jump();
       }
        
       //stops the player from walking off the left side of the screen
       if (rb.transform.position.x <= -7.2f) 
       {
           rb.transform.position = new Vector3(-7.2f, rb.transform.position.y, rb.transform.position.z);
           rb.velocity = new Vector2(0, rb.velocity.y); 
       }

       //see if the player is moving fast enough to play the run animation
       if(Mathf.Abs(movementX) > 0.05)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        
       //see if the play is on the ground for the animations
       animator.SetBool("isGrounded", Grounded());
    }
    private void FixedUpdate()
    {
        //moves the player left or right depending on the key press
        Vector2 movement = new Vector2(movementX * movementSpeed, rb.velocity.y);
        rb.velocity = movement;
    }
    void Jump()
    {
        //lets the player jump
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        rb.velocity = movement;
        FindObjectOfType<Audio>().Play("Jump");
    }
    public bool Grounded()
    {
        //check to see if the feet under the player is overlapping with the groundlayer, if it is allow them to jump
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.2f, groundLayer);

        if (groundCheck != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    void vineKeyboardInputs()
    {
        //change space from jump to detach from the vine if the player is attached to a vine
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (attached)
            {
                Detach();
            }
        }
    }
    public void Attach(Rigidbody2D vineBone)
    {
        //attaches the player to the vine
        hj.connectedBody = vineBone;
        hj.enabled = true;
        attached = true;
        attachedToVine = vineBone.gameObject.transform.parent;
        animator.SetBool("isAttached", true);
    }

    void Detach()
    {
        //detaches the player from the vine
        hj.enabled = false;
        hj.connectedBody = null;
        animator.SetBool("isAttached", false);
    }
}
