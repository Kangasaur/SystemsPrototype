using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed;
    public float jumpSpeed;
    bool onGround = true;
    float hmove;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }

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
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            onGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
    }
}
