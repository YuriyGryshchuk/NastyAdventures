using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlowerCheckingArea : State
{
    [SerializeField] private TriggerToPlayer _triggerToPlayer;
   
    private bool _needTransit;

    private void OnEnable()
    {
        _triggerToPlayer.TargetChanged += ChangedTarget;
        _needTransit = false;
    }

    private void Update()
    {
        Exit();
    }

    public override void Exit()
    {
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
