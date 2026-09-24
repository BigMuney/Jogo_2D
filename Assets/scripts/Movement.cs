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
    bool OnWall = false;
    bool ClockStart = false;
    bool FacingRight = true;
    int Direction = 1;
    public Rigidbody2D RB;
    public BoxCollider2D Collider;
    [SerializeField] private Crystals crystals;

    void Start()
    {
        crystals = GetComponent<Crystals>();
        RB = GetComponent<Rigidbody2D>();
        Collider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {

        if (Input.GetAxis("Horizontal") != 0)
            {
            float movedirection = Input.GetAxis("Horizontal");

            RB.linearVelocityX = (MinSpeed * movedirection) + movedirection * Speed * ( Time.deltaTime * 10 );
            FacingRight = (movedirection > 0) ? true : false;
            Direction = (FacingRight == true) ? 1 : -1;

        }
        if (Input.GetKeyDown("space") == true && CanJump == true & jumpcount >=1)
        {
            if (OnWall)
            {
                RB.linearVelocityY = JumpPower;
                RB.linearVelocityX = (JumpPower/2) * -Direction;
                
            }
            else
            {
                if (RB.linearVelocityY > JumpPower)
                {
                    RB.linearVelocityY = RB.linearVelocityY + (JumpPower / 2f);
                    jumpcount =-1;
                }
                else
                {
                    RB.linearVelocityY = JumpPower;
                    jumpcount =-1 ;

                }
            }
        }
        if (ClockStart)
        {
            TimeCounter += Time.deltaTime;
            if(TimeCounter > CayoteTime)
            {
                jumpcount = jumpcount - 1;
                ClockStart = false;
                TimeCounter = 0f;
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("hazard"))
        {
            SceneManager.LoadScene(0);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            CanJump = true;
            jumpcount = crystals.extrajump + 1;
        }
        if (collision.collider.CompareTag("Wall"))
        {
            OnWall = true;
            CanJump = true; 
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
}
