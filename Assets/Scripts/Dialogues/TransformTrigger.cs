using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformTrigger : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private CircleCollider2D circleCollider;
    public DialogueTrigger dialogueTrigger;
    public SongTrigger songTrigger;
    public bool isSong;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        circleCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boxCollider.OverlapPoint(transform.position) || circleCollider.OverlapPoint(transform.position))
        {
            this.GetComponent<TransformTrigger>().enabled = false;
            if (isSong)
            {
                songTrigger.StartSong();
            }
            else
            {
                dialogueTrigger.StartDialogue();
            }
        }
    }
}