using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject soccerBallPrefab;
    public Transform ballSpawnPoint;

    void Awake()
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

    void Start()
    {
        StartCoroutine(SpawnBallRoutine());
    }

    private IEnumerator SpawnBallRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3f, 5f)); // 每3到5秒生成一顆球
            RespawnBall();
        }
    }

    public void RespawnBall()
    {
        GameObject newBall = Instantiate(soccerBallPrefab, ballSpawnPoint.position, Quaternion.identity);
        Rigidbody rb = newBall.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }
        XRGrabInteractable grabInteractable = newBall.GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectExited.AddListener(OnBallReleased);
        }
    }

    private void OnBallReleased(SelectExitEventArgs args)
    {
        Destroy(args.interactable.gameObject);
    }
}