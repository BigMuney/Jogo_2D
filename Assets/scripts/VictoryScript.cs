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
        if (Throphy)
        {
            ThrophyScreen.SetActive(true);
            Victory = true;
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 0f;
            VictoryScreen.SetActive(true);
            Victory = true;
        }

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
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
