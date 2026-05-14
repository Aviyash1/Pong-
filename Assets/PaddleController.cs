using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour
{
    public float moveSpeed = 10f;
    private float originalSpeed;

    public bool isLeft;
    public float limit;

    void Start()
    {
        originalSpeed = moveSpeed;
        limit = Camera.main.orthographicSize - 0.8f;
    }

    void Update()
    {
        float move = 0f;

        if (isLeft)
        {
            if (Input.GetKey(KeyCode.W)) move = 1f;
            if (Input.GetKey(KeyCode.S)) move = -1f;
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow)) move = 1f;
            if (Input.GetKey(KeyCode.DownArrow)) move = -1f;
        }

        Vector3 pos = transform.position;
        pos.y += move * moveSpeed * Time.deltaTime;

        pos.y = Mathf.Clamp(pos.y, -limit, limit);

        transform.position = pos;
    }

    public void SlowDown()
    {
        StartCoroutine(SlowRoutine());
    }

    IEnumerator SlowRoutine()
    {
        moveSpeed *= 0.5f;
        yield return new WaitForSeconds(3f);
        moveSpeed = originalSpeed;
    }
}