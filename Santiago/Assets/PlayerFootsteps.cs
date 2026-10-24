using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    [Header("Configuración de Sonido")]
    public AudioSource audioSource;
    public AudioClip sonidoPaso;

    [Header("Ritmo de los Pasos")]
    public float intervaloPasos = 0.4f;

    private float timer = 0f;

    void Start()
    {
        if (audioSource != null)
        {
            audioSource.loop = false;
        }
    }

    void Update()
    {
        // Detects whether you are pressing movement keys
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputZ = Input.GetAxisRaw("Vertical");

        bool estaMoviendose = (inputX != 0 || inputZ != 0);

        if (estaMoviendose)
        {
            timer += Time.deltaTime;

            if (timer >= intervaloPasos)
            {
                ReproducirPaso();
                timer = 0f;
            }
        }
        else
        {
            // Upon releasing the keys, it stops time and halts the audio immediately.
            timer = intervaloPasos;
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    void ReproducirPaso()
    {
        if (audioSource != null && sonidoPaso != null)
        {
            audioSource.PlayOneShot(sonidoPaso);
        }
    }
}