using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausepanel;
    public bool isShow;
    [SerializeField] private InputActionReference menuInputActionReference;
    private void OnEnable()
    {
        menuInputActionReference.action.started += MenuPressed;
    }
    private void OnDisable()
    {
        menuInputActionReference.action.started -= MenuPressed;
    }

    void Update()
    {
        pausepanel.SetActive(isShow);
    }
    private void MenuPressed(InputAction.CallbackContext context)
    {
        Debug.Log("MenuPressed!");
        isShow = !isShow;
    }
}