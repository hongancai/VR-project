using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject soccerPrefab; 
    public Transform spawnPoint; // 生成球的位置
    public float gameDuration = 180f; 

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
            yield return new WaitForSeconds(4f); 
        }

        isGameOver = true;
        StopAllBalls(); 
    }

    public void RespawnBall()
    {
        if (!isGameOver && !isBallDestroyed) 
        {
            StartCoroutine(SpawnBallWithDelay());
        }
    }

    private IEnumerator SpawnBallWithDelay()
    {
        yield return new WaitForSeconds(2f); // 延遲2秒再生成新的球
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
        isGameOver = false; 
        isBallDestroyed = false; 
        StartCoroutine(GameLoop()); 
    }
}