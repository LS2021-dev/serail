using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsMenuUI;
    public AudioSource audioSource;

    void Start()
    {
        Cursor.visible = true;
    }

    public void StartButton()
    {
        GetComponent<AudioSource>().Stop();
        FindObjectOfType<AudioFade>().FadeOut(audioSource, 1f);
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