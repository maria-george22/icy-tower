using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int lives = 3;
    public Image[] hearts; // Assign Heart1, Heart2, Heart3
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        Time.timeScale = 1f; // Resume game
        UpdateHeartsUI();
        gameOverPanel.SetActive(false);
        finalScoreText.gameObject.SetActive(false);
        ScoreManager.instance.scoreText.gameObject.SetActive(true); // Show score during the game
    }

    public void LoseLife()
    {
        lives--;
        UpdateHeartsUI();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < lives;
        }
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
        finalScoreText.gameObject.SetActive(true); // 👈 Show Final Score now
        finalScoreText.text = "Final Score: " + ScoreManager.instance.score;
        ScoreManager.instance.scoreText.gameObject.SetActive(false);
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Destroy(player); // Destroy player when the game is over
        }
        Time.timeScale = 0f; // Pause game

    }
}
