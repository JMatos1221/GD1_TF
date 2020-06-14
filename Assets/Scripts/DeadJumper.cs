using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadJumper : TimeScale
{
    [SerializeField]
    float jumpSpeed = 236f;
    float lastTimeSlow;
    Rigidbody2D rb, colRB;

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
        if (collision.CompareTag("Player"))
        {
            colRB = collision.GetComponent<Rigidbody2D>();

            colRB.velocity = new Vector2(colRB.velocity.x, jumpSpeed);
        }
    }
}
