using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadJumper : TimeScale
{
    [SerializeField]
    float jumpSpeed = 236f;
    float lastTimeSlow;
    Vector2 moveSpeed;
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
        moveSpeed = rb.velocity;

        if (lastTimeSlow != TimeSlow)
        {
            moveSpeed.x *= TimeSlow / lastTimeSlow;

            lastTimeSlow = TimeSlow;
        }

        moveSpeed.y = Mathf.Clamp(moveSpeed.y, -120f * TimeSlow, 120f);

        rb.velocity = moveSpeed;
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
