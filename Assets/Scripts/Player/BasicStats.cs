using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicStats :  IStatsProvider
{
     private float _walkSpeed;
     private float _runSpeed;
     private float _jumpHeight;
     private float _mass;



    public BasicStats(float walkSpeed, float runSpeed, float jumpHeight, float mass)
    {
        _walkSpeed = walkSpeed;
        _runSpeed = runSpeed;
        _jumpHeight = jumpHeight;
        _mass = mass;
   
    }
  

   public PlayerStats GetStats()
    {
        return new PlayerStats()
        {
            WalkSpeed = _walkSpeed,
            RunSpeed = _runSpeed,
            JumpHeight = _jumpHeight,
            Mass = _mass
        };
    }
}
