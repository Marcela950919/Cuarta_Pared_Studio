using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Speed of the character
    public float speed = 5f;

    void Update()
    {
        // Get input from W, A, S, D or Arrow Keys
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Create the movement direction
        Vector3 movement = new Vector3(moveX, 0f, moveZ);

        // Move the character frame by frame
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}