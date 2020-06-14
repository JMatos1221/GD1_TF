using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSlimer : TimeScale
{
    Rigidbody2D rb;
    float lastTimeSlow;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastTimeSlow = TimeSlow;
    }

    void Update()
    {
        rb.gravityScale = TimeSlow;
    }

    void FixedUpdate()
    {
        if (lastTimeSlow != TimeSlow)
        {
            Vector2 moveSpeed = rb.velocity;

            moveSpeed *= TimeSlow / lastTimeSlow;

            rb.velocity = moveSpeed;

            lastTimeSlow = TimeSlow;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("World")) rb.gravityScale *= 0.5f;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("World")) rb.gravityScale *= 2f;
    }
}
