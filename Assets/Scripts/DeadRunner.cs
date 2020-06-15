using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadRunner : TimeScale
{
    float lastTimeSlow;
    Vector3 moveSpeed;
    Rigidbody2D rb;

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

        moveSpeed.y = Mathf.Clamp(moveSpeed.y, -60f * TimeSlow, 120f);

        rb.velocity = moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("World"))
        {
            float invertSpeed = -rb.velocity.x;

            rb.velocity = new Vector2(invertSpeed, rb.velocity.y);
        }
    }
}
