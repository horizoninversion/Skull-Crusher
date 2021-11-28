using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject joystick;
    void Update()
    {
        if(CrossPlatformInputManager.GetButtonDown("Cancel"))
        {
            if(GameIsPaused)
            {
                Resume();

            }
            else {
                Pause();
            }
        }
        
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        joystick.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        joystick.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Menu");        
        }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}

