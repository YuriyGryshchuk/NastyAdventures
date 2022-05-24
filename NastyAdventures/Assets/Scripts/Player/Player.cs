using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public IStatsProvider _stats { get; private set; }


    

    [SerializeField] private float _walkSpeed = 10F;
    [SerializeField] private float _runSpeed = 20f;
    [SerializeField] private float _jumpHeight = 3f;
    [SerializeField] private float _mass = 2f;

    [SerializeField] HighJump highJump;


    private void Awake()
    {

        _stats = new BasicStats(_walkSpeed, _runSpeed, _jumpHeight, _mass);
        highJump.Init(_stats);

    }


    


    public PlayerStats GetStats()
    {
       return _stats.GetStats();
    }




}
