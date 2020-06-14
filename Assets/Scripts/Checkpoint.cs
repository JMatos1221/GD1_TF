using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    GameMNG gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Main Camera").GetComponent<GameMNG>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.spawnPos = transform.position;
            Destroy(gameObject);
        }
    }
}
