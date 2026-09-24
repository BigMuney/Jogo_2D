using UnityEngine;

public class Crystals : MonoBehaviour
{
    public int[] inventory = new int[3];
    public int currentinv;
    public int extrajump;
    [SerializeField] private Movement movement;
    void Start()
    {
        currentinv = 0;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (inventory[currentinv] == 1)
            {
                movement.jumpcount -= 1;
            }
            currentinv++;
            if (currentinv >= inventory.Length )
            {
                currentinv = 0;
            }
            Debug.Log(inventory.Length);
        }
        if (inventory[currentinv] == 1)
        {
            extrajump = 1;
            if ( movement.jumpcount == 0)
            {
                inventory[currentinv] = 0;
            }
            } else {
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
            Debug.Log("touchedwings");
            if (inventory[currentinv] == 0)
            {
                inventory[currentinv] = 1;
                movement.jumpcount += 1;
            }
        }
    }
}
