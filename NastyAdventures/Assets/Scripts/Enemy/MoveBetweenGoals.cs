using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class MoveBetweenGoals : MonoBehaviour
{

    [SerializeField] private Transform[] _goals;
    [SerializeField] private float _distanceToChangeGoal;
    [SerializeField] private TrigerToPlayer _trigerToPlayer;
    private UnityEngine.AI.NavMeshAgent agent;
    private int _currentGoal = 0;
    private Vector3 _targetPosition;
    private bool _isTargetDetected = false;
    private Player _target;
    private float _timeWithoutDetected = 0;

    

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = _goals[0].position;

        _trigerToPlayer.TargetChanged += ChangedTarget;
    }

        private void Update()
    {
        if (_isTargetDetected)
        {
            _timeWithoutDetected += Time.deltaTime;
            //Debug.Log(_timeWithoutDetected);
            if (_timeWithoutDetected > 5)
            {
                _isTargetDetected = false;
                _timeWithoutDetected = 0;
            }
        }

        if (agent.remainingDistance < _distanceToChangeGoal)
        {
            Debug.Log("ggg");
            if (!_isTargetDetected)
            {
                _currentGoal++;
                if (_currentGoal == _goals.Length) _currentGoal = 0;
                _targetPosition = _goals[_currentGoal].position;
            } else
            {
                _targetPosition = _target.transform.position;
            } 
        }

        agent.SetDestination(_targetPosition);
    }

    private void ChangedTarget(Player target)
    {
        _target = target;
        _isTargetDetected = true;
        Debug.Log("hhh");
        _timeWithoutDetected = 0;
    }
}