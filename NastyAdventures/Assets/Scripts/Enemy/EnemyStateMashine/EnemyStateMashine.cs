using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMashine : MonoBehaviour
{
    [SerializeField] private State[] _states;
    [SerializeField] private Player _target;

    private int _currentState = 0;
    private bool _needTransit = false;

    private void Start()
    {
        ChangeState(0);
    }

    private void Update()
    {
        if (_needTransit == false)
            return;

        ChangeState(_currentState);
    }



    private void ChangeState(int currentState)
    {
        foreach (var state in _states)
        {
            state.enabled = false;
        }

        _states[currentState].enabled = true;
        _states[currentState].Enter(_target, this);
        _needTransit = false;
    }

    public void TransitToNext()
    {
        _currentState++;
        if (_currentState > _states.Length)
            _currentState = _states.Length;
        _needTransit = true;
       
    }

    public void TransitToPrevious()
    {
        _currentState--;
        if (_currentState < 0)
            _currentState = 0;
        _needTransit = true;
    }


}
