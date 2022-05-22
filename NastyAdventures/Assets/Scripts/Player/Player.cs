using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController _player;
    [SerializeField] private Transform _graundCheck;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _mainSpeed = 10f;
    [SerializeField] private float _maxSpeed = 20f;
    [SerializeField] private float _gravity = -9.8f;
    [SerializeField] private float _massPlayer;
    [SerializeField] private float _jumpHeight = 3f;
    [SerializeField] private float _groundDistance = 0.4f;

    private Vector3 _vectorToMove;
    private bool _isGrounded;
    private float _speed;

    Mover mover = new Mover();

   private void Update()
    {
        _isGrounded = mover.GroundedChek(_graundCheck, _groundMask, _groundDistance);
        _speed = mover.Boosting(_mainSpeed, _maxSpeed);
        _vectorToMove = mover.GetVectorInInput(_player, _speed);

        mover.MoveToVector(_player, _vectorToMove, _speed);
        mover.Gravity(_player, _isGrounded, _massPlayer, _gravity);
        mover.Jumping(_jumpHeight, _isGrounded, _gravity);
        mover.Squatting(_player);
    }
}
