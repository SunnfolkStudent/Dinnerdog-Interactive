using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public Transform attackPosUp;
    public Transform attackPosDown;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
    private int _moveDirection;
    
    
    private PlayerInput _Input;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _Input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (_Input.moveVector.x != 0)
        {
            _moveDirection = 1;
        }
        else if (_Input.moveVector.y !=0)
        { 
            if (_Input.moveVector.y < 0)
            {
                _moveDirection = 3;
            }
            else
            {
                _moveDirection = 2;
            }
        }
        
        if (timeBtwAttack <= 0)
        {
            print("time between is OK");
            //then you can attack
            if (_Input.attack)
            {
                print("attack input detected");
                
                if (_moveDirection == 2)
                {
                    print("attack up");
                    Collider2D[] enemiesToDamageUp =
                        Physics2D.OverlapCircleAll(attackPosUp.position, attackRange, whatIsEnemies);
                    for (int i = 0; i < enemiesToDamageUp.Length; i++)
                    {
                        enemiesToDamageUp[i].GetComponent<EnemyHealth>().EnemyTakeDamage(damage);
                    }
                }

                else if (_moveDirection == 1)
                {
                    print("attack normal");
                    Collider2D[] enemiesToDamage =
                        Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        enemiesToDamage[i].GetComponent<EnemyHealth>().EnemyTakeDamage(damage);
                    }
                }
                
                else if (_moveDirection == 3)
                {
                    print("attack down");
                    Collider2D[] enemiesToDamageDown =
                        Physics2D.OverlapCircleAll(attackPosDown.position, attackRange, whatIsEnemies);
                    for (int i = 0; i < enemiesToDamageDown.Length; i++)
                    {
                        enemiesToDamageDown[i].GetComponent<EnemyHealth>().EnemyTakeDamage(damage);
                    }
                }

                timeBtwAttack = startTimeBtwAttack;
            }
            
        }
        else
        {
            timeBtwAttack -= 1 * Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
        Gizmos.DrawWireSphere(attackPosUp.position, attackRange);
        Gizmos.DrawWireSphere(attackPosDown.position, attackRange);
    }
}
