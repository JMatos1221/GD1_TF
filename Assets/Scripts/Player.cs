using UnityEngine;

public class Player : MonoBehaviour
{
    float hAxis;
    [SerializeField]
    float speed = 150f, jumpSpeed = 236f;
    bool jump=false;
    Vector2 moveSpeed;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.W)) jump = true;
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
}
