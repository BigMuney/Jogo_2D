using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScript : MonoBehaviour
{
    public GameObject VictoryScreen;
    public bool Victory = false;
    Scene scene;
    void Start()
    {
        VictoryScreen.SetActive(false);
        scene = SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0f;
        VictoryScreen.SetActive(true);
        Victory = true;

    }
    public void RestartScene()
    {
        Time.timeScale = 1f;
        Victory = false;
        SceneManager.LoadScene(scene.buildIndex);
    }

    public void NextLevel()
    {
        Victory = false; 
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene.buildIndex + 1);
    }

}
