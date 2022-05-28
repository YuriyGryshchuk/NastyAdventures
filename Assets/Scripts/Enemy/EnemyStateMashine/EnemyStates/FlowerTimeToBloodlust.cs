using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerTimeToBloodlust : State
{
    [SerializeField] private TriggerToPlayer _triggerToPlayer;
    [SerializeField] private float _timeToBloodlust = 5f;
    [SerializeField] private float _distanceToTarget;

    private float _startTimeToEnemyBloodlust;
    private bool _needTransitToNext;
    private bool _needTransitToPrevious;
    private float _timeToChangePrevious;

    private void OnEnable()
    {
        _needTransitToNext = false;
        _needTransitToPrevious = false;
        _startTimeToEnemyBloodlust = 0;

        _triggerToPlayer.TargetChanged += ChangedTarget;
    }

    private void Update()
    {
        Timer();
        Exit();
        CheckTransitToNext();
        TransitToPrivious();
    }

    private void Timer()
    {
        _startTimeToEnemyBloodlust += Time.deltaTime;
        _timeToChangePrevious += Time.deltaTime;
    }

    private void CheckTransitToNext()
    {
        if (_startTimeToEnemyBloodlust > _timeToBloodlust)
        {
            _needTransitToNext = true;
        }
    }

    private void TransitToPrivious()
    {
        if(_timeToChangePrevious >= 1)
        {
            _needTransitToPrevious = true;
        }
    }

    public override void Exit()
    {
        if (_needTransitToPrevious)
        {
            StateMashine.TransitToPrevious();
            _triggerToPlayer.TargetChanged -= ChangedTarget;
        }

        if (_needTransitToNext)
        {
            StateMashine.TransitToNext();
            _triggerToPlayer.TargetChanged -= ChangedTarget;
        }
    }

    private void ChangedTarget(Player target) 
    {
        _timeToChangePrevious = 0;
    }
       
}
