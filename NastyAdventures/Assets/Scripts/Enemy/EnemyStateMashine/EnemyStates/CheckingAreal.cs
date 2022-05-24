using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingAreal : State
{
    [SerializeField] private float _angleToCheck = 90f;
    [SerializeField] private float _stepToRotate = 5f;

    private float _currentAngleRotate;
    private float _targetAngleRotate;
    private float _startRotate;
    private Quaternion _currentRotate;
    private Quaternion _rotateToTarget;

    private void Start()
    {
        _startRotate = transform.rotation.y; 
    }
    private void OnEnable()
    {
        _rotateToTarget = _currentRotate;
        _currentAngleRotate = transform.rotation.y;
    }
       

    private void Update()
    {
        ChangeTargetRotate();
        RotateToTarget();
        transform.rotation = _rotateToTarget;



    }

    private void ChangeTargetRotate()
    {
        if (_currentAngleRotate <= _stepToRotate + _angleToCheck )
        {
            _rotateToTarget = Quaternion.Inverse(_currentRotate);
        }
        if (_currentAngleRotate >= _targetAngleRotate && _currentAngleRotate > _startRotate)
        {
            _rotateToTarget = _currentRotate;
        }

    }

    private void RotateToTarget()
    {
        var stepRotate = _stepToRotate * Time.deltaTime;
        _currentAngleRotate += stepRotate;
        _currentRotate = Quaternion.Euler(0, _currentAngleRotate, 0);
           
    }

}