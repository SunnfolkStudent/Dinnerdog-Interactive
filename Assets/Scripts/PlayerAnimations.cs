using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerMovement;
    private Rigidbody2D _rigibody;
    private PlayerInput _input;

    private readonly int _sideWalk = Animator.StringToHash("SideWalk");
    private readonly int _upDown = Animator.StringToHash("UpDown");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        _rigibody = GetComponent<Rigidbody2D>();
        _input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        _animator.SetFloat(_sideWalk, _input.moveVector.x);
        _animator.SetFloat(_upDown, _input.moveVector.y);
        
        if (_input.moveVector.x > 0)
        {
            transform.localScale = new Vector2 (-1f, 1f);
        }
        else if (_input.moveVector.x < 0)
        {
            transform.localScale = new Vector3(1f, 1f);
        }
    }
}