using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongTrigger : MonoBehaviour
{
    public string actor;
    public string lyrics;
    public Sprite actorSprite;
    
    public void StartSong()
    {
        FindObjectOfType<SongManager>().OpenSongBox(actor, lyrics, actorSprite);
    }
}
