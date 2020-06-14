using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSlimer : TimeScale
{
    Rigidbody2D rb;
    float lastTimeSlow, slippingWall = 1f;
    Vector3 moveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastTimeSlow = TimeSlow;
    }

    void Update()
    {
        rb.gravityScale = TimeSlow * slippingWall;
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
        if (collision.CompareTag("World")) slippingWall = 0.1f;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("World")) slippingWall = 1f;
    }
}
