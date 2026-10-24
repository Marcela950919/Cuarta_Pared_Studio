using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCInteraction : MonoBehaviour
{
    [Header("Referencias del Canvas (UI)")]
    public GameObject dialoguePanel;          // DialogBox Object
    public TMP_Text dialogueText;             // TextoDialogo Object
    public Image characterPortraitImage;     // Portrait/Character Object

    [Header("Contenido de este NPC")]
    [TextArea(3, 5)]
    public string npcMessage;                 // The specific message of this character
    public Sprite npcPortrait;                // This character's 2D face
    public GameObject rewardPiece;            // The New Year’s Eve effigy that one presents

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Turn on the dialogue panel
            if (dialoguePanel != null)
            {
                dialoguePanel.SetActive(true);
            }

            // Replace the on-screen text with the text for this NPC
            if (dialogueText != null)
            {
                dialogueText.text = npcMessage;
            }

            // Replace the on-screen portrait with the one for this NPC
            if (characterPortraitImage != null && npcPortrait != null)
            {
                characterPortraitImage.sprite = npcPortrait;
            }

            // Show the collectible item
            if (rewardPiece != null)
            {
                rewardPiece.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Hide the panel when the player moves away
            if (dialoguePanel != null)
            {
                dialoguePanel.SetActive(false);
            }
        }
    }
}