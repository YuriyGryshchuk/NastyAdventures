using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    private const string START_POSITION_KEY = "startPlayerPosition";

    private Vector3 _startPosition;

    private void OnTriggerEnter(Collider other)
    {
        _startPosition = other.transform.position;
        Debug.Log(_startPosition);
        SaveData.Save(START_POSITION_KEY, _startPosition);
    }
}
