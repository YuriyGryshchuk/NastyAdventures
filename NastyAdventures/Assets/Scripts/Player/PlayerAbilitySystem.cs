using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerAbilitySystem : MonoBehaviour
{
    [SerializeField] private List<StatsDecorator> _playerAbilitys;

    private Player _player;

    public UnityEvent<int> onCastAbility;

    private void Start()
    {
        
        _player = GetComponent<Player>();
      
        onCastAbility.AddListener(CastAbility);
       
    }


    private void Update()
    {
      
        if (Input.GetButtonDown("Ability1") && _playerAbilitys[0] != null)
        {
            
            
            onCastAbility?.Invoke(0);

        }
        if (Input.GetButtonDown("Ability2") && _playerAbilitys[1] != null)
        {

           
            onCastAbility?.Invoke(1);

        }
        if (Input.GetButtonDown("Ability3") && _playerAbilitys[2] != null)
        {

          
            onCastAbility?.Invoke(2);

        }
        if (Input.GetButtonDown("Ability4") && _playerAbilitys[3] != null)
        {

            onCastAbility?.Invoke(3);

        }
    }

    private void CastAbility(int indexAbility)
    {
        _playerAbilitys[indexAbility].Init(_player._stats);
        _player.SetStats(_playerAbilitys[indexAbility]);
       
    }
    
    
}
