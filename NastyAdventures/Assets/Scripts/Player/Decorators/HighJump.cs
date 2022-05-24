using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class HighJump : StatsDecorator
{

    [SerializeField] private float _jumpMultiplier;

    
 


    protected override PlayerStats GetStatsInternal()
    {
        var stats = _wrappedEntity.GetStats();
        stats.JumpHeight = stats.JumpHeight * _jumpMultiplier;
        return stats;

    }
}
