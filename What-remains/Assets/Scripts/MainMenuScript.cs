using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Add this line

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void ShowInstructions()
    {
        StartCoroutine(LoadSceneWithDelay("InstructionsScene", 0.5f));
    }

    public void ShowCredits()
    {
        StartCoroutine(LoadSceneWithDelay("CreditsScene", 0.5f));
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }

    private IEnumerator LoadSceneWithDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
