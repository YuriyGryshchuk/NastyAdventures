using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class СheckingArea : State
{
    [SerializeField] private TriggerToPlayer _triggerToPlayer;
    [SerializeField] private float _timeEnemyWaking = 10f;

    private float _startTimeEnemyWaking = 0f;
    private bool _enemyIsWaking;
    private bool _needTransit;

    private void OnEnable()
    {
        _enemyIsWaking = true;
        _triggerToPlayer.TargetChanged += ChangedTarget;
    }
    private void Update()
    {
        if (_enemyIsWaking)
        {
            _startTimeEnemyWaking += Time.deltaTime;
        }
        Exit();
    }
    public override void Exit()
    {
        if(_startTimeEnemyWaking >= _timeEnemyWaking)
        {
            _startTimeEnemyWaking = 0;
            StateMashine.TransitToPrevious();
        }

        if (_needTransit)
        {
            StateMashine.TransitToNext();
            _triggerToPlayer.TargetChanged -= ChangedTarget;
        }
    }

    private void ChangedTarget(Player target)
    {
        _needTransit = true;
    }
}
