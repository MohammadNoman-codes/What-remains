using UnityEngine;

public class PlayerCollectibleSound : MonoBehaviour
{
    public AudioClip collectSound; // Sound to play when the player collects a collectible item
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on the player.");
        }
    }

    // Function to play the specified sound
    void PlaySound()
    {
        if (collectSound != null)
        {
            audioSource.PlayOneShot(collectSound);
        }
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // Check if the collision is with a collectible item
        if (other.CompareTag("Collectible"))
        {
            PlaySound();
            Destroy(other.gameObject); // Destroy the collectible object
        }
    }
}
