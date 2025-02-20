using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void RestartGame ()
    {
        Time.timeScale = 1;
        Debug.Log("Restarting Game....");
        //SceneManager.LoadScene("Ryan");

    }

    public void QuitGame ()
    {
        Debug.Log("Quitting Game..... ");
        Application.Quit();
    }
            
}
