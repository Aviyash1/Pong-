using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static void SaveScore(int score)
    {
        List<int> scores = LoadScores();

        scores.Add(score);
        scores.Sort((a, b) => b.CompareTo(a));

        if (scores.Count > 10)
            scores.RemoveRange(10, scores.Count - 10);

        for (int i = 0; i < scores.Count; i++)
        {
            PlayerPrefs.SetInt("Score" + i, scores[i]);
        }

        PlayerPrefs.SetInt("ScoreCount", scores.Count);
        PlayerPrefs.Save();
    }

    public static List<int> LoadScores()
    {
        List<int> scores = new List<int>();
        int count = PlayerPrefs.GetInt("ScoreCount", 0);

        for (int i = 0; i < count; i++)
        {
            scores.Add(PlayerPrefs.GetInt("Score" + i));
        }

        return scores;
    }
}