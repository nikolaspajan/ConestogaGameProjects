using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TurnOnAi : MonoBehaviour
{
    public GameObject flyingEnemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            flyingEnemy.GetComponent<AIPath>().enabled = true;
        }
    }
}
