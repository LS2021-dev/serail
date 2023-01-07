using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
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

    public DialogueTrigger dialogueTrigger1;
    public DialogueTrigger dialogueTrigger2;
    public DialogueTrigger dialogueTrigger4;
    public SongTrigger songTrigger6;
    public SongTrigger songTrigger7;
    
    public GameObject pedrilloHearts;
    public GameObject pedrilloNotes;
    public GameObject osminNotes;

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
        else if (storyId == 3)
        {
            if (pedrilloRb.position.x != 4)
            {
                pedrilloRb.position = Vector3.MoveTowards(pedrilloRb.position,
                    new Vector3(4, pedrilloRb.position.y, 0), 0.1f);
            }
        }
        else if (storyId == 5)
        {
            if (konstanzeRb.position.x != 9)
            {
                konstanzeRb.position = Vector3.MoveTowards(konstanzeRb.position,
                    new Vector3(9, konstanzeRb.position.y, 0), 0.1f);
            }

            if (playerRb.position.x != 8)
            {
                playerRb.position = Vector3.MoveTowards(playerRb.position,
                    new Vector3(8, playerRb.position.y, 0), 0.1f);
            }

            if (osminRb.position.x != 13)
            {
                osminRb.position = Vector3.MoveTowards(osminRb.position,
                    new Vector3(13, osminRb.position.y, 0), 0.1f);
            }
        } else if (storyId == 8)
        {
            if (selimRb.position.x != 16)
            {
                selimRb.position = Vector3.MoveTowards(selimRb.position,
                    new Vector3(16, selimRb.position.y, 0), 0.1f);
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
            dialogueTrigger1.StartDialogue();
        }
        else if (id == 1)
        {
            controlDoor1.CloseDoor();
        }
        else if (id == 2)
        {
            dialogueTrigger2.StartDialogue();
            pedrilloNotes.SetActive(false);
        }
        else if (id == 4)
        {
            pedrilloHearts.SetActive(true);
            StartCoroutine(TriggerDialogue4(1.5f));
        }
        else if (id == 5)
        {
            konstanzeRb.gravityScale = 3.5f;
            konstanze.GetComponent<Konstanze>().handsUp = false;
            GameObject.Find("Dialogue_5").GetComponent<TransformTrigger>().enabled = true;
            controlDoor2.OpenDoor();
            osmin.GetComponent<SpriteRenderer>().enabled = true;
            player.GetComponent<Player>().faceRight = true;
        }
        else if (id == 6)
        {
            osminNotes.SetActive(true);
            songTrigger6.StartSong();
        }
        // else if (id == 7)
        // {
        //     osminNotes.SetActive(false);
        //     // songTrigger7.StartSong();
        // }
        // else if (id == 8)
        // {
        //     selim.GetComponent<SpriteRenderer>().enabled = true;
        // }
    }

    private IEnumerator TriggerDialogue4(float delay)
    {
        yield return new WaitForSeconds(delay);
        dialogueTrigger4.StartDialogue();
    }
}