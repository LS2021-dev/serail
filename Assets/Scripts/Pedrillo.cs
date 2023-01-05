using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedrillo : MonoBehaviour
{
    private float x;
    private Animator animator;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x = rb.velocity.x;
        animator.SetFloat("Speed", Mathf.Abs(x));
        if (x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
