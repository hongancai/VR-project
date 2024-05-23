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
        if (collision.gameObject.CompareTag("Ball"))
        {
            lifeManager.LoseLife();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Bomb"))
        {
            Destroy(collision.gameObject);
        }
    }
}
