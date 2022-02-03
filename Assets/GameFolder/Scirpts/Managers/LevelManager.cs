using System.Collections;
using System.Collections.Generic;
using ConquerTheCity.Controllers;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace ConquerTheCity.Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] public Canvas GameOverCanvas;
        [SerializeField] public Canvas WinCanvas;


        [SerializeField] GameObject[] SquareObjects;
        [SerializeField] float CheckDelay = 1f;

        private float _timer;

        private bool _canCheck = false;

        SquareController _squareController;

        Color _teamColor = Color.green;

        [SerializeField] int TeamMember;
        [SerializeField] int EnemyMember;

        private void Update()
        {
            dealayTime();
            CheckSquareColors();

        }

        private void CheckSquareColors()
        {
            if(!_canCheck) return;
            foreach(GameObject obj in SquareObjects)
            {
                _squareController = obj.GetComponent<SquareController>();
                if(_squareController.MainObjectColor == _teamColor)
                {
                    TeamMember += 1;
                }
                else
                {
                    EnemyMember +=1;
                }
            }
            if(TeamMember == SquareObjects.Length)
            {
                GameManager.Instance.SetActiveCanvas(WinCanvas);
            }
            else if (EnemyMember == SquareObjects.Length)
            {
                GameManager.Instance.SetActiveCanvas(GameOverCanvas);
            }
            TeamMember = 0;
            EnemyMember = 0;
            _canCheck = false;
        }
        private void dealayTime()
        {
            _timer += Time.deltaTime;
                
            if(_timer >= CheckDelay)
            {
                _timer = 0;
                _canCheck = true;
            }
        }
    }    
}

