using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    Rigidbody2D rb;
    bool isGrounded = false;
    Scene scene;
    public MenuScene menu;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        float movementhorizontal = Input.GetAxis("Horizontal"); // to recognize the horizontal movement
        rb.linearVelocity = new Vector2(movementhorizontal * speed, rb.linearVelocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
        scene = SceneManager.GetActiveScene();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.collider.CompareTag("hazard"))
        {
            menu.ShowGameOver();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
