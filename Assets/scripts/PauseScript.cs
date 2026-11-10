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
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene.buildIndex);
    }

    public void NextLevel()
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
    public void PrevLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene.buildIndex - 1);
    }
}
