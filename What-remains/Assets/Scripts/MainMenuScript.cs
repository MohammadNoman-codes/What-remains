using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void ShowInstructions()
    {
        // Load the instructions scene
        SceneManager.LoadScene("InstructionsScene");
    }

    public void ShowCredits()
    {
        // Load the credits scene
        SceneManager.LoadScene("CreditsScene");
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
}
