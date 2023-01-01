using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDoor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite openDoor;
    public Sprite closedDoor;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OpenDoor()
    {
        spriteRenderer.sprite = openDoor;
    }

    void CloseDoor()
    {
        spriteRenderer.sprite = closedDoor;
    }
}