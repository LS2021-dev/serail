using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Wie schafft man, dass das importiert wird?
    public GameObject settingsMenuUI;

    public void StartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OptionsButton()
    {
        throw new NotImplementedException();
    }

    public void QuitButton()
    {
        Application.Quit();
    }
    
}
