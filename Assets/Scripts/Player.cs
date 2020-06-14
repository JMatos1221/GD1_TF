using UnityEngine;

public class Player : TimeScale
{
    float hAxis;
    [SerializeField]
    float speed, jumpSpeed = 236f, maxSpeed = 150f;
    bool jump = false;
    Vector2 moveSpeed;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.W) && rb.velocity.y > -0.5f && rb.velocity.y < 0.5) 
            jump = true;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (TimeSlow == 1) TimeSlow = 0.25f;

            else TimeSlow = 1;
        }
    }

    void FixedUpdate()
    {
        moveSpeed = new Vector2(speed * hAxis, rb.velocity.y);

        if (jump)
        {
            moveSpeed.y = jumpSpeed;
            jump = false;
        }

        rb.velocity = moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Slime"))
        {
            speed /= 2;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Slime"))
        {
            speed = maxSpeed;
        }
    }
}
