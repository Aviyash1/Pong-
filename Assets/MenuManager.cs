using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("AbilitySelect");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}