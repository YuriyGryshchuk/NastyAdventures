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

   


    private void Awake()
    {

        _stats = new BasicStats(_walkSpeed, _runSpeed, _jumpHeight, _mass);
    

    }


    


    public PlayerStats GetStats()
    {
       return _stats.GetStats();
    }


    public void SetStats(IStatsProvider stats)
    {
        _stats = stats;
    }

}
