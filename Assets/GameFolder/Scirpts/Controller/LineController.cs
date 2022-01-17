using System.Collections;
using System.Collections.Generic;
using ConquerTheCity.Inputs;
using ConquerTheCity.Combats;
using UnityEngine;

namespace ConquerTheCity.Controllers
{
    public class LineController : MonoBehaviour
    {
        LineRenderer lr;
        DrawPhysicsLine _drawphy;

        [SerializeField] int cubeLineCount = 0;
        [SerializeField] int canDrawCount = 0;

        DisplayHealth _displayHealth;

        private void Awake()
        {
            lr = GetComponent<LineRenderer>();
            _displayHealth = GetComponentInChildren<DisplayHealth>();
            _drawphy = GetComponent<DrawPhysicsLine>();
        }

        private void Start()
        {
            lr.enabled = true;
            lr.positionCount = 2;
        }

        private void Update()
        {
            if(_displayHealth.CubeHealth > 30 && cubeLineCount == 2)
            {
                lr.positionCount = 6;
                lr.SetPosition(4, this.transform.position);
                lr.SetPosition(5, this.transform.position);
                canDrawCount = 3;
            }
            else if(_displayHealth.CubeHealth > 20 && cubeLineCount == 1)
            {
                lr.positionCount = 4;
                lr.SetPosition(2, this.transform.position);
                lr.SetPosition(3, this.transform.position);
                canDrawCount = 2;
            }
            else if (_displayHealth.CubeHealth > 0 && cubeLineCount == 0)
            {
                lr.positionCount = 2;
                lr.SetPosition(1, this.transform.position);
                lr.SetPosition(0, this.transform.position);
                canDrawCount = 1;
            }
        }

        public void DrawLine(Vector3 start,Vector3 end)
        {
            if(canDrawCount == 3)
            {
                cubeLineCount = 3;
                lr.SetPosition(4, start);
                lr.SetPosition(5, end);
            }
            if(canDrawCount == 2)
            {
                cubeLineCount = 2;
                lr.SetPosition(2, start);
                lr.SetPosition(3, end);
            }
            if(canDrawCount == 1)
            {
                cubeLineCount = 1;
                lr.SetPosition(0, start);
                lr.SetPosition(1, end);            
            }
        }



    }    
}
