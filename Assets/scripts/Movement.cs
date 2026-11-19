using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{
    public int targetFPS = 60; // Set your desired FPS
    public float TimeCounter, Speedloss;
    public int JumpPower, Speed, jumpcount, MaxSpeed, CayoteTime;
    public bool CanJump = false;
    public bool jumped = false;
    public bool OnWall = false;
    public bool ClockStart = false;
    public bool FacingRight = true;
    public int Direction = 1;
    public bool onsurface;
    Scene scene;
    public Rigidbody2D RB;
    public BoxCollider2D Collider;
    [SerializeField] private Crystals crystals;

    void Start()
    {
        Application.targetFrameRate = targetFPS; // this makes sure the frame rate is consistant

        scene = SceneManager.GetActiveScene();
        crystals = GetComponent<Crystals>();
        RB = GetComponent<Rigidbody2D>();
        Collider = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumped = false;
        if (collision.collider.CompareTag("hazard")) // code responsible for reseting the scene on death
        {
            Time.timeScale = 1f; // this line in specific is to prevent the game from freezing because of the school player script, delete this for optimization once school stuff is done, or not idk maybe it helps the game not bug 
            SceneManager.LoadScene(scene.buildIndex); // Scene will reset itself once it touches a hazard
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")) 
        {
            CanJump = true; // allows the player to jump, this is so there are more safeguards to jumping
            if (jumped == false) 
            {
                jumpcount = 1; //gives the player 1 jump
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        onsurface = false;
        if (collision.collider.CompareTag("Ground"))

        {
            ClockStart = true; // this triggers the cayote time when the player leaves the groud
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) //script handles left and right movement
        {  
        float movedirection = Input.GetAxis("Horizontal"); // this code returns -1,0,1 depending on the current status of how the player is using the arrow keys
        FacingRight = (movedirection > 0) ? true : false; // this code uses the direction to figure out the direction the player is facing
        Direction = (FacingRight == true) ? 1 : -1; // this code uses the direction and translates that to a int used in the math to move the player the right direction
            
            if (FacingRight == true) //this code handles movement to the right
            {
                if (RB.linearVelocityX < MaxSpeed * Direction)
                {
                    RB.linearVelocityX = RB.linearVelocityX + Speed * Direction; // this handles the acceleration to the right
                    if (RB.linearVelocityX > MaxSpeed * Direction)  // this conditional limits the speed to the max
                    { 
                        RB.linearVelocityX = MaxSpeed * Direction;
                    }
                }
                else
                {
                    RB.linearVelocityX = RB.linearVelocityX * 0.999f; // when moving in a direction that youre going over the max walk speed, it slows down gradually
                }
            }
            if (FacingRight == false) // this code handles movement to the left
            {
                if (RB.linearVelocityX > MaxSpeed * Direction)
                {
                    RB.linearVelocityX = RB.linearVelocityX + Speed * Direction; //acceleration to the left
                    if (RB.linearVelocityX < MaxSpeed * Direction)
                    {
                        RB.linearVelocityX = MaxSpeed * Direction; //limits speed to the max
                    }
                }
                else
                {
                    RB.linearVelocityX = RB.linearVelocityX * 0.999f; // when moving in a direction that youre going over the max walk speed, it slows down gradually
                }
            }
        }
        else 
        {
                RB.linearVelocity = new Vector2(RB.linearVelocity.x/Speedloss, RB.linearVelocity.y); //simulates friction
        }
        if (Input.GetKeyDown(KeyCode.Z) == true && CanJump == true & jumpcount >= 1) // this is the code that handles jumping
        {
                if (RB.linearVelocityY > JumpPower)
                {
                    RB.linearVelocityY = RB.linearVelocityY + (JumpPower / 2f); // if the velocity is higher than the power of the jump than add extra velocity
                    jumpcount -= 1;
                    jumped = true;
                }
                else // when the player has less horizontal momentum than the 
                {
                    RB.linearVelocityY = JumpPower;
                    jumpcount -= 1;
                    jumped = true;
                }
        }
        if (ClockStart) // this script is the one that runs cayote time
        {
            if (jumped == true) // if the player has jumped cayote time gets canceled
            {
                ClockStart = false;
                TimeCounter = 0;
            }
            TimeCounter += 1; // every frame adds 1 to the timer, the cayote time is how long till it adds up to it
            if (TimeCounter > CayoteTime) // once the code is done, it lets the player fall to their death lmao get good ez no re
            {
                jumpcount = jumpcount - 1;
                ClockStart = false;
                TimeCounter = 0f; //restarts the clock
            }
        }
    }
}
