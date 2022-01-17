using System.Collections;
using System.Collections.Generic;
using ConquerTheCity.Combats;
using ConquerTheCity.Controllers;
using UnityEngine;

namespace ConquerTheCity.Inputs
{
    public class GetInputs : MonoBehaviour
    {
        [SerializeField] Camera gameCamera;
        LineController _lineController;
        DrawPhysicsLine _drawphy;
        LineRenderer lr;
        
        //[SerializeField] float _distance = 0f;

        private GameObject _firstObject;
        private GameObject _secondObject;

        Vector3 _startPos;
        Vector3 _endpos;

        public bool hit1 = false;
        public bool hit2 = false;

        Vector2 camPosition;

        //Input.GetMouseButtonDown(0) ilk tıklama anı

        //if (Input.GetMouseButton(0)) tıklama devam ediyor

        //if (Input.GetMouseButtonUp(0)) tıklama bitti

        private void Awake()
        {
            lr = GetComponent<LineRenderer>();
        }

        private void Start()
        {
            lr.enabled = true;
            gameCamera = Camera.main;
            
        }

        private void Update()
        {
            camPosition = gameCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(camPosition, Vector2.zero);
            lr.positionCount = 2;
            if(Input.GetMouseButtonDown(0))
            {
                if (hit.collider.gameObject.tag == "Tower")
                {
                    _firstObject = hit.collider.gameObject;
                    _lineController = _firstObject.GetComponent<LineController>();
                    _drawphy = _firstObject.GetComponent<DrawPhysicsLine>();
                    _startPos = _firstObject.transform.position;

                    hit1 = true;
                    //Debug.Log("hit1:" + hit1);
                }


                else
                {
                    hit1 = false;
                }
            }
            if(Input.GetMouseButton(0))
            {
                if (hit1 == true)
                {
                    Debug.Log(hit.collider);
                    lr.SetPosition(0, _startPos);
                    lr.SetPosition(1, camPosition);
                }
                else
                {
                    Debug.Log(hit.collider.name);
                }    
            }
            

            if (Input.GetMouseButtonUp(0))
            {
                if (hit.collider.gameObject.tag == "Tower")
                {
                    _secondObject = hit.collider.gameObject;
                    _endpos = _secondObject.transform.position;
                    if( _firstObject != _secondObject)
                    {
                        hit2 = true;
                        Debug.Log("Objeler Farkli");
                    }
                }
                else
                {
                    hit1= false;
                    hit2 = false;
                }

                if(hit1 && hit2)
                {
                    _lineController.DrawLine(_startPos, _endpos);
                    _drawphy.addColliderToLine(_firstObject, _startPos , _endpos);
                    hit1 = false;
                    hit2 = false;
                    lr.positionCount = 0;
                }
                else
                {
                    lr.positionCount = 0;
                }
            }
        }
    }   
}

