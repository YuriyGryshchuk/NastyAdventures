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
    
    
    private Stack<IStatsProvider> _downStatsStack;

    private List<IStatsProvider> _downStats;

    private StatsDecorator _lastAbility;
    private void Awake()
    {
        _downStatsStack = new Stack<IStatsProvider>();
        _downStats = new List<IStatsProvider>();
        _stats = new BasicStats(_walkSpeed, _runSpeed, _jumpHeight, _mass);
    

    }


    


    public PlayerStats GetStats()
    {
       return _stats.GetStats();
    }


    public void SetAbility(StatsDecorator stats)
    {
        _downStats.Add(_stats);
        _stats = stats;
        _lastAbility = stats;
        StartCoroutine(AbilityTimer(stats));
    }


    private IEnumerator AbilityTimer(StatsDecorator stats)
    {
        yield return new WaitForSeconds(5f);

        

        if (_downStats.Count > 1)
        {
           
            _downStats.Remove(stats);
     
            _lastAbility.Init(_downStats[_downStats.Count - 1]);
            _downStats.Add(_lastAbility);
       
        }
       
        


        _stats = _downStats[_downStats.Count - 1];
     
        Debug.Log(_stats);
            

    }

}
