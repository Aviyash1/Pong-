using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("HomeScreen");
    }

    public void LoadHighScores()
    {
        SceneManager.LoadScene("HighScores");
    }
}