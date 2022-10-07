using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackAttack : MonoBehaviour
{
    [SerializeField] private int attackDamage = 1;
    [SerializeField] private float knockbackForce;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            Vector2 dir = collision.transform.position - transform.position;
            dir.y = 0;
            rb.AddForce(dir.normalized * knockbackForce, ForceMode2D.Impulse);

            if(collision.gameObject.tag == "Player")
            {
                FindObjectOfType<AudioManager>().Play("Hurt");
                collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
            }
        }
    }
}
