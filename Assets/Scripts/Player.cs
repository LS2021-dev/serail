using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TerrainTools;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public float ladderSpeed = 2f;
    public float gravity = 3.5f;

    private Rigidbody2D rb;
    private CircleCollider2D circleCollider;
    private float x;
    private float y;
    private bool isGrounded;
    private Animator animator;
    private bool isClimbing;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();

        Physics2D.IgnoreLayerCollision(6, 7);
    }

    // Update is called once per frame
    void Update()
    {
        if (!DialogueManager.isDialogueActive && !Story.freezePlayer)
        {
            x = Input.GetAxis("Horizontal");
            animator.SetFloat("Speed", Mathf.Abs(x));
            isGrounded = circleCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
            if (isGrounded)
            {
                animator.SetBool("IsJumping", false);
            }

            y = Input.GetAxis("Vertical");
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
    }

    private void FixedUpdate()
    {
        if (DialogueManager.isDialogueActive)
        {
            speed = 0f;
            jumpForce = 0f;
        }
        else
        {
            speed = 5f;
            jumpForce = 10f;
        }

        rb.velocity = new Vector2(x * speed, rb.velocity.y);
        if (x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (Input.GetKey("space") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("IsJumping", true);
        }

        if (isClimbing)
        {
            rb.velocity = new Vector2(rb.velocity.x, y * ladderSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("LadderTop"))
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(0, 0);
            isClimbing = false;
            animator.SetBool("IsClimbing", false);
        }
        else if (col.gameObject.CompareTag("LadderPart"))
        {
            rb.gravityScale = 0f;
            isClimbing = true;
            animator.SetBool("IsClimbing", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            rb.gravityScale = gravity;
            isClimbing = false;
            animator.SetBool("IsClimbing", false);
        }
    }
}