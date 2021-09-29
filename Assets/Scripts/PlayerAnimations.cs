using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerMovement;
    private Rigidbody2D _rigibody;
    private PlayerInput _input;
    private PlayerAudio _audio;
    private AudioSource _AudioSource;

    private readonly int _sideWalk = Animator.StringToHash("SideWalk");
    private readonly int _upDown = Animator.StringToHash("UpDown");

    public bool playerBark;
    private static readonly int CanWalk = Animator.StringToHash("canWalk");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        _rigibody = GetComponent<Rigidbody2D>();
        _input = GetComponent<PlayerInput>();
        _audio = GetComponent<PlayerAudio>();
        _AudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_input.moveVector != Vector2.zero && !_playerMovement.isDashing)
        {
            _animator.SetFloat(_sideWalk, _input.moveVector.x);
            _animator.SetFloat(_upDown, _input.moveVector.y);
            _animator.SetBool(CanWalk, true);
        }
        else
        {
            _animator.SetBool(CanWalk, false);
        }
        
        
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