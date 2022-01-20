using System.Collections;
using System.Collections.Generic;
using ConquerTheCity.Spawners;
using UnityEngine;

namespace ConquerTheCity.Move
{
    public class Mover : MonoBehaviour
    {
        public Vector3 endPos;
        Vector2 toTarget;

        CircleSpawner _circleSpawner;

        private void Awake()
        {
            _circleSpawner = GetComponentInParent<CircleSpawner>();
        }
        
        private void Start()
        {
            endPos = _circleSpawner.CircleEndPosition;
            endPos.z = 0;
            toTarget = endPos - transform.position;
        }


        void FixedUpdate()
        {
            float speed = 0.2f;

            transform.Translate(toTarget * speed * Time.deltaTime);
        }

        // public void GetPosition(Vector3 position)
        // {
        //     position = endPos;
        // }
    }    
}
