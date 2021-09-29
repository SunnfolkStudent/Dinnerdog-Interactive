using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class HealthManager : MonoBehaviour
    {
        public static int lives = 3;
        public int currentLives = lives;
        public int maxLives = 3;
        public GameObject heart3;
        public GameObject heart2;
        public GameObject heart1;
        

        private void Awake()
        {
            lives = maxLives;
        }

        private void Start()
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
        }

        public static void SetLives(int value)
        {
            lives = value;
        }

        public static void AddLives()
        {
            lives++;
        }

        public void ReduceLives()
        {
            lives--;
        }

        private void Update()
        {
            currentLives = lives;
            if (lives > 3)
            {
                ReduceLives();
            }
            if (lives >= 3)
            {
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                print("Aww");
            }
            else if (lives == 2)
            {
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(false);
                print("Aww");
            }
            else if (lives == 1)
            {
                heart1.SetActive(true);
                heart2.SetActive(false);
                heart3.SetActive(false);
                print("Aww");
            }
            else if (lives < 1)
            {
                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(false);
                Destroy(gameObject);
                
                print("Die");
            }
        }
    }
}