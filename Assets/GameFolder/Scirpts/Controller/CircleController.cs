using System.Collections;
using System.Collections.Generic;
using ConquerTheCity.Combats;
using UnityEngine;

namespace ConquerTheCity.Controllers
{
    public class CircleController : MonoBehaviour
    {
        GameObject mainObject;

        DisplayHealth _displayHealth;

        private void Awake()
        {
            mainObject = this.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;
        }


        private void OnTriggerEnter2D(Collider2D collider)
        {
            if(collider.gameObject.CompareTag("Circle"))
            {
                Destroy(this.gameObject);
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
