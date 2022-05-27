using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boll : MonoBehaviour
{
    [SerializeField] private Transform _graundCheck;
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private float _groundDistanse = 0.2f;

    private float _speed;
    private Vector3 _targetPosition;
    private bool _isHit;
    public event UnityAction HitedTarget;

    Gravity gravity = new Gravity();

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed);

        HitTarget();
        Missed();
    }

    public void Init(float bollSpeed, Vector3 targetPosition)
    {
        _speed = bollSpeed;
        _targetPosition = targetPosition;
    }

    private void HitTarget()
    {
        _isHit = gravity.GroundedCheck(_graundCheck, _targetMask, _groundDistanse);

        if (_isHit)
        {
            HitedTarget?.Invoke();
            Destroy(this.gameObject);
        }
    }

    private void Missed()
    {
        if (transform.position == _targetPosition)
            Destroy(this.gameObject);
    }
}
