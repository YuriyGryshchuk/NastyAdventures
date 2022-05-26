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

    private void Update()
    {
        _restartButton.onClick.AddListener(RestartLevel);
    }

    public void RestartLevel()
    {
        Debug.Log("restart");
        SceneManager.LoadScene("1");
    }
}
