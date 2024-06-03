using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toScene4 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip transitionSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayTransitionSound();
            SceneManager.LoadScene("Scene4");
        }
    }

    private void PlayTransitionSound()
    {
        if (audioSource != null && transitionSound != null)
        {
            audioSource.PlayOneShot(transitionSound);
        }
        else
        {
            Debug.LogWarning("AudioSource or transitionSound not set.");
        }
    }
}