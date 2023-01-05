using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedrillo : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private Vector3 previous;
    private float velocity;
    private bool isKneeling = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isKneeling)
        {
            animator.SetBool("IsKneeling", true);
        }
    }

    private void FixedUpdate()
    {
        velocity = (transform.position - previous).magnitude / Time.deltaTime;
        previous = transform.position;
        animator.SetFloat("Speed", velocity);
    }
}