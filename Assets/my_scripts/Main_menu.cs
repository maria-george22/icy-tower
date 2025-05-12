using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Levels"); // Make sure the scene is added in Build Settings
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed"); // Only visible in Editor
    }
}
