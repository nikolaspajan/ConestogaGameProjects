using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocodileOpenOrClose : MonoBehaviour
{
    //variables
    float changeMouth = 5f;
    bool isOpen = false;
    public Animator animator;
    void Update()
    {
        //changes the mouth state every 5 seconds
        changeMouth -= Time.deltaTime;

        //after 5 seconds change between open and closed
        if (changeMouth <= 0)
        {
            if(isOpen == false)
            {
                isOpen = true;
                changeMouth = 5f;
                animator.SetBool("isOpen", true);
            }
            else
            {
                isOpen = false;
                changeMouth = 5f;
                animator.SetBool("isOpen", false);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //if the player lands on a open crocdile, they run this
        if (collision.gameObject.CompareTag("Player") && isOpen == true)
        {
            Destroy(collision.gameObject);
            FindObjectOfType<Audio>().Play("Crocodile");
            LevelManagerScript.instance.DecreasePointsDeath();
            LevelManagerScript.instance.Respawn();
        }
    }
}
