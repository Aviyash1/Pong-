using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    public GameObject panel;

    public void Show()
    {
        panel.SetActive(true);
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void GoToHighScores()
    {
        SceneManager.LoadScene("HighScores");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}