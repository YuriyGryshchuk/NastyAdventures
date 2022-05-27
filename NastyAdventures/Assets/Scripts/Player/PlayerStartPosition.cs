using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
    private const string START_POSITION_KEY = "startPlayerPosition";

    private Vector3 _startPosition;

    private void Start()
    {
        Debug.Log("RESTART");
        _startPosition = SaveData.Load<Vector3>(START_POSITION_KEY);
        transform.position = _startPosition;
    }

    private void OnEnable()
    {
        transform.position = _startPosition;
    }
}
