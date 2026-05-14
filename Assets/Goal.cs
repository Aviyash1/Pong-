using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isLeftGoal;
    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            if (isLeftGoal)
                gameManager.ScoreRight();
            else
                gameManager.ScoreLeft();
        }
    }
}