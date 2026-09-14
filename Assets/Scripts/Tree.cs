using UnityEngine;

public class Tree : MonoBehaviour
{
    public float speed = 5f;
    public GameObject leftBound;
    public GameObject rightBound;
    public bool isFacingRight = true;

    public GameObject applePrefab;
    public float dropIntervalMin = 1.0f;
    public float dropIntervalMax = 2.5f;
    public Transform dropPoint;

    
    void Start()
    {
        ScheduleNextDrop();
    }

    
    void Update()
    {
        if (isFacingRight)
        {
            // move right
            transform.position = new Vector2(transform.position.x + (speed*Time.deltaTime),
                transform.position.y);
        }
        else
        {
            // move left
            transform.position = new Vector2(transform.position.x - (speed*Time.deltaTime),
                transform.position.y);
        }
        if (transform.position.x > rightBound.transform.position.x)
        {
            isFacingRight = false;
        }
        if (transform.position.x < leftBound.transform.position.x)
        {
            isFacingRight = true;
        }
    }

    void ScheduleNextDrop()
    {
        float delay = Random.Range(dropIntervalMin, dropIntervalMax);
        Invoke(nameof(DropApple), delay);
    }

    void DropApple()
    {
        Vector3 spawnPos;
        if (dropPoint != null)
        {
            spawnPos = dropPoint.position;
        }
        else
        {
            spawnPos = transform.position;
        }

        Instantiate(applePrefab, spawnPos, Quaternion.identity);
        ScheduleNextDrop();

    }
}
