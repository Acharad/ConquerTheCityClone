using System.Collections;
using System.Collections.Generic;
using ConquerTheCity.Controllers;
using UnityEngine;

namespace ConquerTheCity.Spawners
{
    public class CircleSpawner : MonoBehaviour
    {
        GameObject circle;

        [SerializeField] int _delay = 1;
        float timer;

        bool canInstantiate;

        
        private void Awake()
        {
            circle = Resources.Load<GameObject>("Prefabs/Objects/Circle");
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
                Debug.Log("Küre oluşturuluyor");
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

    }    
}
