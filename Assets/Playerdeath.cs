using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerdeath : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -4) {
            SceneManager.LoadScene("Full Game");
        }
    }
}
