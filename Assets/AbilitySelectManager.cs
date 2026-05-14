using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class AbilitySelectManager : MonoBehaviour
{
    // Selected ability text
    public TextMeshProUGUI redSelectedText;
    public TextMeshProUGUI blueSelectedText;

    // Countdown text
    public TextMeshProUGUI countdownText;

    // Ready buttons
    public GameObject redReadyBtn;
    public GameObject blueReadyBtn;

    void Start()
    {
        // Reset states
        GameSettings.redReady = false;
        GameSettings.blueReady = false;

        // Default UI
        redSelectedText.text = "Selected: None";
        blueSelectedText.text = "Selected: None";

        redReadyBtn.SetActive(false);
        blueReadyBtn.SetActive(false);

        // Hide countdown at start
        countdownText.gameObject.SetActive(false);
    }

    // RED SELECT
    public void SelectRed(int id)
    {
        GameSettings.redAbility = id;

        if (id == 0)
            redSelectedText.text = "Selected: Speed Boost";
        else
            redSelectedText.text = "Selected: Slow Opponent";

        redReadyBtn.SetActive(true);
    }

    // BLUE SELECT
    public void SelectBlue(int id)
    {
        GameSettings.blueAbility = id;

        if (id == 0)
            blueSelectedText.text = "Selected: Speed Boost";
        else
            blueSelectedText.text = "Selected: Slow Opponent";

        blueReadyBtn.SetActive(true);
    }

    // RED READY
    public void RedReady()
    {
        GameSettings.redReady = true;
        CheckStart();
    }

    // BLUE READY
    public void BlueReady()
    {
        GameSettings.blueReady = true;
        CheckStart();
    }

    // CHECK BOTH READY
    void CheckStart()
    {
        if (GameSettings.redReady && GameSettings.blueReady)
        {
            StartCoroutine(StartCountdown());
        }
    }

    // COUNTDOWN SYSTEM
    IEnumerator StartCountdown()
    {
        countdownText.gameObject.SetActive(true);

        countdownText.text = "3";
        yield return new WaitForSeconds(1f);

        countdownText.text = "2";
        yield return new WaitForSeconds(1f);

        countdownText.text = "1";
        yield return new WaitForSeconds(1f);

        countdownText.text = "GO!";
        yield return new WaitForSeconds(0.8f);

        SceneManager.LoadScene("SampleScene");
    }
}