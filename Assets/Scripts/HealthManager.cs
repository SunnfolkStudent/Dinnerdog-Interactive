using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

namespace Managers
{
    public class HealthManager : MonoBehaviour
    {
        
        [Header("Lives")]
        public static int lives = 3;
        public int maxLives = 3;
        public GameObject heart3;
        public GameObject heart2;
        public GameObject heart1;
        
        [Header("Invincible")]
        public bool isInvincible;
        [SerializeField] private float invincibilityTime = 1f;
        private SceneController _sceneController;
        private PlayerAudio _audio;

        private void Awake()
        {
            lives = maxLives;
        }

        private void Start()
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            _audio = GetComponent<PlayerAudio>();
        }

        public static void SetLives(int value)
        {
            lives = value;
        }

        public void ReduceLives()
        {
            if (!isInvincible)
            {
                lives--;
                _audio.damage();
                StartCoroutine(Invincibility());
            }
        }

        private void Update()
        {
            if (lives > 3)
            {
                lives = 3;
            }
            if (lives >= 3)
            {
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
            }
            else if (lives == 2)
            {
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(false);
            }
            else if (lives == 1)
            {
                heart1.SetActive(true);
                heart2.SetActive(false);
                heart3.SetActive(false);
            }
            else if (lives < 1)
            {
                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(false);
                Destroy(gameObject);

                PlayerInteract.score = 0;
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
