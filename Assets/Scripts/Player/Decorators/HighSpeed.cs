using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class HighSpeed : StatsDecorator
{
    [SerializeField] private float _speedMultiplier;





    protected override PlayerStats GetStatsInternal()
    {
        var stats = base._wrappedEntity.GetStats();
        stats.WalkSpeed = stats.WalkSpeed * _speedMultiplier;
        return stats;

    }
}
