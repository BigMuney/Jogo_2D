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
        PanelPause.SetActive(false);
        PanelGameOver.SetActive(false); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                resume();
            }
            else 
            { 
                pause();
            }
        }
    }
    public void pause()
    {
        if (dead == false)
        {
            Paused = true;
            PanelPause.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void resume()
    {
        Paused = false;
        PanelPause.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ShowGameOver()
    {
        dead = true;
        PanelGameOver.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Reset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
