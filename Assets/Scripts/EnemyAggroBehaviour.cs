using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggroBehaviour : MonoBehaviour
{
    public EnemyBehaviour Enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Enemy.Target = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Enemy.Target = null;
    }
}
