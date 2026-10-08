using UnityEngine;

public class Crystals : MonoBehaviour
{
    public int[] inventory = new int[3];
    public int currentinv;
    public int extrajump;
    public string crystal;
    [SerializeField] private Movement movement;
    void Start()
    {
        currentinv = 0;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) // this code is responsible for looping through the inventory
        {
            currentinv++;
            if (currentinv >= inventory.Length)
            {
                currentinv = 0;
            }
          
        }
       
        if (inventory[currentinv] == 1) // this code is responsible for the wing crystal
        {
            crystal = "wings";
            Debug.Log(currentinv);
            Debug.Log("asa");
            if (Input.GetKeyDown(KeyCode.X))
            {
                if( movement.RB.linearVelocityY < 0)
                {
                    movement.RB.linearVelocityY = 0;
                }
                movement.RB.linearVelocityY = movement.RB.linearVelocityY + movement.JumpPower * 1.25f; // the multiplier is an arbitrary number, 
                inventory[currentinv] = 0;
            }
        }
        else if (inventory[currentinv] == 2) // this code is responsible for the dash crystal
        {
            Debug.Log(currentinv);
            Debug.Log("dash");
            crystal = "dash";
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (movement.onsurface == false)
                {
                    movement.RB.linearVelocityY = 2f;
                }
                movement.RB.linearVelocityX = movement.RB.linearVelocityX + (movement.JumpPower / 1.5f) * movement.Direction;
                inventory[currentinv] = 0;
            }
        }
        else if (inventory[currentinv] == 0)
        {
            crystal = "nothing";
        }
        Debug.Log(currentinv + " " + crystal);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (inventory[currentinv] == 0) // checks if current inv is empty
        {
            //the scripts under this are simply to apply said crystal to the current inv
            if (collision.CompareTag("wings")) 
            {
            Debug.Log("touchedwings");
                inventory[currentinv] = 1;
            }
            if (collision.CompareTag("dash"))
            {
                Debug.Log("toucheddash");
                inventory[currentinv] = 2;
            }
        } 
    }
}
