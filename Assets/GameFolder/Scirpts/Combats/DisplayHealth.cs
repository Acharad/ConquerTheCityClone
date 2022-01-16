using System.Collections;
using System.Collections.Generic;
using ConquerTheCity.Uis;
using UnityEngine;

namespace ConquerTheCity.Combats
{
    public class DisplayHealth : MonoBehaviour
    {
        [SerializeField] int health = 15;
        int _delay = 1;
        protected float timer;

        Health _health;

        public int CubeHealth => health;


        private void IncreaseHealth()
        {
            timer += Time.deltaTime;
            
            if(timer >= _delay)
            {
                health += _delay;
                timer = 0;
            }
        }

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        private void Update()
        {
            IncreaseHealth();
            _health.WriteHealth(health);
        }
    }
}

