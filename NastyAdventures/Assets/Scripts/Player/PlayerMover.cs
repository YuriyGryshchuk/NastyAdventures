using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Player))]
public class PlayerMover : MonoBehaviour
{
    private Player _player;


    [SerializeField] private CharacterController _playerController;    
    [SerializeField] private float _gravity = -9.8f;
    [SerializeField] private float _groundDistance = 0.4f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;

    private Vector3 _vectorToMove;
    private bool _isGrounded;
    private float _speed;
    
    private Mover _mover = new Mover();
     private void Start()
    {
       
        
        _player = this.GetComponent<Player>();
    }


    private void Update()
    {
        _isGrounded = _mover.GroundedCheck(_groundCheck, _groundMask, _groundDistance);
        _speed = _mover.Boosting(_player.WalkSpeed, _player.RunSpeed);
        _vectorToMove = _mover.GetVectorInInput(_playerController, _speed);

        _mover.MoveToVector(_playerController, _vectorToMove, _speed);
        _mover.Gravity(_playerController, _isGrounded, _player.Mass, _gravity);
        _mover.Jumping(_player.JumpHeight, _isGrounded, _gravity);
        _mover.Squatting(_playerController);
    }
}
