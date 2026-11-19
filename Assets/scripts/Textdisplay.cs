using UnityEngine;

public class Textdisplay : MonoBehaviour
{
    public GameObject text;
    void Start()
    {
        text.SetActive(false); // sets the message to false when scene is loaded
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // once it detects the player the message is activated
        {
            text.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // once the player leaves the trigger it shuts off the message
        { 
            text.SetActive(false); 
        }
    }
     
}
