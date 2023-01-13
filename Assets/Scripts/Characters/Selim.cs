using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selim : MonoBehaviour
{
    private Animator animator;
    private Vector3 previous;
    private float velocity;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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