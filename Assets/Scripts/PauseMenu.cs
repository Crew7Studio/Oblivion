using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public string mainMenu;

    public bool isPaused;
    public GameObject pauseMenuCanvas;

    void Start()
    {
        
    }

    void Update()
    {
        if(isPaused)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
    }

    public void Resume()
    {
        isPaused = false;
    }

    public void MainMenu()
    {
        Application.LoadLevel(mainMenu);
    }

    public void Quit()
    {
        Application.Quit();   
    }
}
