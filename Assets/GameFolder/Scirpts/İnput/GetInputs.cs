using System.Collections;
using System.Collections.Generic;
using ConquerTheCity.Combats;
using UnityEngine;

namespace ConquerTheCity.Inputs
{
    public class GetInputs : MonoBehaviour
    {
        [SerializeField] Camera gameCamera;
        
        //[SerializeField] float _distance = 0f;

        private GameObject _firstObject;
        private GameObject _secondObject;
        
        string a;

        Vector3 _startPos;
        Vector3 _endpos;
        public bool hit1 = false;
        public bool hit2 = false;

        Vector2 camPosition;

       

        CreateLine _createLine;
        LineRenderer lr;

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
                if (hit.collider != null)
                {
                    _firstObject = hit.collider.gameObject;
                    _startPos = _firstObject.transform.position;
                    Debug.Log(_startPos);
                    hit1 = true;
                    Debug.Log("hit1:" + hit1);
                }
                else
                {
                    hit1 = false;
                    //DeletePosition(_startPos);
                    Debug.Log("hit1:" + hit1);
                }
            }
            if(Input.GetMouseButton(0))
            {
                if (hit1 == true)
                {
                    DrawLine(_startPos, camPosition);
                }                
            }
            

            if (Input.GetMouseButtonUp(0))
            {
                if (hit.collider != null)
                {
                    _secondObject = hit.collider.gameObject;
                    _endpos = _secondObject.transform.position;
                    Debug.Log(_endpos);
                    hit2 = true;
                    Debug.Log("hit2:" + hit2);
                }
                else
                {
                    hit1= false;
                    hit2 = false;
                    //DeletePosition(_endpos);
                    Debug.Log("hit2:" + hit2);
                }

                if(hit1 && hit2)
                {
                    DrawLine(_startPos, _endpos);
                    Debug.Log("draw line hit1,hit2");
                    hit1 = false;
                    hit2 = false;
                }
                else
                {
                    lr.positionCount = 0;
                    Debug.Log("delete line");
                }
            }
        }

        private void DrawLine(Vector3 start,Vector3 end)
        {
            lr.SetPosition(0, start);
            lr.SetPosition(1 , end); 
        }
    }   
}

