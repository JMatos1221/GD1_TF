using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    [SerializeField]
    GameObject DeadEnemy;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(transform.parent.gameObject);
            Instantiate(DeadEnemy, transform.parent.position, Quaternion.identity);
        }
    }
}
