using UnityEngine;

public class BallController : MonoBehaviour
{
    public float startSpeed = 8f;
    private float currentSpeed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ResetBall();
    }

    public void ResetBall()
    {
        transform.position = Vector2.zero;
        currentSpeed = startSpeed;
        LaunchBall();
    }

    void LaunchBall()
    {
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.Range(-0.5f, 0.5f);

        Vector2 dir = new Vector2(x, y).normalized;
        rb.linearVelocity = dir * currentSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //  Paddle hit
        if (collision.gameObject.CompareTag("Paddle"))
        {
            currentSpeed += 1f;

            // PLAY PADDLE SOUND
            if (AudioManager.instance != null)
                AudioManager.instance.PlayPaddleHit();
        }
        // Wall hit
        else
        {
            //  PLAY WALL SOUND
            if (AudioManager.instance != null)
                AudioManager.instance.PlayWallHit();
        }

        rb.linearVelocity = rb.linearVelocity.normalized * currentSpeed;
    }

    public void BoostSpeed()
    {
        currentSpeed += 5f;
        rb.linearVelocity = rb.linearVelocity.normalized * currentSpeed;
    }
}