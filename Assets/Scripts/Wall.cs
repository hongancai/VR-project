using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private LifeManager lifeManager;

    void Start()
    {
        lifeManager = FindObjectOfType<LifeManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // 檢查碰撞的物件是否為球
        if (collision.gameObject.CompareTag("GolfBall") ||
            collision.gameObject.CompareTag("Basketball") ||
            collision.gameObject.CompareTag("SoccerBall") ||
            collision.gameObject.CompareTag("Volleyball"))
        {
            // 移除球
            Destroy(collision.gameObject);

            // 扣減玩家生命
            if (lifeManager != null)
            { 
                lifeManager.ReduceLife();
            }
        }
    }
}
