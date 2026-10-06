using UnityEngine;

public class Camera : MonoBehaviour
{
    public Camera camera;
    public Transform playertransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playertransform = GetComponent<Transform>();
        camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.position = new Vector2 ((playertransform.position.x + camera.transform.position.x) / 2, (playertransform.position.y + camera.transform.position.y) /2);
    }
}
