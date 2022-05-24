using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingAreal : State
{
    [SerializeField] private float _angleToCheck = 90f;
    [SerializeField] private float _stepToRotate = 5f;

    private float _currentAngleRotate;

    private bool isReverse;


    private void Start()
    {
        isReverse = false;
    }


    private void OnEnable()
    {
       
        _currentAngleRotate = 0;
    }
       

    private void Update()
    {
        
        RotateToTarget();
        ChangeTargetRotate();



    }

    private void ChangeTargetRotate()
    {
        if (!isReverse)
        {
            if (_currentAngleRotate >= _angleToCheck)
            {
                Inverse();
                
            }
        }
        else
        {
            if (_currentAngleRotate <= _angleToCheck)
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
         isReverse = !isReverse;
    }
}