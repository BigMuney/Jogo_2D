using UnityEngine;

public class Crystals : MonoBehaviour
{
    public int[] inventory = new int[3];
    public int currentinv;
    public int extrajump;
    public SpriteRenderer sprite;
    public string crystal;
    [SerializeField] private Movement movement;
    void Start()
    {
        currentinv = 0;
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) // this code is responsible for looping through the inventory
        {
            currentinv++; // adds to the ID of the inventories
            if (currentinv >= inventory.Length) // once it reaches more than it's max, it goes back to zero
            {
                currentinv = 0;
            }
          
        }
       
        if (inventory[currentinv] == 1) // this code is responsible for the wing crystal
        {
            crystal = "wings";
            sprite.color = Color.darkBlue;
            if (Input.GetKeyDown(KeyCode.X))
            {
                if( movement.RB.linearVelocityY < 0) // this script makes sure that if the player is falling, their vertical speed will be set to nothing before any crystal changes are applied
                {
                    movement.RB.linearVelocityY = 0;
                }
                movement.RB.linearVelocityY = movement.RB.linearVelocityY + movement.JumpPower * 1.25f; // the multiplier is an arbitrary number, it also adds to whichever speed the player is already going, if its upwards, to where they can stack momentum
                inventory[currentinv] = 0;
            }
        }
        else if (inventory[currentinv] == 2) // this code is responsible for the dash crystal
        {
            sprite.color = Color.yellow;
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (movement.onsurface == false)
                {
                    movement.RB.linearVelocityY = 2f; // this stops the vertical momentum of the player completly than adds 2f, this is so it feels like a dash in the air
                }
                movement.RB.linearVelocityX = movement.RB.linearVelocityX + (movement.JumpPower / 1.5f) * movement.Direction; // this works by increasing the horizontal movement of the player by a factor stronger than its jump
                inventory[currentinv] = 0; // this sets the place that the wing is stored back to zero, so there's nothing
            }
        }
        else if (inventory[currentinv] == 0) // this script handles what happens when there's no crystal being held
        {
            sprite.color = Color.lightBlue;
            crystal = "nothing";
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (inventory[currentinv] == 0) // checks if current inv is empty
        {
            //the scripts under this are simply to apply said crystal to the current inv
            if (collision.CompareTag("wings")) 
            {
                inventory[currentinv] = 1; // when colliding with the wing crystal this sets the selected inventory to the ID of the wing crystal
            }
            if (collision.CompareTag("dash"))
            {
                inventory[currentinv] = 2;// when colliding with the dash crystal this sets the selected inventory to the ID of the dash crystal
            }
        } 
    }
}
