using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ConquerTheCity.Uis
{
    public class Health : MonoBehaviour
    {
        TextMeshProUGUI _healthText;

        
        private void Awake()
        {
            _healthText = GetComponent<TextMeshProUGUI>();
        }

        public void WriteHealth(int currentHealth)
        {
            _healthText.text = currentHealth.ToString();
        }
    }   
}