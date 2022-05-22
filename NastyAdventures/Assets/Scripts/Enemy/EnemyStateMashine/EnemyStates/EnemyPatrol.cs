using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : State
{
    [SerializeField] private Transform[] _goals;
    [SerializeField] private float _distanceToChangeGoal;
    [SerializeField] private TrigerToPlayer _trigerToPlayer;

    private UnityEngine.AI.NavMeshAgent agent;
    private int _currentGoal = 0;
    private Vector3 _targetPosition;
    private bool _needTransit;

    private void OnEnable()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        _targetPosition = _goals[0].position;
        _needTransit = false;

        _trigerToPlayer.TargetChanged += ChangedTarget;
    }

    private void Update()
    {
        Exit();

        if (agent.remainingDistance < _distanceToChangeGoal)
        {
            _currentGoal++;
            if (_currentGoal == _goals.Length) _currentGoal = 0;
            _targetPosition = _goals[_currentGoal].position;
        }
        agent.SetDestination(_targetPosition);
    }

    public override void Exit()
    {
        if(_needTransit)
        {
            StateMashine.TransitToNext();
            _trigerToPlayer.TargetChanged -= ChangedTarget;
        }
    }

    private void ChangedTarget(Player target)
    {
        _needTransit = true;
    }
}
