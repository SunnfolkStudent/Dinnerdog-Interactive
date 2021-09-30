using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        public bool isInvincible;
        [SerializeField] private float invincibilityTime = 1f;
        private SceneController _sceneController;
        

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
            if (!isInvincible)
            {
                lives--;
                StartCoroutine(Invincibility());
            }
        }

        private void Update()
        {
            currentLives = lives;
            if (lives > 3)
            {
                lives = 3;
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

                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        IEnumerator Invincibility()
        {
            isInvincible = true;
            yield return new WaitForSeconds(invincibilityTime);
            isInvincible = false;
        }
    }
}
