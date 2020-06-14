using UnityEngine;
using UnityEngine.UI;

public class Player : TimeScale
{
    float hAxis;
    [SerializeField]
    float speed, jumpSpeed = 236f, maxSpeed = 150f, throwSpeed = 300f;
    float energy, maxEnergy = 100f, energyDrain = 10f;
    bool jump = false, canJump = false, slowTime = false;
    Vector2 moveSpeed;
    Rigidbody2D rb;
    GameObject pickBlock;
    Image energyBar;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = maxSpeed;
        energy = maxEnergy;
        energyBar = GameObject.Find("EnergyBar").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.W) && ((rb.velocity.y > -0.5f && rb.velocity.y < 0.5) || canJump))
        {
            jump = true;
            canJump = false;
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow) && energy > 0)
        {
            TimeSlow = 0.1f;

            slowTime = !slowTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pickBlock != null)
            {
                pickBlock.transform.SetParent(transform);

                pickBlock.GetComponent<Rigidbody2D>().mass = 1f;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (transform.childCount > 0)
            {
                transform.GetChild(0).GetComponent<Rigidbody2D>().mass = 9000f;

                transform.GetChild(0).SetParent(null);
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (transform.childCount > 0)
                {
                    Rigidbody2D throwRB = transform.GetChild(0).GetComponent<Rigidbody2D>();

                    transform.GetChild(0).position = transform.position + new Vector3(16, 8, 0);

                    transform.GetChild(0).SetParent(null);

                    throwRB.velocity = new Vector2(throwSpeed * TimeSlow, 0f);

                    throwRB.mass = 9000;
                }
            }
        }

        if (slowTime)
        {
            energy -= Time.deltaTime * energyDrain;

            if (energy <= 0)
            {
                TimeSlow = 1f;
                slowTime = false;
            }
        }
        
        else if (energy < 100)
        {
            energy += Time.deltaTime * 1f;
        }

        energyBar.fillAmount = energy / 100f;

        if (transform.childCount > 0)
        {
            transform.GetChild(0).position = transform.position + new Vector3(16, 8, 0);
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeadBlock"))
        {
            if (pickBlock == null)
            {
                pickBlock = collision.gameObject;
                canJump = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeadBlock"))
        {
            if (collision.gameObject == pickBlock) pickBlock = null;
        }
    }
}
