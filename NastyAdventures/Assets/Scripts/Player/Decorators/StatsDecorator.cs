using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class StatsDecorator : ScriptableObject, IStatsProvider
{

    protected IStatsProvider _wrappedEntity;


   
  
   
    public void Init(IStatsProvider wrappedEntity) 
       
    {

        _wrappedEntity = wrappedEntity;

    }

    public PlayerStats GetStats()
    {
        return GetStatsInternal();
    }

    protected abstract PlayerStats GetStatsInternal();
}
