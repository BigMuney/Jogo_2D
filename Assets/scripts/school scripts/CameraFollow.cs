using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 distance = new Vector3(0f, 0f, -10f);
    public bool SmoothMovement = true;
    public float velocity = 5f;
    void LateUpdate()
    {
        Vector3 targetpossition = target.position + distance; // this position represent where the camera wants to go
        if (SmoothMovement) // when smoothmovement is active it behaves differently
        {
            transform.position = Vector3.Lerp(transform.position, targetpossition, velocity * Time.deltaTime); // smooths the transition from the camera to where its ment to go
        } 
        else // when smoothmovement is off 
        {
            transform.position = targetpossition; // camera snaps to the position of the player with no smoothing
        }
    }
}
