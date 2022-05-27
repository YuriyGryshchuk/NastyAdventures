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
    
    

    private List<StatsDecorator> _downStats;


    private void Awake()
    {
       
        _downStats = new List<StatsDecorator>();
        _stats = new BasicStats(_walkSpeed, _runSpeed, _jumpHeight, _mass);

        

    }


    public PlayerStats GetStats()
    {
       return _stats.GetStats();
    }

    public List<StatsDecorator> GetActiveAbility()
    {
        return _downStats;
    }
    public void SetAbility(StatsDecorator stats)
    {
     
            _downStats.Add(stats);
            _stats = stats;
            StartCoroutine(AbilityTimer(stats));
        
       
    }


    private IEnumerator AbilityTimer(StatsDecorator stats)
    {
        yield return new WaitForSeconds(stats.GetTimeAbility() );

       
        _downStats.Remove(stats);

        
        if(_downStats.Count > 1)
        {
            _downStats[_downStats.Count - 1].Init(_downStats[_downStats.Count - 2]);
            _stats = _downStats[_downStats.Count - 1];
        }
        else if(_downStats.Count == 1)
        {
           
            _downStats[_downStats.Count - 1].Init(new BasicStats(_walkSpeed, _runSpeed, _jumpHeight, _mass));
           
            _stats = _downStats[_downStats.Count - 1];
            _downStats.RemoveAt(_downStats.Count - 1);
        }
        else
        {
            _stats = new BasicStats(_walkSpeed, _runSpeed, _jumpHeight, _mass);
        }   
    }

}
