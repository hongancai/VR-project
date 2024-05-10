using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S1Mgr : MonoBehaviour
{
    public Button btnplay;
    // Start is called before the first frame update
    void Start()
    {
        btnplay.onClick.AddListener(OnPlayClick);
    }

    private void OnPlayClick()
    {
        SceneManager.LoadScene("S2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
