using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour
{
    private ControlDoor door1;

    void Start()
    {
        // call the function to open the door
        door1 = GameObject.Find("Door 1").GetComponent<ControlDoor>();
        door1.OpenDoor();
    }

    public static void Execute(int id)
    {
        Debug.Log("Story " + id);
    }
}
