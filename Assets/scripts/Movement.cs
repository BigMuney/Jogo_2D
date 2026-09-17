using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float Velocity, MaxSpeedL, MaxSpeedR, TimeCounter, CayoteTime, MinSpeed;
    public int JumpPower, Speed;
    public bool CanJump = false;
    bool OnWall = false;
    bool ClockStart = false;
    bool FacingRight = true;
    int Direction = 1;
    public Rigidbody2D RB;
    public BoxCollider2D Collider;
    void Start()
    {
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
        if (Input.GetKeyDown("space") == true && CanJump == true)
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
                }
                else
                {
                    RB.linearVelocityY = JumpPower;
                    CanJump = false;
                }
            }
        }
        if (ClockStart)
        {
            TimeCounter += Time.deltaTime;
            if(TimeCounter > CayoteTime)
            {
                CanJump = false;
                ClockStart = false;
                TimeCounter = 0f;
            }
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            CanJump = true;
            Debug.Log("touchfloor");
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
