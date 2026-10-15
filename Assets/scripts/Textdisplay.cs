using UnityEngine;

public class Textdisplay : MonoBehaviour
{
    public GameObject text;
    void Start()
    {
        text.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            text.SetActive(false); 
        
        }
    }
     
}
