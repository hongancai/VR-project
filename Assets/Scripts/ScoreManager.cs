using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // 分數顯示的TextMeshPro元件
    private int score = 0; // 初始分數

    void Start()
    {
        UpdateScoreUI(); // 初始化分數顯示
    }

    public void AddScore(int value)
    {
        score += value; // 增加分數
        UpdateScoreUI(); // 更新UI
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score : " + score.ToString(); // 更新分數顯示
    }
}
