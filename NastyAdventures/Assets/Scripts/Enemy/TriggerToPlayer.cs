using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerToPlayer: MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _enemyView = 45f;
    [SerializeField] private float _enemyViewDistance = 3;
    [SerializeField] private Light _lightDetection;
  
    public event UnityAction<Player> TargetChanged;

    private void LateUpdate()
    {
        FindTarget();
    }

    private void FindTarget()
    {

        if (CheckPlayerInEnemyViev())
        {     
            
                _lightDetection.color = Color.red;
                TargetChanged?.Invoke(_target);         
          
        }
        else
        {
            _lightDetection.color = Color.green;
        }
    }



 
    private bool CheckPlayerInEnemyViev()
    {
        if (Vector3.Angle(transform.forward, _target.transform.position - transform.position) <= _enemyView &&
                Vector3.Distance(transform.position, _target.transform.position) <= _enemyViewDistance && !CheckObstacleBetweenPlayerAndEnemy())
        {
            return true;
        }
        return false;
     }



    private bool CheckObstacleBetweenPlayerAndEnemy()
    {
        RaycastHit hit;

        Vector3 posTarget = new Vector3(_target.transform.position.x, _target.transform.position.y + 1f, _target.transform.position.z);

        Debug.DrawRay(transform.position, (posTarget - transform.position).normalized * Vector3.Distance(transform.position, _target.transform.position));

        if (Physics.Raycast(transform.position, (posTarget - transform.position).normalized * Vector3.Distance(transform.position, _target.transform.position), out hit) && hit.collider.GetComponent<CharacterController>())
        {
            return false;
        }
        return true;
    }

}
