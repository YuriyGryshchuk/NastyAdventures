using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuiterTarget : State
{
    [SerializeField] private TriggerToPlayer _triggerToPlayer;
    [SerializeField] private float _distanceToKillTarget;
    [SerializeField] private float _timeToResetPursuit;

    private UnityEngine.AI.NavMeshAgent agent;
    private bool _needTransitToNext;
    private bool _needTransitToPrevious;
    private float _timeWinhoutTarget;

    private void OnEnable()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        _needTransitToNext = false;
        _needTransitToPrevious = false;
        _timeWinhoutTarget = 0;

        _triggerToPlayer.TargetChanged += ChangedTarget;

        CheckTransitToNext();
        CheckTransitToPrevious();

    }

    private void Update()
    {
        _timeWinhoutTarget += Time.deltaTime;
        agent.SetDestination(Target.transform.position);

        CheckTransitToNext();
        CheckTransitToPrevious();
        Exit();
    }

    private void ChangedTarget(Player target)
    {
        _timeWinhoutTarget = 0;
    }

    private void CheckTransitToNext()
    {
        if (agent.remainingDistance < _distanceToKillTarget)
            _needTransitToNext = true;
    }

    private void CheckTransitToPrevious()
    {
        if (_timeWinhoutTarget > _timeToResetPursuit)
            _needTransitToPrevious = true;
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

}
