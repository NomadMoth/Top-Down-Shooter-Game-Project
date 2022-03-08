using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;

    public GameObject pauseMenuUI;

    void Start()
    {
        Resume();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    void LoadMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    void QuitGame()
    {
        Debug.Log("QUITTING GAME");
        Application.Quit();
    }
}
