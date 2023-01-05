using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
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

    private Transform playerTransform;
    private Transform pedrilloTransform;
    private Transform konstanzeTransform;
    private Transform osminTransform;
    private Transform selimTransform;

    public DialogueTrigger dialogueTrigger;

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

        playerTransform = player.GetComponent<Transform>();
        pedrilloTransform = pedrillo.GetComponent<Transform>();
        konstanzeTransform = konstanze.GetComponent<Transform>();
        osminTransform = osmin.GetComponent<Transform>();
        selimTransform = selim.GetComponent<Transform>();

        Execute(0);
    }

    private void Update()
    {
        // osminTransform.position = Vector2.MoveTowards(osminTransform.position, new Vector2(0, osminTransform.position.y), 3f * Time.deltaTime);
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
    }
}