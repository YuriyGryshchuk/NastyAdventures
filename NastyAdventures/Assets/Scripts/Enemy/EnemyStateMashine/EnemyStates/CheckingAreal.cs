using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingAreal : State
{
    [SerializeField] private float _angleToCheck = 90f;
    [SerializeField] private float _stepToRotate = 5f;

    private float _currentAngleRotate;
    private bool _isReverse;
    private float _startAngle;



    private void Start()
    {
        _startAngle = transform.rotation.y;
    }


    private void OnEnable()
    {
        _isReverse = false;
        _currentAngleRotate = _startAngle;
    }
       

    private void Update()
    {
        
        RotateToTarget();
        ChangeTargetRotate();



    }

    private void ChangeTargetRotate()
    {
        if (!_isReverse)
        {
            if (_currentAngleRotate >= _angleToCheck - _startAngle)
            {
                Inverse();
                
            }
        }
        else
        {
            if (_currentAngleRotate <= _angleToCheck + _startAngle)
            {
                Inverse();
               
            }
        }
       

    }

    private void RotateToTarget()
    {
      
        _currentAngleRotate += _stepToRotate * Time.deltaTime;
        transform.rotation  = Quaternion.Euler(0, _currentAngleRotate, 0);
           
    }
    private void Inverse()
    {
        _angleToCheck = -_angleToCheck;
        _stepToRotate = -_stepToRotate;
         _isReverse = !_isReverse;
    }
}