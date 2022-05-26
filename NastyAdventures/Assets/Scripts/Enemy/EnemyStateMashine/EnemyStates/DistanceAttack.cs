using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceAttack : State
{
    [SerializeField] private float _timeBetweenAttacks = 2;
    [SerializeField] private TriggerToPlayer _triggerToPlayer;
    [SerializeField] private float _speedToRotate;
    [SerializeField] private GameObject _boll;
    [SerializeField] private Transform _bollSpawn;
    [SerializeField] private float _bollSpeed = 2f;

    private Vector3 _vectorToTarget;
    private CharacterController _controller;
    private float _currentTime;
    private GameObject _curentBoll;
    private Boll _bollScript;


    Mover mover = new Mover();

    private void OnEnable()
    {
        _controller = GetComponent<CharacterController>();
        _currentTime = 0;
        //_triggerToPlayer.TargetChanged += ChangedTarget;
    }

    private void Update()
    {
       _vectorToTarget = mover.GetVectorToTarget(_controller, Target, _speedToRotate);

        mover.RotateToVector(_controller, _vectorToTarget);

        Timer();
        AttackTarget();

    }

    private void AttackTarget()
    {
        if (_currentTime >= _timeBetweenAttacks)
        {
            Instantiate(_boll, _bollSpawn.position, Quaternion.identity);
            _bollScript = _curentBoll.GetComponent<Boll>();
            _bollScript.Init(_bollSpeed, Target.transform.position);
            _currentTime = 0;
        }
    }

    private void Timer()
    {
        _currentTime += Time.deltaTime;
    }



    

 }
