using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class StatsDecorator : ScriptableObject, IStatsProvider
{

    protected IStatsProvider _wrappedEntity;

    [SerializeField] private float _timeAbility;
   
  
   
    public void Init(IStatsProvider wrappedEntity) 
       
    {
       if(this != wrappedEntity)
        {
            _wrappedEntity = wrappedEntity;
        }
            
        
       

    }

    public PlayerStats GetStats()
    {
        return GetStatsInternal();
    }
    public float GetTimeAbility()
    {
        return _timeAbility;
    }
    protected abstract PlayerStats GetStatsInternal();
}
