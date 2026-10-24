using UnityEngine;

public class CollectiblePiece : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the area is the Player
        if (other.CompareTag("Player"))
        {
            // 1. Call the GameManager to add the piece and update the UI/victory state.
            if (GameManager.instance != null)
            {
                GameManager.instance.RecogerPieza();
            }

            // 2. Destroy the map piece
            Destroy(gameObject);
        }
    }
}