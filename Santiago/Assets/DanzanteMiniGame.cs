using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DanzanteMiniGame : MonoBehaviour
{
    [Header("Referencias de la Interfaz (UI)")]
    public GameObject dialoguePanel;          // Objeto CuadroDialogo
    public TMP_Text dialogueText;             // Objeto TextoDialogo
    public Image characterPortraitImage;     // Objeto RetratoPersonaje
    public Slider progressBar;                // Objeto BarraAserrin

    [Header("Contenido y Configuración")]
    public Sprite npcPortrait;                // 2D photo of the dancer
    public GameObject rewardPiece;            // Objeto PiezaAnoViejo (1)
    public int requiredPresses = 10;          // Number of times to press Space

    private int currentPresses = 0;
    private bool isGameActive = false;
    private bool isCompleted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (dialoguePanel != null) dialoguePanel.SetActive(true);

            // Asignar foto del Danzante
            if (characterPortraitImage != null && npcPortrait != null)
            {
                characterPortraitImage.sprite = npcPortrait;
            }

            if (!isCompleted)
            {
                // Start the minigame
                if (dialogueText != null) 
                {
                    dialogueText.text = "¡Al ritmo del Carnaval! Presiona la tecla ESPACIO " + requiredPresses + " veces para empacar el aserrín.";
                }

                if (progressBar != null)
                {
                    progressBar.gameObject.SetActive(true);
                    progressBar.value = 0;
                }

                currentPresses = 0;
                isGameActive = true;
            }
            else
            {
                // If you have already completed it previously
                if (dialogueText != null) dialogueText.text = "¡Qué gran energía! Ya me ayudaste a llenar el saco de aserrín.";
                if (progressBar != null) progressBar.gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        // Detect whether the player is inside the zone and presses SPACE
        if (isGameActive && !isCompleted && Input.GetKeyDown(KeyCode.Space))
        {
            currentPresses++;

            // Update the bar's value (from 0 to 1)
            if (progressBar != null)
            {
                progressBar.value = (float)currentPresses / requiredPresses;
            }

            // Did you complete the pulses?
            if (currentPresses >= requiredPresses)
            {
                isCompleted = true;
                isGameActive = false;

                // Victory message
                if (dialogueText != null)
                {
                    dialogueText.text = "¡Excelente zapateo! Has empacado todo el aserrín. Toma el relleno para el Año Viejo.";
                }

                // Hide the bar and show the reward
                if (progressBar != null) progressBar.gameObject.SetActive(false);
                if (rewardPiece != null) rewardPiece.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isGameActive = false;

            if (dialoguePanel != null) dialoguePanel.SetActive(false);
            if (progressBar != null) progressBar.gameObject.SetActive(false);
        }
    }
}