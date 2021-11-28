using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;
public class LevelManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Skull Chrusher");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    public void Playagain()
    {
        SceneManager.LoadScene("Level 2");
    }
}