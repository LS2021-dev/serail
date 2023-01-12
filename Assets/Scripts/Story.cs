using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public DialogueTrigger dialogueTrigger6;
    public DialogueTrigger dialogueTrigger7;
    public SongTrigger songTrigger2;
    public SongTrigger songTrigger3;
    public SongTrigger songTrigger4;

    public GameObject pedrilloHearts;
    public GameObject pedrilloNotes;
    public GameObject osminNotes;
    public GameObject globalNotes;
    
    public AudioSource ouverture;

    private int storyId = 0;
    public static bool freezePlayer = false;

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
        
        Cursor.visible = false;

        Execute(0);
    }

    private void FixedUpdate()
    {
        if (storyId == 1)
        {
            pedrilloRb.position = Vector3.MoveTowards(pedrilloRb.position,
                new Vector3(2, pedrilloRb.position.y, 0), 0.1f);
        }
        else if (storyId == 3)
        {
            pedrilloRb.position = Vector3.MoveTowards(pedrilloRb.position,
                new Vector3(4, pedrilloRb.position.y, 0), 0.1f);
        }
        else if (storyId == 5)
        {
            konstanzeRb.position = Vector3.MoveTowards(konstanzeRb.position,
                new Vector3(9, konstanzeRb.position.y, 0), 0.1f);
            playerRb.position = Vector3.MoveTowards(playerRb.position,
                new Vector3(8, playerRb.position.y, 0), 0.1f);
            osminRb.position = Vector3.MoveTowards(osminRb.position,
                new Vector3(13, osminRb.position.y, 0), 0.1f);
        }
        else if (storyId == 8)
        {
            selimRb.position = Vector3.MoveTowards(selimRb.position,
                new Vector3(12, selimRb.position.y, 0), 0.1f);
        }
        else if (storyId == 9)
        {
            pedrilloRb.position = Vector3.MoveTowards(pedrilloRb.position,
                new Vector3(11, pedrilloRb.position.y, 0), 0.1f);
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
            freezePlayer = true;
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
            StartCoroutine(WaitForOsmin());
            songTrigger2.StartSong();
        }
        else if (id == 7)
        {
            osminNotes.SetActive(false);
            songTrigger3.StartSong();

        }
        else if (id == 8)
        {
            selim.GetComponent<SpriteRenderer>().enabled = true;
            StartCoroutine(WaitForSelim());
        }
        else if (id == 9)
        {
            StartCoroutine(WaitForPedrillo());
        }
        else if (id == 10)
        {
            songTrigger4.StartSong();
        }
        else if (id == 11)
        {
            globalNotes.SetActive(false);
            FindObjectOfType<AudioFade>().FadeOut(ouverture, 3f);
            StartCoroutine(End());
        }
    }

    private IEnumerator TriggerDialogue4(float delay)
    {
        yield return new WaitForSeconds(delay);
        dialogueTrigger4.StartDialogue();
    }

    private IEnumerator WaitForOsmin()
    {
        yield return new WaitUntil(() => osminRb.position.x == 13);
        osminNotes.SetActive(true);
    }

    private IEnumerator WaitForSelim()
    {
        yield return new WaitUntil(() => selimRb.position.x == 12);
        globalNotes.SetActive(false);
        dialogueTrigger6.StartDialogue();
    }

    private IEnumerator WaitForPedrillo()
    {
        yield return new WaitUntil(() => pedrilloRb.position.x == 11);
        pedrillo.GetComponent<Pedrillo>().isKneeling = true;
        freezePlayer = false;
        dialogueTrigger7.StartDialogue();
    }

    private IEnumerator End()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("End");
    }
}