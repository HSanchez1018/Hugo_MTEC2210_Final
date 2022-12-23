using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask ground;
    public float speed = 5;
    public float jumpSpeed = 5;
    private Rigidbody2D rb;

    bool jumping;
    float xMove;

    public float distanceCheckAmount = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();      
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Are we on the ground? - " + GroundCheck());

        xMove = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
        }
    }
      

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        Debug.Log("Triggered");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(xMove * speed * Time.deltaTime, rb.velocity.y);

        if (jumping == true)
        {
            rb.velocity = Vector2.up * jumpSpeed;
            jumping = false;
        }
    }

    public bool GroundCheck()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, distanceCheckAmount, ground);
    }
}
