using System.Collections;
using System.Collections.Generic;
using ConquerTheCity.Combats;
using ConquerTheCity.Spawners;
using UnityEngine;

namespace ConquerTheCity.Controllers
{
    public class CircleController : MonoBehaviour
    {
        public Color CircleColor;
        bool _isTeammate;

        GameObject mainObject;

        GameObject targetObject;

        public GameObject CircleControllerTargetObject => targetObject;

        DisplayHealth _displayHealth;
        SquareController _squareController;
        CircleSpawner _circleSpawner;
        CircleController _enemyCircleController;
        SquareController _enemySquareController;

        SpriteRenderer _spriteRenderer;


        private void Awake()
        {
            _squareController = GetComponentInParent<SquareController>();
            _circleSpawner = GetComponentInParent<CircleSpawner>();
            _spriteRenderer = GetComponent<SpriteRenderer>();

            mainObject = _squareController.SquareMainObject;

            targetObject = _circleSpawner.TargetGameObject;
            CircleColor = _squareController.MainObjectColor;
            _spriteRenderer.color = CircleColor;
            

            // Debug.Log(targetObject);
        }


        private void OnTriggerEnter2D(Collider2D collider)
        {
            if(collider.gameObject.CompareTag("Circle"))
            {
                _enemyCircleController = collider.gameObject.GetComponent<CircleController>();
                if(_enemyCircleController.CircleControllerTargetObject == mainObject)
                {
                    Destroy(this.gameObject);
                }
            }

            else if(collider.gameObject != mainObject && collider.tag != "LineCollider" && collider.tag != "Background")
            {
                _displayHealth = collider.gameObject.GetComponent<DisplayHealth>();
                _enemySquareController = collider.gameObject.GetComponent<SquareController>();
                
                if(_enemySquareController.MainObjectColor == CircleColor)
                {
                    _isTeammate = true;
                }
                else
                {
                    _isTeammate = false;
                }
                _displayHealth.ChangeHealth(_isTeammate, CircleColor);
                Destroy(this.gameObject);
            }
        }
    }    
}
