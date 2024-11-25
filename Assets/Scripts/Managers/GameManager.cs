using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;

    [SerializeField] float startTime = 5f;
    bool gameOver = false;
    float timeLeft = 0;
    void Start()
    {
        timeLeft = startTime;
    }
    void Update()
    {
        DecreaseTime();
    }

    private void DecreaseTime()
    {
        if (gameOver)
        {
            return;
        }
        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1");
        if (timeLeft <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        playerController.enabled = false;
        gameOverText.SetActive(true);
        Time.timeScale = .1f;
        gameOver = true;
    }
}
