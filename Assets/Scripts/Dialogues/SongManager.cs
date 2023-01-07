using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SongManager : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;

    public GameObject pedrilloNotes;
    public GameObject osminNotes;
    
    public static bool isSongActive = false;
    private string currentActor;
    private string currentLyrics;
    private Sprite currentActorSprite;

    public void OpenSongBox(string actor, string lyrics, Sprite actorSprite)
    {
        isSongActive = true;
        currentActor = actor;
        currentLyrics = lyrics;
        currentActorSprite = actorSprite;
        if (FindObjectOfType<DialogueManager>().dialogueIndex == 2)
        {
            pedrilloNotes.SetActive(true);
        }
        DisplaySong();
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
        FindObjectOfType<DialogueManager>().dialogueIndex++;
    }

    void DisplaySong()
    {
        actorName.text = currentActor;
        messageText.text = currentLyrics;
        actorImage.sprite = currentActorSprite;
    }

    void CloseSongBox()
    {
        Debug.Log("HI");
        backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
        FindObjectOfType<Story>().Execute(FindObjectOfType<DialogueManager>().dialogueIndex);
        isSongActive = false;
    }

    private void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    void Update()
    {
        if (isSongActive && Input.GetKeyDown(KeyCode.Space))
        {
            CloseSongBox();
        }
    }
}