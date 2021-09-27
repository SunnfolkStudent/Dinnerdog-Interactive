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
        
        public static void SetEnemyLives(int value)
        {
            enemyLives = value;
        }
        
        public static void AddEnemyLives()
        {
            enemyLives++;
        }
        
        public static void ReduceEnemyLives()
        {
            enemyLives--;
        }
        
    }
}