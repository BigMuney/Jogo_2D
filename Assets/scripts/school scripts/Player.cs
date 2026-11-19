using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    Rigidbody2D rb;
    bool isGrounded = false;
    public MenuScene menu;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float movementhorizontal = Input.GetAxis("Horizontal"); // to recognize the horizontal movement
        rb.linearVelocity = new Vector2(movementhorizontal * speed, rb.linearVelocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true) // only allows the jump to happen if the player presses space and is grounded
        {
            rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse); // math to make jump
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")) // makes grounded when touching the floor
        {
            isGrounded = true;
        }
        if (collision.collider.CompareTag("hazard")) // triggers game over screen
        {
            menu.ShowGameOver();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")) // after the player leaves the ground turns isgrounded off
        {
            isGrounded = false;
        }
    }
}
