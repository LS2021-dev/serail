using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongTrigger : MonoBehaviour
{
    public string lyrics;
    public string actor;
    public Sprite actorSprite;
    
    public void StartSong()
    {
        FindObjectOfType<SongManager>().OpenSongBox(actor, lyrics, actorSprite);
    }
}
