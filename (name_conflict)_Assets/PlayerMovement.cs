using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float dirX = 0f;
    private SpriteRenderer sprite;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    private enum Movement {idle,jumping,falling,running};


    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("A inceput jocu!!!!");

        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimation();
    }
    private void UpdateAnimation()
    {
        Movement state = Movement.idle;

        if(dirX > 0f)
        {
            state = Movement.running;
            sprite.flipX = false;
        }
        else if(dirX < 0f)
        {
            state = Movement.running;
            sprite.flipX = true;
        }
        else
        {
            state = Movement.idle;
        }

        if(rb.velocity.y > .1f)
        {
            state = Movement.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = Movement.falling;
        }

        anim.SetInteger("state", (int)state);

    }



}
