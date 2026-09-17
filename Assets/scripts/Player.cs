using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float movementhorizontal = Input.GetAxis("Horizontal"); // to recognize the horizontal movement
        rb.linearVelocity = new Vector2(movementhorizontal * speed, rb.linearVelocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
    }
}
