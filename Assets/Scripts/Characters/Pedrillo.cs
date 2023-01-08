using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedrillo : MonoBehaviour
{
    private Animator animator;
    private Vector3 previous;
    private float velocity;
    private CircleCollider2D circleCollider;
    private BoxCollider2D boxCollider;
    private float oldY;
    [HideInInspector] public bool isKneeling = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        circleCollider = GetComponent<CircleCollider2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        oldY = boxCollider.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (isKneeling)
        {
            animator.SetBool("IsKneeling", true);
            circleCollider.enabled = false;
            boxCollider.size = new Vector2(boxCollider.size.x, 0.25f);
        }
        else
        {
            animator.SetBool("IsKneeling", false);
            circleCollider.enabled = true;
            boxCollider.size = new Vector2(boxCollider.size.x, oldY);
        }

        if (transform.position.x > previous.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (transform.position.x < previous.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void FixedUpdate()
    {
        velocity = (transform.position - previous).magnitude / Time.deltaTime;
        previous = transform.position;

        animator.SetFloat("Speed", velocity);
    }
}