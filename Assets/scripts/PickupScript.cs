using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class PickupScript : MonoBehaviour
{
    bool timer = false;
    public int counter;
    public SpriteRenderer SR;
    public Collider2D Collider;
    private void Start()
    {
        Collider = GetComponent<Collider2D>();
        SR = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("should be turned off");
            Collider.enabled = false;
            SR.enabled = false;
            timer = true; 
            counter = 0;
        }
    }
    private void Update()
    {
        if (timer)
        {
           
            if (counter <=120)
            {
                counter++;
            }
            else
            {
                gameObject.SetActive(true);
                SR.enabled=true;
                Collider.enabled=true;
                timer = false;
            }
        }
    }
}
