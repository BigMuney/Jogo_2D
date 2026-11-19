using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScript : MonoBehaviour
{
    public bool Throphy;
    public GameObject ThrophyScreen;
    public GameObject VictoryScreen;
    public bool Victory = false;
    Scene scene;
    void Start()
    {
        VictoryScreen.SetActive(false);
        scene = SceneManager.GetActiveScene();
        ThrophyScreen.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Throphy) // this checks if the current winbox is a throphy one
        {
            ThrophyScreen.SetActive(true); // triggers the throphy win screen
            Victory = true; // grants victory
            Time.timeScale = 0f; // sets timescale to 0 
        }
        else // this triggers the regular victory screen
        {
            Time.timeScale = 0f; // timescale is set to 0 
            VictoryScreen.SetActive(true); // activates the victory sc
            Victory = true;
        }

    }
    public void RestartScene() //  reloads the scene by scene name
    {
        Time.timeScale = 1f; // timescale is set to 1 (normal)
        Victory = false; // turns off victory
        SceneManager.LoadScene(scene.buildIndex);
    }

    public void NextLevel()// loads scene by adding 1 to current scene build index 
    {
        Victory = false; //turns off victory
        Time.timeScale = 1f; // timescale set to 1 (normal
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
    public void ToMenu()
    {
        SceneManager.LoadScene(0); // menu is scene 0 and this brings the player to it
    }
}
