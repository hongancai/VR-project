using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Soccer : MonoBehaviour
{
    private Rigidbody rb;
    private Transform target;
    public float ballSpeed = 10f; // 設置球的速度

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody not found on Soccer game object!");
            return;
        }
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.isKinematic = false; 
        GetComponent<XRGrabInteractable>().selectExited.AddListener(OnBallReleased);
        ChooseRandomTarget();
    }

 	private void OnBallReleased(SelectExitEventArgs args)
	{
    if (GameManager.Instance != null)
    {
        GameManager.Instance.RespawnBall();
    }

    if (ScoreManager.Instance != null)
    {
        ScoreManager.Instance.AddScore(1);
    }
    Destroy(gameObject);
	}

    private void ChooseRandomTarget()
    {
        string[] targetTags = { "Target1", "Target2", "Target3"};
        string randomTag = targetTags[Random.Range(0, targetTags.Length)];
        GameObject targetObject = GameObject.FindGameObjectWithTag(randomTag);
        if (targetObject != null)
        {
            target = targetObject.transform;
        }
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            rb.velocity = direction * ballSpeed; // 使用設置的速度來移動球
        }
    }
}