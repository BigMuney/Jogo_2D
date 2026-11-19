using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    public GameObject PanelGameOver;
    public GameObject PanelPause;
    public bool Paused = false;
    public bool dead = false;

    void Start()
    {
        // sets both scenes to false on start to prevent unwanted menus showing up
        PanelPause.SetActive(false);
        PanelGameOver.SetActive(false); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // when pressing scape pauses and unpauses
        {
            if (Paused)
            {   resume();  }
            else 
            {    pause();  }
        }
    }
    public void pause()
    {
        if (dead == false) // this prevents the menu from showing up while another would be
        {
            Paused = true; 
            PanelPause.SetActive(true);// activates the pause screen
            Time.timeScale = 0f; // stops the time so that the things in the game dont move
        }
    }
    public void resume()
    {
        Paused = false;
        PanelPause.SetActive(false); //deactivates the pause screen
        Time.timeScale = 1f; //sets the time to its normal ammount
    }
    public void ShowGameOver()
    {
        dead = true; // is used to make sure the game knows which state its in
        PanelGameOver.SetActive(true); // activates gameover screen
        Time.timeScale = 0f; // stops the time in the game
    }
    public void Resetlevel()
    {
        Time.timeScale = 1f; // sets time to norma
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // reloads the scene by name
    }
    public void ToMenu()
    {
        SceneManager.LoadScene(0);// scene 0 is the menu, this send the player to it
    }
}
