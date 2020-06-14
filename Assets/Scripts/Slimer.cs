using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimer : TimeScale
{
    Rigidbody2D rb;
    Vector2 moveSpeed;
    GameObject followTarget;
    [SerializeField]
    float speed = 35f;
    float timer = 1;
    public bool follow = false;
    Vector3 diff, slimeOffset;
    [SerializeField]
    GameObject slime;
    public bool Alive { get; set; } = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (followTarget == null)
        {
            if (FindObjectOfType<Player>()) followTarget = FindObjectOfType<Player>().gameObject;
        }

        else if (follow)
        {
            diff = followTarget.transform.position - transform.position;

            if (diff.x > 16) speed = Mathf.Abs(speed);

            else if (diff.x < -16) speed = -Mathf.Abs(speed);
        }

        if (timer > 16f / Mathf.Abs(speed))
        {
            slimeOffset = transform.position;

            slimeOffset.y -= 7;

            Instantiate(slime, slimeOffset, Quaternion.identity).transform.SetParent(transform);

            timer = 0;
        }

        rb.gravityScale = TimeSlow;
    }

    void FixedUpdate()
    {
        moveSpeed = new Vector2((follow ? 3 * speed : speed) * TimeSlow, rb.velocity.y);

        rb.velocity = moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.position.y - transform.position.y < 24)
            {
                Destroy(collision.gameObject);
                follow = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("World") && !follow)
        {
            speed = -speed;
        }
    }
}
