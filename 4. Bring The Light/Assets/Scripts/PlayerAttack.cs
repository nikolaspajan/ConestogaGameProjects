using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayer;
    public int attackDamage;
    public float knockbackForce;
    public float attackRate;
    private float nextAttackTime;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.C))
            {
                nextAttackTime = Time.time + 1f / attackRate;
                StartCoroutine(AttackTrigger());
            }
        }
    }

    IEnumerator AttackTrigger()
    {
        animator.SetTrigger("Attacking");
        FindObjectOfType<AudioManager>().Play("SwordSwing");
        yield return new WaitForSeconds(0.12f);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<GroundEnemyMove>() != null)
            {
                enemy.GetComponent<GroundEnemyMove>().enabled = false;
            }

            if (enemy.GetComponent<GroundEnemyPatrol>() != null)
            {
                enemy.GetComponent<GroundEnemyPatrol>().enabled = false;
            }

            if (enemy.GetComponent<TurnOnAi>() != null)
            {
                enemy.GetComponent<TurnOnAi>().enabled = false;
            }

            Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                FindObjectOfType<AudioManager>().Play("HurtEnemy");
                Vector2 dir = enemy.transform.position - transform.position;
                dir.y = 0;
                rb.AddForce(dir.normalized * knockbackForce, ForceMode2D.Impulse);
            }
            else
            {
                BoxCollider2D bc = enemy.GetComponent<BoxCollider2D>();

                if(bc != null)
                {
                    FindObjectOfType<AudioManager>().Play("HurtEnemy");
                    Vector2 dir = enemy.transform.position - transform.position;
                    dir.y = 0;
                    bc.transform.Translate(dir * 4);
                }
            }

            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            yield return new WaitForSeconds(0.5f);

            if (enemy.GetComponent<GroundEnemyMove>() != null)
            {
                enemy.GetComponent<GroundEnemyMove>().enabled = true;
            }

            if (enemy.GetComponent<GroundEnemyPatrol>() != null)
            {
                enemy.GetComponent<GroundEnemyPatrol>().enabled = true;
            }

            if (enemy.GetComponent<TurnOnAi>() != null)
            {
                enemy.GetComponent<TurnOnAi>().enabled = true;
            }
        }
    }
}
