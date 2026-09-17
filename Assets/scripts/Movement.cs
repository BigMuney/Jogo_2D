using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float Velocity, MaxSpeedL, MaxSpeedR, TimeCounter, CayoteTime;
    public int JumpPower;
    public bool CanJump = false;
    bool ClockStart = false;
    public Rigidbody2D RB;
    public BoxCollider2D Collider;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        Collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
            {
            float movedirection = Input.GetAxis("Horizontal");
            RB.linearVelocityX = movedirection * 5f;

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
                CanJump = true;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            CanJump = true;
            Debug.Log("touchfloor");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        ClockStart = true;
        Debug.Log("clockstart");
    }
}
