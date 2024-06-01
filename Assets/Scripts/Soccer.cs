using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Soccer : MonoBehaviour
{
    private Rigidbody rb;
    private Transform target;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        GetComponent<XRGrabInteractable>().selectExited.AddListener(OnBallReleased);
        ChooseRandomTarget();
    }

    private void OnBallReleased(SelectExitEventArgs args)
    {
        Destroy(gameObject);
        GameManager.Instance.RespawnBall();
        ScoreManager.Instance.AddScore(50);
    }

    private void ChooseRandomTarget()
    {
        string[] targetTags = { "Target1", "Target2", "Target3", "Target4", "Target5", "Target6" };
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
            rb.velocity = direction * 5f; // 調整速度
        }
    }
}