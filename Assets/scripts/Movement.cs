using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float Velocity;
    public float MinSpeed;
    public float MaxSpeed;
    public float Speed;
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
        if (Input.GetKeyDown("space") == true )
        {
            RB.linearVelocityY = 10f;
            Debug.Log("space");
        }
    }
}
