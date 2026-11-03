using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuFunctions : MonoBehaviour
{
    public GameObject canvas;
    public int LV;
    public bool Paused = false;
    Scene scene;
    void Start()
    {
        canvas.SetActive(false);
        scene = SceneManager.GetActiveScene();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && Paused == false)
        {
            Time.timeScale = 0f;
            canvas.SetActive(true);
            Paused = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) && Paused == true)
        { 
            Time.timeScale = 1f;
            canvas.SetActive(false);   
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
}
