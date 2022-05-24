using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class NegativeMass : StatsDecorator
{
    [SerializeField] [Min(1)]  private float _massMultiplier;


    


    protected override PlayerStats GetStatsInternal()
    {
        var stats = base._wrappedEntity.GetStats();
        stats.Mass = stats.Mass * (- _massMultiplier);
        return stats;

    }
}
