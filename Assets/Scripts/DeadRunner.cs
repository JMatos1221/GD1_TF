using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class DeadRunner : TimeScale
{
    [SerializeField]
    float maxSpeed = 100f;
    float lastTimeSlow;
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
        if (lastTimeSlow != TimeSlow)
        {
            Vector2 moveSpeed = rb.velocity;

            moveSpeed *= TimeSlow / lastTimeSlow;

            rb.velocity = moveSpeed;

            lastTimeSlow = TimeSlow;
        }
    }
}
