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
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
    
    private PlayerInput _Input;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _Input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <=0)
        {
            print("time between is OK");
            //then you can attack
            if (_Input.attack)
            {
                print("attack input detected");
                Collider2D[] enemiesToDamage =
                    Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyHealth>().EnemyTakeDamage(damage);
                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
