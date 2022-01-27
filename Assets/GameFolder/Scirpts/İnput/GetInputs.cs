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
        LineRenderer lr;
        LineRenderer _deletedObjectLr;
        
        //[SerializeField] float _distance = 0f;

        private GameObject _firstObject;
        private GameObject _secondObject;
        private GameObject _destroyObject;
        private GameObject _destroyObjectParent;
        private GameObject _mainSquareObject;

        Vector3 _startPos;
        Vector3 _endpos;

        public bool hit1 = false;
        public bool hit2 = false;

        Vector2 camPosition;


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
                    _startPos = _firstObject.transform.position;
                    hit1 = true;
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
                    lr.SetPosition(0, _startPos);
                    lr.SetPosition(1, camPosition);
                }
                else
                {
                    if(hit.transform.gameObject.tag != "Tower" && hit.transform.gameObject.name != "BackGroundSquare" && hit.transform.gameObject.tag != "Circle")
                    {
                        _mainSquareObject = hit.transform.parent.gameObject.transform.parent.gameObject;
                        _destroyObjectParent = hit.transform.parent.gameObject;
                        _destroyObject = hit.transform.gameObject;

                        // Debug.Log(_mainSquareObject);
                        // Debug.Log(_destroyObjectParent);
                        // Debug.Log(_destroyObject);

                        _lineController = _mainSquareObject.GetComponent<LineController>();
                        _deletedObjectLr = _destroyObjectParent.GetComponent<LineRenderer>();
                        // burda bi hata var düzeltilecek.
                        _lineController.ChanceLineCount();
                        _lineController.DeleteLinesToList(_destroyObjectParent);
                        Destroy(_destroyObjectParent);
                    }
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
                    }
                }
                else
                {
                    hit1= false;
                    hit2 = false;
                }

                if(hit1 && hit2)
                {
                    _lineController.DrawLine(_firstObject, _startPos, _endpos, _secondObject);
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

