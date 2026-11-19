using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseScript : MonoBehaviour
{
    public GameObject PauseMenu;
    public bool Paused = false;
    Scene scene;
    void Start()
    {
        PauseMenu.SetActive(false);
        scene = SceneManager.GetActiveScene();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && Paused == false) // when pressing P and the game is unpaused, it pauses the game
        {
            Time.timeScale = 0f; // sets the timescale to 0 to stop any movement
            PauseMenu.SetActive(true); // shows the pause menu
            Paused = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) && Paused == true)
        { 
            Time.timeScale = 1f; // returns time back to normal
            PauseMenu.SetActive(false); // deactivates the pause menu
            Paused = false ;
        }
    }
    public void RestartScene() // function on menu ment to restart the current scene, it returns time to normal and reloads the current scene by index
    {   
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene.buildIndex);
    }

    public void NextLevel() // function on menu to get player to next level, it returns time to normal and adds 1 to the current build's build index and loads it
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
    public void PrevLevel()// function on menu to get player to the previous level, it returns time to normal and subtracts 1 from the current scene build index
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene.buildIndex - 1);
    }
}
