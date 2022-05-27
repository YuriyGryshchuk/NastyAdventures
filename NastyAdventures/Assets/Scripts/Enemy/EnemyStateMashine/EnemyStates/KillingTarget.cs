using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingTarget: State
{
    [SerializeField] private Canvas _deadCanvas;

    private void OnEnable()
    {
        _deadCanvas.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

}
