using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed;
    public float jumpSpeed;
    float hmove;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMove();
        CheckJump();
    }

    void CheckMove()
    {
        hmove = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(hmove, rb.velocity.y);
    }
    void CheckJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }
}
