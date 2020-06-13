using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField]
    float speed = 100f, jumpSpeed = 125f, travelDistance = 64f, sight = 64f;
    float timer = 0f;
    bool jump = false, follow = false;
    Rigidbody2D rb;
    GameObject followTarget;
    Vector2 moveSpeed;
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

        Vector3 diff = followTarget.transform.position - transform.position;

        if (Mathf.Sqrt(Mathf.Pow(diff.x, 2) + Mathf.Pow(diff.y, 2)) < sight)
        {
            follow = true;
        }

        else follow = false;

        if (follow)
        {
            timer = 0;

            if (diff.x > 32) speed = Mathf.Abs(speed);

            else if (diff.x < -32) speed = -Mathf.Abs(speed);
        }

        else
        {
            timer += Time.deltaTime;

            if (timer > travelDistance / Mathf.Abs(speed))
            {
                speed = -speed;
                timer = 0f;
            }
        }

        if (rb.velocity.y > -0.5f && rb.velocity.y < 0.5f) jump = true;
    }

    void FixedUpdate()
    {
        moveSpeed = new Vector2(speed, rb.velocity.y);

        if (jump)
        {
            moveSpeed.y = jumpSpeed;
            jump = false;
        }


        rb.velocity = moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("World"))
        {
            speed = -speed;
            timer = 0f;
        }
    }
}
