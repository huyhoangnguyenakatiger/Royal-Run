using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;

    [SerializeField] float startTime = 5f;
    bool gameOver = false;
    public bool GameOver => gameOver;
    float timeLeft = 0;
    void Start()
    {
        timeLeft = startTime;
    }
    void Update()
    {
        DecreaseTime();
    }

    public void IncreaseTime(float time)
    {
        timeLeft += time;
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
            PlayerGameOver();
        }
    }

    private void PlayerGameOver()
    {
        playerController.enabled = false;
        gameOverText.SetActive(true);
        Time.timeScale = .1f;
        gameOver = true;
    }
}
