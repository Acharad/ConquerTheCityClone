using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConquerTheCity.Controllers
{
    public class LineColliderController : MonoBehaviour
    {
        GameObject _mainObject;
        GameObject _enemyObject;

        LineController _lineController;

        SquareController _squareController;

        private void Awake()
        {
            _squareController = GetComponentInParent<SquareController>();
            _mainObject = _squareController.SquareMainObject;
            _lineController = _mainObject.GetComponent<LineController>();
            
        }

        public void FindEnemyObject(GameObject enemyObject)
        {
            _enemyObject = enemyObject;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if(_enemyObject != null)
            {
                if(collider.gameObject != _mainObject && collider.gameObject != _enemyObject && !collider.gameObject.CompareTag("Circle") && !collider.gameObject.CompareTag("Background") && !collider.gameObject.CompareTag("LineCollider"))
                {
                    // Debug.Log(collider.gameObject);
                    Destroy(this.gameObject.transform.parent.gameObject);
                    _lineController.lineCount -= 1;

                }
            }
        }


    }  
}

