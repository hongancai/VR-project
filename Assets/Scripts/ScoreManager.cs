using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public TextMeshProUGUI gameOverScoreText; // 遊戲結束面板中的分數顯示
    public TextMeshProUGUI inGameScoreText; // 遊戲中的分數顯示
    public TextMeshProUGUI timeUpScoreText; // 時間到面板中的分數顯示

    private int score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateInGameScoreUI();
    }

    public int GetScore()
    {
        return score;
    }

    public void UpdateInGameScoreUI()
    {
        if (inGameScoreText != null)
        {
            inGameScoreText.text = "Score: " + score.ToString();
        }
    }

    public void UpdateScoreUI()
    {
        if (gameOverScoreText != null)
        {
            gameOverScoreText.text = "Score: " + score.ToString();
        }
        if (timeUpScoreText != null)
        {
            timeUpScoreText.text = "Score: " + score.ToString();
        }
    }
}