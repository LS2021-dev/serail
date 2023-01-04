using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDoor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite openDoor;
    public Sprite closedDoor;

    public void OpenDoor()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = openDoor;
    }

    public void CloseDoor()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedDoor;
    }
}