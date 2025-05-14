using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        scoreText.text = "Score: " + score;
    }


    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = "Score: 0";
    }

}
