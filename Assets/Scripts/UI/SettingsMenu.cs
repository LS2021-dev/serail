using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("masterVolume", volume);
    }
    public void SetDialoguesVolume(float volume)
    {
        audioMixer.SetFloat("dialoguesVolume", volume);
    }
    public void SetSongsVolume(float volume)
    {
        audioMixer.SetFloat("songsVolume", volume);
    }

    public void SetBackgroundMusicVolume(float volume)
    {
        audioMixer.SetFloat("backgroundMusicVolume", volume);
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            settingsMenuUI.SetActive(false);
        }
    }
}
