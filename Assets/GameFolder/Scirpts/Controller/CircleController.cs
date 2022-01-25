using System.Collections;
using System.Collections.Generic;
using ConquerTheCity.Combats;
using ConquerTheCity.Spawners;
using UnityEngine;

namespace ConquerTheCity.Controllers
{
    public class CircleController : MonoBehaviour
    {
        GameObject mainObject;
        GameObject targetObject;

        public GameObject CircleControllerTargetObject => targetObject;

        DisplayHealth _displayHealth;
        SquareController _squareController;
        CircleSpawner _circleSpawner;
        CircleController _enemyCircleController;

        private void Awake()
        {
            _squareController = GetComponentInParent<SquareController>();
            _circleSpawner = GetComponentInParent<CircleSpawner>();

            mainObject = _squareController.SquareMainObject;
            targetObject = _circleSpawner.TargetGameObject;
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
                _displayHealth.DecreaseHealth();
                Destroy(this.gameObject);
                
            }
        }
    }    
}
