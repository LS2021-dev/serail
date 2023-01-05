using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectTrigger : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueTrigger.StartDialogue();
        }
    }
}
