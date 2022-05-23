using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float WalkSpeed { get; private set; }
    public float RunSpeed { get; private set; }
    public float JumpHeight { get; private set; }
    public float Mass { get; private set; }




    [SerializeField] private float _walkSpeed = 10f;
    [SerializeField] private float _runSpeed = 20f;
    [SerializeField] private float _jumpHeight = 3f;
    [SerializeField] private float _massPlayer;

    private void Awake()
    {
        WalkSpeed = _walkSpeed;
        RunSpeed = _runSpeed;
        JumpHeight = _jumpHeight;
        Mass = _massPlayer;
    }



}
