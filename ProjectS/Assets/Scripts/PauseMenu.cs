using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused;
    public GameObject pauseUI;
    void Update()
    {
        if (true){ //get input
            if (IsPaused){
                Resume();
            }
            else{
                Pause();
            }
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
        //SceneManager.LoadScene("Main_Menu");
    }
    public void OnDestroy()
    {
        IsPaused = false;
    }
}
