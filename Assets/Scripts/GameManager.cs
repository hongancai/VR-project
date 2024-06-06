using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject soccerPrefab; // 球的预制件
    public Transform spawnPoint; // 生成球的位置
    public float gameDuration = 180f; // 游戏持续时间（秒）

    private bool isGameOver = false;
    private bool isBallDestroyed = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(Gameplay());

        Debug.Log("Game Over");
    }

    private IEnumerator Gameplay()
    {
        float startTime = Time.time;

        while (!isGameOver && Time.time - startTime < gameDuration)
        {
            SpawnBall();
            yield return new WaitForSeconds(3f); // 每3秒生成一颗球
        }

        isGameOver = true;
        StopAllBalls(); // 结束游戏时停止所有球的运动
    }

    public void RespawnBall()
    {
        if (!isGameOver && !isBallDestroyed) // 当游戏未结束且球未被摧毁时重新生成球
        {
            StartCoroutine(SpawnBallWithDelay());
        }
    }

    private IEnumerator SpawnBallWithDelay()
    {
        yield return new WaitForSeconds(1f); // 延迟1秒再生成新的球
        SpawnBall();
    }

    private void SpawnBall()
    {
        Instantiate(soccerPrefab, spawnPoint.position, spawnPoint.rotation); // 在spawnPoint位置生成球
    }

    public void SetGameOver(bool value)
    {
        isGameOver = value;
    }

    public void SetBallDestroyed(bool value)
    {
        isBallDestroyed = value;
    }

    private void StopAllBalls()
    {
        Soccer[] soccerBalls = FindObjectsOfType<Soccer>();
        foreach (Soccer ball in soccerBalls)
        {
            Destroy(ball.gameObject);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isGameOver = false; // 重新开始游戏时重置游戏状态
        isBallDestroyed = false; // 重新开始游戏时重置球的状态
        StartCoroutine(GameLoop()); // 重新开始游戏循环
    }
}