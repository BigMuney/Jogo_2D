using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public void StartGame() // this function sets the time to normal and loads the first level scene
    {
        Time.timeScale = 1f; // time goes back to normal
        SceneManager.LoadScene(1); // scene 1 is the first level of the game
    }
    public void CloseGame()
    {
        Application.Quit(); // quit apps
    }
     
}

