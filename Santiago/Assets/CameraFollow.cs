using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Target object for the camera to follow (the Player)
    public Transform target;

    // Distance offset between camera and player
    public Vector3 offset = new Vector3(0f, 6f, -7f);

    void LateUpdate()
    {
        if (target != null)
        {
            // Smoothly keep the camera positioned relative to the player
            transform.position = target.position + offset;
        }
    }
}