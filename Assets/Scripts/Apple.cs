using UnityEngine;

public class Apple : MonoBehaviour
{
    public float fallSpeed = 4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag.Equals("Basket"))
        {
            if (ScoreController.Instance != null)
                ScoreController.Instance.AddPoint();
            
            Destroy(gameObject);  //apple caught in basket
        }
        else if(other.gameObject.tag.Equals("Ground"))
        {
            BasketController basketController = FindFirstObjectByType<BasketController>();
            if (basketController != null)
                basketController.MissApple();

            Destroy(gameObject);
        }
    }
}
