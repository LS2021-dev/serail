using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Story : MonoBehaviour
{
    private ControlDoor controlDoor1;
    private ControlDoor controlDoor2;
    private GameObject player;
    private GameObject pedrillo;
    private GameObject konstanze;
    private GameObject osmin;
    private GameObject selim;

    private Rigidbody2D playerRb;
    private Rigidbody2D pedrilloRb;
    private Rigidbody2D konstanzeRb;
    private Rigidbody2D osminRb;
    private Rigidbody2D selimRb;

    public DialogueTrigger dialogueTrigger;
    public static bool freezePlayer = false;

    private int storyId = 0;

    void Start()
    {
        controlDoor1 = GameObject.Find("Door 1").GetComponent<ControlDoor>();
        controlDoor2 = GameObject.Find("Door 2").GetComponent<ControlDoor>();

        player = GameObject.Find("Player");
        pedrillo = GameObject.Find("Pedrillo");
        konstanze = GameObject.Find("Konstanze");
        osmin = GameObject.Find("Osmin");
        selim = GameObject.Find("Selim");

        playerRb = player.GetComponent<Rigidbody2D>();
        pedrilloRb = pedrillo.GetComponent<Rigidbody2D>();
        konstanzeRb = konstanze.GetComponent<Rigidbody2D>();
        osminRb = osmin.GetComponent<Rigidbody2D>();
        selimRb = selim.GetComponent<Rigidbody2D>();

        Execute(0);
    }

    private void FixedUpdate()
    {
        if (storyId == 1)
        {
            if (pedrilloRb.position.x != 2)
            {
                pedrilloRb.position = Vector3.MoveTowards(pedrilloRb.position,
                    new Vector3(2, pedrilloRb.position.y, 0), 0.1f);
            }
        }
    }

    public void Execute(int id)
    {
        Debug.Log("Story id: " + id);
        storyId = id;
        if (id == 0)
        {
            controlDoor1.OpenDoor();
            dialogueTrigger.StartDialogue();
        }
        else if (id == 1)
        {
            controlDoor1.CloseDoor();
        }
        else if (id == 2)
        {
        }
    }
}