using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private CharacterController _playerController;    
    [SerializeField] private float _groundDistance = 0.4f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;

    private Player _player;
    private Vector3 _vectorToMove;
    private bool _isGrounded;
    private float _speed;
    
    private Mover _mover = new Mover();
    private Gravity _gravity = new Gravity();
    private Vector3 _velocity;

     private void Start()
    {
        _player = this.GetComponent<Player>();
    }


    private void Update()
    {
        _isGrounded = _gravity.GroundedCheck(_groundCheck, _groundMask, _groundDistance);
        _speed = _mover.Boosting(_player.GetStats().WalkSpeed, _player.GetStats().RunSpeed);
        _vectorToMove = _mover.GetVectorInInput(_playerController, _speed);

        _mover.MoveToVector(_playerController, _vectorToMove, _speed);
        _velocity = _gravity.Attract(_playerController, _velocity, _isGrounded, _player.GetStats().Mass);
        _velocity = _mover.Jumping(_player.GetStats().JumpHeight, _velocity, _isGrounded, -9.8f);
      
        _mover.Squatting(_playerController);
    }
}
