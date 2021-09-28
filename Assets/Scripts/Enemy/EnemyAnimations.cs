using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    private Animator _animator;
    private EnemyMovement _enemyMovement;
    private Rigidbody2D _rigibody;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _enemyMovement = GetComponent<EnemyMovement>();
        _rigibody = GetComponent<Rigidbody2D>();
    }
    
    
}
