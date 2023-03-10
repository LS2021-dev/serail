using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongTrigger : MonoBehaviour
{
    public string actor;
    public string lyrics;
    public Sprite actorSprite;
    public AudioSource audioSource;
    public bool wait;

    public void StartSong()
    {
        if (wait)
        {
            StartCoroutine(Wait());
        }
        else
        {
            FindObjectOfType<SongManager>().OpenSongBox(actor, lyrics, actorSprite, audioSource);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<SongManager>().OpenSongBox(actor, lyrics, actorSprite, audioSource);
    }
}