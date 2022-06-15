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
    [SerializeField] private BoxCollider2D boxcoll;
    [SerializeField] private LayerMask jumpGround;
    public int extraJumps;
    DialogueManager dialogueManager;
    bool isActive;
    private enum Movement { idle, jumping, falling, running };

    //for ground check
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    //for audio sources
    [SerializeField] private AudioSource jumpSoundEffect;


    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("A inceput jocu!!!!");

        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        boxcoll = GetComponent<BoxCollider2D>();
        dialogueManager = GameObject.Find("Dialogue Box").GetComponent<DialogueManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        isActive = dialogueManager.getActivity();

        if (isActive == false)
        {
            dirX = Input.GetAxisRaw("Horizontal");

            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

            if (isGrounded)
            {
                extraJumps = 1;
            }

            if (Input.GetButtonDown("Jump") && extraJumps > 0)
            {
                jumpSoundEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                extraJumps--;
            }
            else if (Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }

            UpdateAnimation();
        }
        else
        {
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
            dirX = 0;
        }
        UpdateAnimation();
    }
    private void UpdateAnimation()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

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

    //old check for ground
/*    private bool onGround()
    {
        return Physics2D.BoxCast(boxcoll.bounds.center, boxcoll.bounds.size, 0f, Vector2.down, .1f, jumpGround);
    }*/



}
