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
        
        //SceneManager.LoadScene("Ryan");
        Debug.Log("Restarting Game....");

    }
     
    public void QuitGame ()
    {
        
        Application.Quit();
        Debug.Log("Game is exiting");
    }
            
}
