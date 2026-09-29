using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{
    public float Velocity, MaxSpeedL, MaxSpeedR, TimeCounter, CayoteTime, MinSpeed;
    public int JumpPower, Speed, jumpcount;
    public bool CanJump = false;
    public bool jumped = false;
    public bool OnWall = false;
    public bool ClockStart = false;
    public bool FacingRight = true;
    public int Direction = 1;
    public Rigidbody2D RB;
    public BoxCollider2D Collider;
    [SerializeField] private Crystals crystals;

    void Start()
    {
        crystals = GetComponent<Crystals>();
        RB = GetComponent<Rigidbody2D>();
        Collider = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumped = false;
        if (collision.collider.CompareTag("hazard")) // code responsible for reseting the scene on death
        {
            SceneManager.LoadScene(0);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.collider.CompareTag("Wall"))
        {
            OnWall = true;
            CanJump = true; 
        }
        if (collision.collider.CompareTag("Ground"))
        {
            CanJump = true;
            if (jumped == false) 
            {
                jumpcount = 1; 
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            ClockStart = true;
        }
        if (collision.collider.CompareTag("Wall"))
        {
            OnWall = false;
            ClockStart = true;
        
        }
    }
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            float movedirection = Input.GetAxis("Horizontal");

            RB.linearVelocityX = (MinSpeed * movedirection) + movedirection * Speed;
            FacingRight = (movedirection > 0) ? true : false;
            Direction = (FacingRight == true) ? 1 : -1;

        }
        if (Input.GetKeyDown("space") == true && CanJump == true & jumpcount >= 1)
        {
            if (OnWall) // this script makes it so that if you're in contacts with a wall and jump you'll go the oposite way
            {
                RB.linearVelocityY = JumpPower;
                RB.linearVelocityX = (JumpPower / 2) * -Direction;
                jumpcount -= 1;
                jumped = true;
            }
            else
            {
                if (RB.linearVelocityY > JumpPower)
                {
                    RB.linearVelocityY = RB.linearVelocityY + (JumpPower / 2f); // if the velocity is higher than the power of the jump than add extra velocity
                    jumpcount -= 1;
                    jumped = true;
                }
                else
                {
                    RB.linearVelocityY = JumpPower;
                    jumpcount -= 1;
                    jumped = true;
                }
            }
        }
        if (ClockStart) // this script is the one that runs cayote time
        {
            if (jumped == true)
            {
                ClockStart = false;
                TimeCounter = 0;
            }
            TimeCounter += 0.05f; // every frame adds 0.05 to the timer, meaning it takes 4 frames to run out
            if (TimeCounter > CayoteTime)
            {
                jumpcount = jumpcount - 1;
                ClockStart = false;
                TimeCounter = 0f;
            }
        }

    }
}
