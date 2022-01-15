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
                    lr.SetPosition(0,_startPos);
                    lr.SetPosition(1, camPosition);
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
                    hit2 = false;
                    //DeletePosition(_endpos);
                    Debug.Log("hit2:" + hit2);
                }
            }
            if(hit1 && hit2)
            {
                Debug.Log(hit1);
                Debug.Log(hit2);
                DrawLine(_startPos, _endpos);
                hit1 = false;
                hit2 = false;
            }
            else if (hit1 || hit2)
            {
                //DeletePosition(_startPos);
                //DeletePosition(_endpos);
                DrawLine(_startPos, _endpos);
                
            }

        }

        private void DrawLine(Vector3 start,Vector3 end)
        {
            lr.SetPosition(0, start);
            lr.SetPosition(1 , end); 
        }
        private void DeletePosition(Vector3 position)
        {
            position.x = 0f;
            position.y = 0f;
            position.z = 0f;
        }
    }   
}

