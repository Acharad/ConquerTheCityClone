using System.Collections;
using System.Collections.Generic;
using ConquerTheCity.Controllers;
using ConquerTheCity.Move;
using UnityEngine;

namespace ConquerTheCity.Spawners
{
    public class CircleSpawner : MonoBehaviour
    {
        GameObject circle;

        Mover _mover;

        [SerializeField] Vector3 _circleEndPosition;
        [SerializeField] GameObject _targetGameObject;

        public Vector3 CircleEndPosition => _circleEndPosition;
        public GameObject TargetGameObject => _targetGameObject;


        [SerializeField] int _delay = 1;
        float timer;

        bool canInstantiate;

        
        private void Awake()
        {
            circle = Resources.Load<GameObject>("Prefabs/Objects/Circle");
            // _mover = GetComponentInChildren<Mover>();
        }

        private void Update()
        {
            dealayTime();
            CreateCircle();
        }
        
        private void dealayTime()
        {
            timer += Time.deltaTime;
            
            if(timer >= _delay)
            {
                timer = 0;
                canInstantiate = true;
            }
        }

        public void CreateCircle()
        {
            if(canInstantiate)
            {
                // circle.transform.position = this.gameObject.transform.position;
                // circle.transform.parent = this.transform;
                Instantiate(circle, this.transform);
                canInstantiate = false;
            }
        }

        public void CircleEndPos(Vector3 position)
        {
            _circleEndPosition = position;
            // _mover.endPos = position;
        }

        public void TargetObject(GameObject targetGameObject)
        {
            _targetGameObject = targetGameObject;
        }

    }    
}
