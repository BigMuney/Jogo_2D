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
        if (collision.CompareTag("Player")) // this detects if the crystal is touching the player
        {
            Collider.enabled = false; // turns off the colider so the player cannot interact with it
            SR.enabled = false; // turns off the sprite renderer so the player cannot see it
            timer = true; // starts the timer
            counter = 0;
        }
    }
    private void Update()
    {
        if (timer)
        {   
            if (counter <=120) // 2 second timer to respawn the crystal
            {
                counter++;
            }
            else
            {
                SR.enabled=true;
                Collider.enabled=true;
                timer = false;
                //sets renderer colider to true allowing the player to interact with it again, and stops the timer
            }
        }
    }
}
