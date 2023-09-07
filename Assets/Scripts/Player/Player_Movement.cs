using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private Animator anim;
    private SpriteRenderer sp;

    [SerializeField] private LayerMask jumpbleGround;

    private float dirX;
    [SerializeField] private float jumpForce;
    [SerializeField] private float doubleJumpForce;
    [SerializeField] private float moveSpeed;

    private bool doubleJump;
    private bool doubleJump2;

    private enum MovementState { Idle, Running, Jumping, Falling, DoubleJump }

    [SerializeField] private AudioSource jumSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveSpeed * dirX,rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            if(IsGrounded())
            {
                jumSoundEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                doubleJump = true;
            }

            else if (doubleJump)
            {
                jumSoundEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x, doubleJumpForce);
                doubleJump = false;
            }
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        doubleJump2 = true;
        MovementState state;

        if (dirX > 0)
        {
            state = MovementState.Running;
            sp.flipX = false;
        }
        else if (dirX < 0)
        {
            state = MovementState.Running;
            sp.flipX = true;
        }
        else
        {
            state = MovementState.Idle;
        }

        if(rb.velocity.y > .1f)
        {
            state = MovementState.Jumping;
            if (Input.GetButtonDown("Jump"))
            {
                state = MovementState.DoubleJump;
                doubleJump2 = false;
            }      
        }

        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.Falling;
            if (Input.GetButtonDown("Jump") && doubleJump2)
            {
                state = MovementState.DoubleJump;
            }            
        }

        anim.SetInteger("State", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, jumpbleGround);
    }
}
