using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    private Animator _animator;
    private EnemyMovement _enemyMovement;
    private Rigidbody2D _rigibody;

    private readonly int _sideWalk = Animator.StringToHash("SideWalk");
    private readonly int _upDown = Animator.StringToHash("UpDown");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _enemyMovement = GetComponent<EnemyMovement>();
        _rigibody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _animator.SetFloat(_sideWalk, _enemyMovement._movementDirection.x);
        _animator.SetFloat(_upDown, _enemyMovement._movementDirection.y);
        
        if(_enemyMovement._movementDirection.x > 0)
        {
            transform.localScale = new Vector2(-1f, 1f);
        } 
        else if(_enemyMovement._movementDirection.x < 0)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
    }
}