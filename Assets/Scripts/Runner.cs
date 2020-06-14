using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Runner : TimeScale
{
    [SerializeField]
    float speed = 250f;
    Rigidbody2D rb;
    Vector2 moveSpeed;
    public bool Alive { get; set; } = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.gravityScale = TimeSlow;
    }

    void FixedUpdate()
    {
        moveSpeed = new Vector2(speed * TimeSlow, rb.velocity.y);

        rb.velocity = moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.position.y - transform.position.y < 24) Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("World")) speed = -speed;
    }
}
