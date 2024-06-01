using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public Image heart1;
    public Image heart2;
    public Image heart3;
    
    public GameObject pnlGameOver;

    private int lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        pnlGameOver.SetActive(false);
    }
    public void ReduceLife()
    {
        lives--;
        UpdateLivesUI();

        if (lives <= 0)
        {
            GameOver();
        }
    }
    private void UpdateLivesUI()
    {
        if (lives < 3)
        {
            heart3.enabled = false;
        }
        if (lives < 2)
        {
            heart2.enabled = false;
        }
        if (lives < 1)
        {
            heart1.enabled = false;
        }
    }
    private void GameOver()
    {
        pnlGameOver.SetActive(true);
    }
}
