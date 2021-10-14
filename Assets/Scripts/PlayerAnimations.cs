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
    private PlayerAttack _attack;

    private readonly int _sideWalk = Animator.StringToHash("SideWalk");
    private readonly int _upDown = Animator.StringToHash("UpDown");
    
    private static readonly int CanWalk = Animator.StringToHash("canWalk");
    private static readonly int isBarking = Animator.StringToHash("isBarking");
    private static readonly int isDashing = Animator.StringToHash("isDashing");

    public Animator _barkAnim;


    public CapsuleCollider2D _horizontal;
    public CapsuleCollider2D _vertical;

    private void Start()
    {
        _vertical.enabled = false;
        
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        _rigibody = GetComponent<Rigidbody2D>();
        _input = GetComponent<PlayerInput>();
        _audio = GetComponent<PlayerAudio>();
        _AudioSource = GetComponent<AudioSource>();
        _attack = GetComponent<PlayerAttack>();
    }
    
    private void Update()
    {
        if (_input.moveVector != Vector2.zero && !_playerMovement.isDashing)
        {
            _animator.SetFloat(_sideWalk, _input.moveVector.x);
            _animator.SetFloat(_upDown, _input.moveVector.y);
            
            _barkAnim.SetFloat(_sideWalk, _input.moveVector.x);
            _barkAnim.SetFloat(_upDown, _input.moveVector.y);
            
            _animator.SetBool(CanWalk, true);
        }
        else
        {
            _animator.SetBool(CanWalk, false);
        }

        if (_input.attack && _attack.canAttack)
        {
            _animator.SetBool(isBarking, true);
            _barkAnim.Play("Bark");
        }
        else
        {
            _animator.SetBool(isBarking, false);
        }

        if (_input.dash)
        {
            _animator.SetBool(isDashing, true);
        }
        else
        {
            _animator.SetBool(isDashing, false);
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

    public void SetHorizontalCollision()
    {
        _horizontal.enabled = true;
        _vertical.enabled = false;
    }

    public void SetVerticalCollision()
    {
        _horizontal.enabled = false;
        _vertical.enabled = true;
    }
}