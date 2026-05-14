using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class HighScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        List<int> scores = HighScoreManager.LoadScores();

        scoreText.text = "HIGH SCORES\n\n";

        for (int i = 0; i < scores.Count; i++)
        {
            scoreText.text += (i + 1) + ". " + scores[i] + "\n";
        }
    }
}