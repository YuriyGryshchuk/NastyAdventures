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

        Vector3 posTarget = new Vector3(_target.transform.position.x, _target.transform.position.y, _target.transform.position.z);
        Vector3 posEnemyEyes = new Vector3(this.transform.position.x, this.transform.position.y + 1.2f, this.transform.position.z);
        Debug.DrawRay(posEnemyEyes, (posTarget - transform.position).normalized * Vector3.Distance(transform.position, _target.transform.position));

        if (Physics.Raycast(posEnemyEyes, (posTarget - transform.position).normalized * Vector3.Distance(transform.position, _target.transform.position), out hit) && hit.collider.GetComponent<Player>())
        {
            return false;
        }
        return true;
    }

}
