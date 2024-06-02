using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject soccerPrefab; // 球的預製件
    public Transform spawnPoint; // 生成球的位置
    public float gameDuration = 180f; // 遊戲持續時間（秒）

    private bool isGameOver = false;

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

        // 遊戲結束後的邏輯可以在這裡實現，例如顯示結算畫面等
        Debug.Log("Game Over");
    }

    private IEnumerator Gameplay()
    {
        float startTime = Time.time;

        while (!isGameOver && Time.time - startTime < gameDuration)
        {
            SpawnBall();
            yield return new WaitForSeconds(Random.Range(3f, 5f)); // 每3到5秒生成一顆球
        }

        isGameOver = true;
        StopAllBalls(); // 停止所有球的運動
    }

    public void RespawnBall()
    {
        if (!isGameOver)
        {
            StartCoroutine(SpawnBallWithDelay());
        }
    }

    private IEnumerator SpawnBallWithDelay()
    {
        yield return new WaitForSeconds(1f); // 延遲1秒再生成新的球
        SpawnBall();
    }

    private void SpawnBall()
    {
        Instantiate(soccerPrefab, spawnPoint.position, spawnPoint.rotation); // 在spawnPoint位置生成球
    }

    private void StopAllBalls()
    {
        Soccer[] soccerBalls = FindObjectsOfType<Soccer>();
        foreach (Soccer ball in soccerBalls)
        {
            Destroy(ball.gameObject); // 銷毀正在場景中移動的球
        }
    }
}