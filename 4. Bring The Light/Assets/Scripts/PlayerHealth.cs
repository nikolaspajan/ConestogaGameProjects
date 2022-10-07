using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int health = 0;
    [SerializeField] private int maxHealth = 5;

    public GameObject deathUI;
    private Animator animator;
    public Image[] hp;
    private int hpLeft = 5;

    private void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void UpdateHealth(int mod)
    {
        health += mod;
        FindObjectOfType<AudioManager>().Play("Health");
        if (mod < 0)
        {
            HPLose();
        }
        else
        {
            if(health >= maxHealth)
            {
                health = maxHealth;
            }
            HPGain();
            return;
        }
        
        if (health <= 0)
        {
            StartCoroutine(ReloadLevel());
        }
        else
        {
            animator.SetTrigger("GotHit");
        }
    }

    public void HPLose()
    {
        if(hpLeft <= 0)
        {
            hpLeft = 0;
            return;
        }
        hpLeft--;
        hp[hpLeft].enabled = false;
    }

    public void HPGain()
    {
        if (hpLeft >= 5)
        {
            hpLeft = maxHealth;
            return;
        }
        hp[hpLeft].enabled = true;
        hpLeft++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "HP")
        {
            Destroy(collision.gameObject);
            UpdateHealth(1);
        }
    }

    IEnumerator ReloadLevel()
    {
        animator.SetTrigger("GotHit");
        gameObject.GetComponent<Character2DController>().enabled = false;
        FindObjectOfType<AudioManager>().Play("Death");
        animator.SetTrigger("Death");

        yield return new WaitForSeconds(1);
        Time.timeScale = 0f;
        deathUI.SetActive(true);
    }
}
