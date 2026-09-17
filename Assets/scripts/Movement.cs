using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float Velocity, MaxSpeedL, MaxSpeedR, TimeCounter, CayoteTime;
    public int JumpPower, Speed;
    public bool CanJump = false;
    bool OnWall = false;
    bool ClockStart = false;
    bool FacingRight = true;
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
            RB.linearVelocityX = movedirection * Speed;

        }
        if (Input.GetKeyDown("space") == true && CanJump == true)
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
        if (ClockStart)
        {
            TimeCounter = TimeCounter + Time.deltaTime;
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
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        ClockStart = true;
        Debug.Log("clockstart");
    }
}
