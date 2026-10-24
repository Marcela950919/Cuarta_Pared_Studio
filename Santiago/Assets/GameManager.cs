using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI del Contador")]
    public TMP_Text contadorTexto;

    [Header("Elementos de Victoria")]
    public GameObject panelVictoria;
    public GameObject anoViejoCompleto;

    [Header("Sonido / Accesibilidad (WCAG 2.2)")]
    public AudioSource audioSource;
    public AudioClip sonidoRecoleccion;
    public AudioClip sonidoVictoria; // <--- New clip for the win

    private int piezasRecolectadas = 0;
    private int totalPiezas = 3;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void RecogerPieza()
    {
        piezasRecolectadas++;

        ActualizarUI();

        if (piezasRecolectadas >= totalPiezas)
        {
            ActivarVictoria();
        }
        else
        {
            // Only the standard effect plays if you have not yet collected all the pieces.
            if (audioSource != null && sonidoRecoleccion != null)
            {
                audioSource.PlayOneShot(sonidoRecoleccion);
            }
        }
    }

    void ActualizarUI()
    {
        if (contadorTexto != null)
        {
            contadorTexto.text = "Piezas: " + piezasRecolectadas + " / " + totalPiezas;
        }
    }

    void ActivarVictoria()
    {
        // Play the special victory sound when the 3 pieces are put together
        if (audioSource != null && sonidoVictoria != null)
        {
            audioSource.PlayOneShot(sonidoVictoria);
        }

        if (anoViejoCompleto != null)
        {
            anoViejoCompleto.SetActive(true);
        }

        if (panelVictoria != null)
        {
            panelVictoria.SetActive(true);
        }
    }
}