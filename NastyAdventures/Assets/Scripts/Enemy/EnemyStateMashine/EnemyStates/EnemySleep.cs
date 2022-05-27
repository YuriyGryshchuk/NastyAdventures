using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySleep : State
{
    [SerializeField] private float _timeEnemySleep = 10f;
    [SerializeField] private Light _lightDetection;

    private float _startTimeEnemySleep = 0f;
    private bool _enemyIsSleeping;

    private void OnEnable()
    {
        _lightDetection.enabled = false;
        _enemyIsSleeping = true;
        
    }

    private void Update()
    {
        if (_enemyIsSleeping)
        {
            _startTimeEnemySleep += Time.deltaTime;
        }
        Exit();
        
    }
    public override void Exit()
    {
        if (_startTimeEnemySleep >= _timeEnemySleep)
        {
            _startTimeEnemySleep = 0;
            _lightDetection.enabled = true;
            StateMashine.TransitToNext();
        }
    }
}
