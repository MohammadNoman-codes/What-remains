using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSound : MonoBehaviour
{
    public GameObject Jump;
    public AudioClip jumpSound;
    public AudioClip landSound;
    private AudioSource jumpAudioSource;
    private AudioSource landAudioSource;
    private bool isJumping = false;

    // Adjust this delay according to your preference
    public float landSoundDelay = 0.5f; // in seconds

    // Start is called before the first frame update
    void Start()
    {
        Jump.SetActive(false);

        // Add AudioSources to the GameObject
        jumpAudioSource = gameObject.AddComponent<AudioSource>();
        landAudioSource = gameObject.AddComponent<AudioSource>();

        // Set the volume for both AudioSources
        jumpAudioSource.volume = 1.0f;
        landAudioSource.volume = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            PlayJumpSound();
        }

        if (Input.GetKeyUp(KeyCode.Space) && isJumping)
        {
            StopJumpSound();
        }

        // Example condition for landing sound (you might want to adjust this)
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(PlayLandSoundWithDelay());
        }
    }

    void PlayJumpSound()
    {
        Jump.SetActive(true);

        // Play the jump sound
        if (jumpSound != null && jumpAudioSource != null)
        {
            jumpAudioSource.PlayOneShot(jumpSound);
        }

        isJumping = true;
    }

    void StopJumpSound()
    {
        Jump.SetActive(false);
        isJumping = false;
    }

    IEnumerator PlayLandSoundWithDelay()
    {
        // Wait for the specified delay before playing the land sound
        yield return new WaitForSeconds(landSoundDelay);

        // Play the landing sound
        if (landSound != null && landAudioSource != null && !isJumping)
        {
            landAudioSource.PlayOneShot(landSound);
        }
    }
}
