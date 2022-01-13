using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConquerTheCity.Inputs
{
    public class Inputs : MonoBehaviour
    {
        [SerializeField] Camera gameCamera;
        //[SerializeField] float _distance = 0f;

        //Input.GetMouseButtonDown(0) ilk tıklama anı

        //if (Input.GetMouseButton(0)) tıklama devam ediyor

        //if (Input.GetMouseButtonUp(0)) tıklama bitti

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(gameCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                
                if (hit.collider.CompareTag("Tower"))
                {
                    Debug.Log ("Target name: " + hit.collider.name);
                }
                else 
                {
                    Debug.Log ("Target name: " + hit.collider.name);
                }
            }

        }
    }   
}

