using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused;
    public GameObject pauseUI;
    public void TogglePause()
    {
        if (IsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    public void Resume(){
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause(){
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadMenu(){
        Time.timeScale = 1f;
        //SceneManager.LoadScene("Settings"); 
    }
    public void QuitGame(){
        Time.timeScale = 1f;
        GameManager.Instance.SaveManager.SaveGame();
        SceneManager.LoadScene("MainMenu");
    }
    public void OnDestroy()
    {
        IsPaused = false;
    }
}
