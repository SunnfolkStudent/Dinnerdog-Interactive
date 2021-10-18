using System;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class ScoreManager: MonoBehaviour
    {
        public TMP_Text _tmpText;

        private void Start()
        {
            _tmpText.text = "Food Collected: " + PlayerInteract.score + "/3";
        }

        public void SetScoreUI()
        {
            if (PlayerInteract.score >=3)
            {
                _tmpText.text = "Return to kitchen";
            }
            else
            {
                _tmpText.text = "Food Collected: " + PlayerInteract.score + "/3";
            }
        }

        private void Update()
        {
            SetScoreUI();
        }
    }
}