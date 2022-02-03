using System.Collections;
using System.Collections.Generic;
using ConquerTheCity.Uis;
using ConquerTheCity.Controllers;
using UnityEngine;

namespace ConquerTheCity.Combats
{
    public class DisplayHealth : MonoBehaviour
    {
        [SerializeField] int health = 15;
        [SerializeField] float _delay = 1;

        
        protected float timer;

        LineController _lineController;
        TeamColor _teamColor;

        Health _health;

        public int CubeHealth => health;

        private void Awake()
        {
            _health = GetComponentInChildren<Health>();
            _lineController = GetComponent<LineController>();
            _teamColor = GetComponent<TeamColor>();
        }

        private void Update()
        {
            IncreaseHealth();
            _health.WriteHealth(health);
        }
    
        private void IncreaseHealth()
        {
            timer += Time.deltaTime;
            if(_lineController.HasLine)
            {
                if(timer >= _delay)
                {
                    timer = 0;
                }
            }
            if(timer >= _delay)
            {
                health += 1;
                timer = 0;
            }
        }

        public void ChangeHealth(bool isTeammate, Color enemyColor)
        {
            if(isTeammate)
            {
                health +=1;
            }
            else
            {
                if(health > 0)
                {
                    health -=1;
                }
                else
                {
                    // _teamColor.ObjectColor = enemyColor;
                    _teamColor.ChangeColor(enemyColor);
                }
            }
        }

        
    }
}

