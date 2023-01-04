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
    private bool isGrounded;
    private Animator animator;
    private bool isClimbing;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(x));
        isGrounded = circleCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
        if (isGrounded)
        {
            animator.SetBool("IsJumping", false);
        }
    }

    private void FixedUpdate()
    {
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

        if (Input.GetKey("w") && isClimbing)
        {
            rb.velocity = new Vector2(rb.velocity.x, ladderSpeed);
        } else if (Input.GetKey("s") && isClimbing)
        {
            rb.velocity = new Vector2(rb.velocity.x, -ladderSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("LadderTop"))
        {
            Debug.Log("LadderTop");
            rb.gravityScale = gravity;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            isClimbing = false;
            animator.SetBool("IsClimbing", false);
        }
        else if (col.gameObject.CompareTag("Ladder"))
        {
            Debug.Log("Ladder");
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            isClimbing = true;
            animator.SetBool("IsClimbing", true);
        }
    }
}