using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    [SerializeField]
    float speed = 250f;
    Rigidbody2D rb;
    Vector2 moveSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveSpeed = new Vector2(speed, rb.velocity.y);
        rb.velocity = moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("World")) speed = -speed;
    }
}
