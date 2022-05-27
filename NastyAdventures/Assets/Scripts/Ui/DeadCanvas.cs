using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadCanvas : MonoBehaviour
{
    [SerializeField] private Canvas _deadCanvas;
    [SerializeField] private Button _restartButton;

    private void Start()
    {
        _deadCanvas.enabled = false;
    }

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(RestartLevel);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(RestartLevel);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        Debug.Log("restart");
        SceneManager.LoadScene(0);
    }
}
