using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class StatsDecorator : ScriptableObject, IStatsProvider
{

    protected IStatsProvider _wrappedEntity;

    //protected StatsDecorator(IStatsProvider wrappedEntity)
    //{
    //    _wrappedEntity = wrappedEntity;
    //}


   public PlayerStats GetStats()
    {
        return GetStatsInternal();
    }

    public void Init(IStatsProvider wrappedEntity) 
    {
        _wrappedEntity = wrappedEntity;
    }

    protected abstract PlayerStats GetStatsInternal();
}
