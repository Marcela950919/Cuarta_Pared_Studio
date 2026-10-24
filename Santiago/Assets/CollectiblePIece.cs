using UnityEngine;

/// <summary>
/// Handles collection detection for puzzle pieces and notifies GameManager.
/// </summary>
public class CollectiblePiece : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is tagged as Player
        if (other.CompareTag("Player"))
        {
            // Notify the GameManager to process item collection
            if (GameManager.instance != null)
            {
                GameManager.instance.CollectPiece();
            }

            // Destroy this collectible item object
            Destroy(gameObject);
        }
    }
}