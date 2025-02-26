using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI; //refernece to the pause menu ui

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   //game is already paused when pressing escape
        {
           if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }
        
    public void Resume ()
    {
        
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        
    }

    void Pause ()
    {
        
        pauseMenuUI.SetActive(true); //bring up pause menu
        Time.timeScale = 0f;
        GameIsPaused = true;
        
        
    }

    public void RestartGame ()
    {
        Time.timeScale = 1;
        
        SceneManager.LoadScene("Full Game");
        

    }
     
    public void QuitGame ()
    {
        
        Application.Quit();
        Debug.Log("Game is exiting");
    }
            
}
