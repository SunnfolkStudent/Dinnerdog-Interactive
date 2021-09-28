using UnityEngine;

public class HealthManager : MonoBehaviour
    {
        public int lives = 3;
        public int maxLives = 3;


        private void Awake()
        {
            lives = maxLives;
        }

        public void SetLives(int value)
        {
            lives = value;
        }

        public void AddLives()
        {
            lives++;
        }

        public void ReduceLives()
        {
            lives--;
        }
        
        //Remove this when we can reset scene or reload game
        private void Update()
        {
            if (lives <= 0)
            {
                Destroy(gameObject);
            }
        }
    }