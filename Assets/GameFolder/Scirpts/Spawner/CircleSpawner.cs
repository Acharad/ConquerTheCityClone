using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConquerTheCity.Spawners
{
    public class CircleSpawner : MonoBehaviour
    {
        [SerializeField] GameObject circle;
        [SerializeField] int _delay = 1;
        float timer;
        Vector3 endPos;

        bool canInstantiate;

        private void Update()
        {
            dealayTime();
            // CreateCircle();
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

        public void CreateCircle(Quaternion rotation)
        {
            if(canInstantiate)
            {
                Instantiate(circle, this.transform.position , rotation);
            }
        }

    }    
}
