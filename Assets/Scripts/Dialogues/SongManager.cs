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
    public GameObject globalNotes;
    public AudioSource ouverture;

    public static bool isSongActive = false;
    private string currentActor;
    private string currentLyrics;
    private Sprite currentActorSprite;
    private AudioSource currentAudioSource;

    public void OpenSongBox(string actor, string lyrics, Sprite actorSprite, AudioSource audio)
    {
        isSongActive = true;
        currentActor = actor;
        currentLyrics = lyrics;
        currentActorSprite = actorSprite;
        currentAudioSource = audio;
        ;
        if (FindObjectOfType<DialogueManager>().dialogueIndex == 1)
        {
            pedrilloNotes.SetActive(true);
        }
        else if (FindObjectOfType<DialogueManager>().dialogueIndex == 6)
        {
            osminNotes.SetActive(true);
        } else if (FindObjectOfType<DialogueManager>().dialogueIndex == 7)
        {
            globalNotes.SetActive(true);
        } else if (FindObjectOfType<DialogueManager>().dialogueIndex == 10)
        {
            globalNotes.SetActive(true);
        }

        DisplaySong();
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
        FindObjectOfType<DialogueManager>().dialogueIndex++;
    }

    void DisplaySong()
    {
        FindObjectOfType<AudioFade>().FadeOut(ouverture, 0.5f);
        ouverture.Pause();
        currentAudioSource.Play();
        actorName.text = currentActor;
        messageText.text = currentLyrics;
        actorImage.sprite = currentActorSprite;
    }

    void CloseSongBox()
    {
        currentAudioSource.Stop();
        ouverture.UnPause();
        FindObjectOfType<AudioFade>().FadeIn(ouverture, 0.5f);
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