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

        Vector3 _startPos;
        Vector3 _endpos;
        bool hit1 = false;
        bool hit2 = false;

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
            RaycastHit2D hit = Physics2D.Raycast(gameCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(Input.GetMouseButtonDown(0))
            {
                if (hit.collider.CompareTag("Tower"))
                {
                    _firstObject = hit.collider.gameObject;
                    _startPos = _firstObject.transform.position;
                    Debug.Log(_startPos);
                    hit1 = true;
                }
            }

            if (Input.GetMouseButton(0))
            {
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (hit.collider.CompareTag("Tower"))
                {
                    _secondObject = hit.collider.gameObject;
                    _endpos = _secondObject.transform.position;
                    Debug.Log(_endpos);
                    hit2 = true;
                }
            }
            if(hit1 && hit2)
            {
                DrawLine(_startPos, _endpos);
                //_startPos = Vector3.zero;
                //_endpos = Vector3.zero;
            }

        }

        private void DrawLine(Vector3 start,Vector3 end)
        {
            lr.SetPosition(0, start);
            lr.SetPosition(1 , end); 
        }
    }   
}

