using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMov : MonoBehaviour
{
    public string[] levelScenes = { "Scene1", "Scene2", "Scene3", "Scene4" }; // Add the names of your 4 levels
    private int currentLevelIndex = 0;
    public float sceneLoadDelay = 3f; // Time in seconds to wait before loading the next scene
    public AudioSource audioSource; // The audio source component
    public AudioClip transitionSound; // The sound to play during the scene transition

    private Coroutine loadNextLevelCoroutine;

    private void Start()
    {
        // Check if the levelScenes array is properly populated
        if (levelScenes.Length < 1)
        {
            Debug.LogError("SceneMov: The levelScenes array is empty. Please populate it with the names of your scenes.");
            enabled = false;
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Increment the current level index immediately
            IncrementLevelIndex();

            // Play the transition sound
            PlayTransitionSound();

            // Load the next level scene after a delay
            StopCoroutine(loadNextLevelCoroutine);
            loadNextLevelCoroutine = StartCoroutine(LoadNextLevelWithDelay());
        }
    }

    private void IncrementLevelIndex()
    {
        // Increment the current level index
        currentLevelIndex++;
        Debug.Log($"Current level index: {currentLevelIndex}");
    }

    private void PlayTransitionSound()
    {
        // Check if the audio source and clip are set
        if (audioSource != null && transitionSound != null)
        {
            audioSource.PlayOneShot(transitionSound);
        }
        else
        {
            Debug.LogWarning("AudioSource or transitionSound not set.");
        }
    }

    private IEnumerator LoadNextLevelWithDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(sceneLoadDelay);

        // Check if there are any more levels to load
        if (currentLevelIndex < levelScenes.Length)
        {
            // Load the next level
            string nextSceneName = levelScenes[currentLevelIndex];
            Debug.Log($"Loading next level: {nextSceneName}");
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            // You've reached the end of the levels, you can do something else here
            Debug.Log("You've completed all the levels!");
        }
    }

    public void ResetLevelIndex()
    {
        currentLevelIndex = 0;
        Debug.Log("Level index reset to 0.");
    }

    private void OnDisable()
    {
        // Stop the coroutine when the script is disabled
        StopCoroutine(loadNextLevelCoroutine);
    }
}