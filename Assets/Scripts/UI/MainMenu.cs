using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsMenuUI;

    void Start()
    {
        Cursor.visible = true;
    }

    public void StartButton()
    {
        GetComponent<AudioSource>().Stop();
        FindObjectOfType<LevelLoader>().LoadNextLevel();
    }

    public void OptionsButton()
    {
        settingsMenuUI.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}