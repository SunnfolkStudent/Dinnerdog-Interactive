using System;
using UnityEngine;

namespace Managers
{
    public class EnemyHealth : MonoBehaviour
    {
        [Header("Current enemy lives")]
        public int enemyLives = 3;
        
        [Header("Max Lives")]
        public int maxEnemyLives = 3;
        
        private void Awake()
        {
            enemyLives = maxEnemyLives;
        }
        
        public  void SetEnemyLives(int value)
        {
            enemyLives = value;
        }
        
        public void AddEnemyLives()
        {
            enemyLives++;
        }
        
        public void ReduceEnemyLives()
        {
            enemyLives--;
        }

        public void EnemyTakeDamage(int damage)
        {
            enemyLives -= damage;
            print("enemy damage taken");
        }

        private void Update()
        {
            if (enemyLives <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}