using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float Velocity, MaxSpeedL, MaxSpeedR, Speed;
    public int JumpPower;
    public bool CanJump = false;
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
        Speed = RB.linearVelocityX;
        if (Input.GetKeyDown("space") == true && CanJump == true )
        {
            RB.linearVelocityY = JumpPower;
            CanJump = false;
        }
        if (Input.GetAxis("Horizontal") != 0 && RB.linearVelocityX <= MaxSpeedR && RB.linearVelocityX >= MaxSpeedL)
        {
            float HorizontalMove = Input.GetAxis("Horizontal");
            RB.linearVelocityX = (HorizontalMove * Velocity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") == true)
        {
            CanJump = true;
        }
    }
}
