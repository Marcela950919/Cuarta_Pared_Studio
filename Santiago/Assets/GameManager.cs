using UnityEngine;
using TMPro;

/// <summary>
/// Manages global game state, UI score tracking, sound effects, and victory sequence.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI Score Elements")]
    public TMP_Text scoreText;

    [Header("Victory Sequence Elements")]
    public GameObject victoryPanel;
    public GameObject fullAnoViejoModel;

    [Header("Audio & Accessibility SFX")]
    public AudioSource audioSource;
    public AudioClip collectionSFX;
    public AudioClip victorySFX;

    private int collectedItems = 0;
    private int totalItems = 3;

    private void Awake()
    {
        // Enforce Singleton pattern for global access
        if (instance == null)
        {
            instance = this;
        }
    }

    /// <summary>
    /// Increments collected item counter and updates UI. Triggers victory if all items are gathered.
    /// </summary>
    public void CollectPiece()
    {
        collectedItems++;
        UpdateUI();

        // Check if player completed the main objective
        if (collectedItems >= totalItems)
        {
            TriggerVictory();
        }
        else
        {
            // Play item collection sound feedback
            if (audioSource != null && collectionSFX != null)
            {
                audioSource.PlayOneShot(collectionSFX);
            }
        }
    }

    /// <summary>
    /// Updates textual UI displaying collected items count.
    /// </summary>
    void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Pieces: " + collectedItems + " / " + totalItems;
        }
    }

    /// <summary>
    /// Triggers victory audio feedback, shows victory UI panel, and reveals the finished model.
    /// </summary>
    void TriggerVictory()
    {
        if (audioSource != null && victorySFX != null)
        {
            audioSource.PlayOneShot(victorySFX);
        }

        if (fullAnoViejoModel != null)
        {
            fullAnoViejoModel.SetActive(true);
        }

        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
        }
    }
}