using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class BasketController : MonoBehaviour
{
    private Vector2 mousePos;
    public float minX = -8f;
    public float maxX = 8f;
    public GameObject[] baskets;
    public TextMeshProUGUI gameOverText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mousePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = mousePos;
        //clamp x and lock y/z to the basket's own current position
        transform.position = new Vector2(Mathf.Clamp(mousePos.x, minX, maxX), transform.position.y);
    }

    void OnMouseMove(InputValue value)
    {
        mousePos = value.Get<Vector2>();
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
    }

    public void MissApple()
    {
        for (int i = baskets.Length - 1; i >= 0; i--)
        {
            if (baskets[i] != null && baskets[i].activeSelf)
            {
                baskets[i].SetActive(false);
                IsGameOver();
                return;
            }
        }
    }

    public void IsGameOver()
    {
        for (int i = 0; i < baskets.Length; i++)
        {
            if (baskets[i] != null && baskets[i].activeSelf)
                return;
        }
        Debug.Log("All baskets gone, Game Over!");

        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = "Game Over!";
        }

        Time.timeScale = 0f; // stops movement
    }
}
