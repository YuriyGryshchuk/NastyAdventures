using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrigerToPlayer : MonoBehaviour
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
        if (Vector3.Angle(transform.forward, _target.transform.position - transform.position) <= _enemyView && 
                Vector3.Distance(transform.position, _target.transform.position) <= _enemyViewDistance)
        {
            _lightDetection.color = Color.red;
            TargetChanged?.Invoke(_target);
        }
        else
        {
            _lightDetection.color = Color.green;
        }
    }

}
