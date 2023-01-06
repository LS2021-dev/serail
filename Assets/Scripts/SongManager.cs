using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SongManager : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;

    public GameObject notesPedrillo;
    public GameObject notesOsmin;

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
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
        FindObjectOfType<DialogueManager>().dialogueIndex++;
        DisplaySong();
        if (FindObjectOfType<DialogueManager>().dialogueIndex == 2)
        {
            GameObject.Find("Romanze_Pedrillo").SetActive(false);
            notesPedrillo.SetActive(true);
        }
    }

    void DisplaySong()
    {
        actorName.text = currentActor;
        messageText.text = currentLyrics;
        actorImage.sprite = currentActorSprite;
    }

    void CloseSongBox()
    {
        backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
        FindObjectOfType<Story>().Execute(FindObjectOfType<DialogueManager>().dialogueIndex);
        isSongActive = false;
        if (FindObjectOfType<DialogueManager>().dialogueIndex == 2)
        {
            notesPedrillo.SetActive(false);
        }
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