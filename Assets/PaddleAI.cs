using UnityEngine;

public class PaddleAI : MonoBehaviour
{
    public float speed = 10f;
    public bool isLeft;

    public float limit;

    void Start()
{
    limit = Camera.main.orthographicSize - 0.8f;
}
    void Update()
    {
        float move = 0f;

        // LEFT PLAYER (W / S)
        if (isLeft)
        {
            if (Input.GetKey(KeyCode.W))
                move = 1f;

            if (Input.GetKey(KeyCode.S))
                move = -1f;
        }
        // RIGHT PLAYER (Arrow Keys)
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
                move = 1f;

            if (Input.GetKey(KeyCode.DownArrow))
                move = -1f;
        }

        // Move paddle
        Vector3 pos = transform.position;
        pos.y += move * speed * Time.deltaTime;

        // Clamp within bounds
        pos.y = Mathf.Clamp(pos.y, -limit, limit);

        transform.position = pos;
    }
}