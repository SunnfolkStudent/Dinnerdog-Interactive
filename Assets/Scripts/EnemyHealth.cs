using UnityEngine;

namespace Managers
{
    public class EnemyHealth : MonoBehaviour
    {
        public int enemyLives = 3;
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

    }
}