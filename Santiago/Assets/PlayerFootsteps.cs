using UnityEngine;

/// <summary>
/// Handles player movement sound feedback at set intervals to enhance accessibility.
/// </summary>
public class PlayerFootsteps : MonoBehaviour
{
    [Header("Audio Configuration")]
    public AudioSource audioSource;
    public AudioClip footstepSFX;

    [Header("Footstep Timing")]
    public float stepInterval = 0.4f;

    private float timer = 0f;

    void Start()
    {
        // Ensure looping is disabled so steps don't play infinitely
        if (audioSource != null)
        {
            audioSource.loop = false;
        }
    }

    void Update()
    {
        // Check movement input from WASD or Arrow keys
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputZ = Input.GetAxisRaw("Vertical");

        bool isMoving = (inputX != 0 || inputZ != 0);

        if (isMoving)
        {
            timer += Time.deltaTime;

            if (timer >= stepInterval)
            {
                PlayFootstepSound();
                timer = 0f;
            }
        }
        else
        {
            // Reset timer and stop audio immediately when player halts movement
            timer = stepInterval;
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    /// <summary>
    /// Plays footstep audio clip.
    /// </summary>
    void PlayFootstepSound()
    {
        if (audioSource != null && footstepSFX != null)
        {
            audioSource.PlayOneShot(footstepSFX);
        }
    }
}