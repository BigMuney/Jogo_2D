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
        if (Input.GetKeyDown(KeyCode.P) && Paused == false)
        {
            Time.timeScale = 0f;
            PauseMenu.SetActive(true);
            Paused = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) && Paused == true)
        { 
            Time.timeScale = 1f;
            PauseMenu.SetActive(false);   
            Paused = false ;
        }
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(scene.buildIndex);
        Time.timeScale = 1f;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(scene.buildIndex + 1);
        Time.timeScale = 1f;
    }
    public void PrevLevel()
    {
        SceneManager.LoadScene(scene.buildIndex - 1);
        Time.timeScale = 1f;
    }
}
