using System.Collections;
using UnityEngine;

public class BackgroundMusicPlayer : MonoBehaviour
{
    public AudioClip firstAudioClip; // The first audio clip to play
    public AudioClip loopAudioClip;  // The audio clip to loop after the first clip

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Ensure the audio source is set to not loop initially
        audioSource.loop = false;

        // Play the first audio clip
        PlayFirstClip();
    }

    void PlayFirstClip()
    {
        if (firstAudioClip != null)
        {
            audioSource.clip = firstAudioClip;
            audioSource.Play();
            // Start coroutine to wait until the first clip is finished
            StartCoroutine(WaitForFirstClipToEnd());
        }
    }

    IEnumerator WaitForFirstClipToEnd()
    {
        // Wait until the first clip finishes playing
        yield return new WaitForSeconds(firstAudioClip.length);

        // Play the looped audio clip
        PlayLoopedClip();
    }

    void PlayLoopedClip()
    {
        if (loopAudioClip != null)
        {
            audioSource.clip = loopAudioClip;
            audioSource.loop = true; // Set to loop the second clip
            audioSource.Play();
        }
    }
}
