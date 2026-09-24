using UnityEngine;

public class Crystals : MonoBehaviour
{
    public int[] inventory = new int[1];
    public int currentinv;
    public int extrajump;
    void Start()
    {
        currentinv = 0;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentinv++;
            if (currentinv > (inventory.Length -1))
            {
                currentinv = 0;
            }
          
        }
            if (inventory[currentinv] == 1)
            {
                extrajump = 1;
            } else
            {
                extrajump = 0;
            }
        
            
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("wings"))
        {
            inventory[currentinv] = 1;
            Debug.Log("touchedwings");
        }
    }

}
