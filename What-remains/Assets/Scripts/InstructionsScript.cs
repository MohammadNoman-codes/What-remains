using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Add this line

public class InstructionsScript : MonoBehaviour
{
    public void ReturnMenu()
    {
        StartCoroutine(LoadSceneWithDelay("MainMenuScene", 0.5f));
    }

    private IEnumerator LoadSceneWithDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
