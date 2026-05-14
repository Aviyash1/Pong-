using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int leftScore = 0;
    public int rightScore = 0;
    public int winScore = 10;

    public TextMeshProUGUI leftText;
    public TextMeshProUGUI rightText;
    public TextMeshProUGUI winText;

    public BallController ball;
    public PaddleController leftPaddle;
    public PaddleController rightPaddle;

    public EndGameMenu endGameMenu;

    void Start()
    {
        UpdateScore();

        if (winText != null)
            winText.gameObject.SetActive(false);

        GameSettings.redUsed = false;
        GameSettings.blueUsed = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !GameSettings.redUsed)
        {
            UseRedAbility();
            GameSettings.redUsed = true;
        }

        if (Input.GetKeyDown(KeyCode.RightShift) && !GameSettings.blueUsed)
        {
            UseBlueAbility();
            GameSettings.blueUsed = true;
        }
    }

    void UseRedAbility()
    {
        if (GameSettings.redAbility == 0)
            ball.BoostSpeed();
        else if (GameSettings.redAbility == 1)
            rightPaddle.SlowDown();
    }

    void UseBlueAbility()
    {
        if (GameSettings.blueAbility == 0)
            ball.BoostSpeed();
        else if (GameSettings.blueAbility == 1)
            leftPaddle.SlowDown();
    }

    public void ScoreLeft()
    {
        leftScore++;
        UpdateScore();

        //Change background color
        Camera.main.backgroundColor = Random.ColorHSV();

        if (leftScore >= winScore)
            EndGame("RED WINS!");
        else
            ball.ResetBall();
    }

    public void ScoreRight()
    {
        rightScore++;
        UpdateScore();

        //Change background color
        Camera.main.backgroundColor = Random.ColorHSV();

        if (rightScore >= winScore)
            EndGame("BLUE WINS!");
        else
            ball.ResetBall();
    }

    void UpdateScore()
    {
        leftText.text = leftScore.ToString();
        rightText.text = rightScore.ToString();
    }

    void EndGame(string winner)
    {
        ball.gameObject.SetActive(false);

        winText.gameObject.SetActive(true);
        winText.text = winner;

        // SAVE SCORE
        HighScoreManager.SaveScore(Mathf.Max(leftScore, rightScore));

        // SHOW MENU
        endGameMenu.Show();
    }
}