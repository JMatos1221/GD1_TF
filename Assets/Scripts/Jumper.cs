using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : TimeScale
{
    [SerializeField]
    float speed = 100f, jumpSpeed = 120f, travelDistance = 64f, sight = 64f;
    float timer = 0f;
    bool jump = false, follow = false;
    Rigidbody2D rb;
    GameObject followTarget;
    Vector2 moveSpeed;
    Vector3 diff;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (followTarget == null)
        {
            if (FindObjectOfType<Player>()) followTarget = FindObjectOfType<Player>().gameObject;
        }

        diff = followTarget.transform.position - transform.position;

        if (Mathf.Sqrt(Mathf.Pow(diff.x, 2) + Mathf.Pow(diff.y, 2)) < sight) follow = true;

        else follow = false;

        if (follow)
        {
            timer = 0;

            if (diff.x > 16) speed = Mathf.Abs(speed);

            else if (diff.x < -16) speed = -Mathf.Abs(speed);
        }

        else
        {
            timer += Time.deltaTime * TimeSlow;

            if (timer > travelDistance / Mathf.Abs(speed))
            {
                speed = -speed;
                timer = 0f;
            }
        }

        if (rb.velocity.y > -0.1f && rb.velocity.y < 0.1f) jump = true;

        rb.gravityScale = TimeSlow;
    }

    void FixedUpdate()
    {
        moveSpeed = new Vector2(speed * TimeSlow, rb.velocity.y);

        if (jump)
        {
            moveSpeed.y = jumpSpeed;
            jump = false;
        }

        if (TimeSlow == 0.25f)
        {
            if (moveSpeed.y > 60f) moveSpeed.y = 60;
        }

        rb.velocity = moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("World") && !follow)
        {
            speed = -speed;
            timer = 0f;
        }
    }
}
