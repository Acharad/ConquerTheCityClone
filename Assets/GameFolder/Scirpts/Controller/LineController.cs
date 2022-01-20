using System.Collections;
using System.Collections.Generic;
using ConquerTheCity.Inputs;
using ConquerTheCity.Spawners;
using ConquerTheCity.Combats;
using ConquerTheCity.Move;
using UnityEngine;

namespace ConquerTheCity.Controllers
{
    public class LineController : MonoBehaviour
    {
        // Line Controller draw physics line fonksiyonuna taşınacak.
        [SerializeField] bool hasLine = false;
        [SerializeField] bool _canDraw = false;
        DrawPhysicsLine _drawPhysicsLine;

        [SerializeField] GameObject _circle;

        public GameObject Circle => _circle;
        public bool HasLine => hasLine;


        public int lineCount;


        DisplayHealth _displayHealth;
        Mover _mover;

        private void Awake()
        {
            _displayHealth = GetComponentInChildren<DisplayHealth>();
            _drawPhysicsLine = GetComponent<DrawPhysicsLine>();
        }
        private void Update()
        {
            CanDrawLine();
            HasLineController();
        }

        public void DrawLine(GameObject line,Vector3 startPos, Vector3 endPos)
        {
            if(_canDraw)
            {
                _drawPhysicsLine.createLine(line, startPos, endPos);
                _drawPhysicsLine.addColliderToLine(startPos, endPos, lineCount+1);
                _drawPhysicsLine.addSpawnerToLine(line, endPos);
                _canDraw = false;
                lineCount += 1;
            }
            else
            {
                Debug.Log("Line çizilemez çünkü _canDraw = " + _canDraw);
            }
        }

        public void ChanceLineCount()
        {
            lineCount -=1;
        }

        private void CanDrawLine()
        {
            if(_canDraw) return;

            if(_displayHealth.CubeHealth >= 30 && lineCount == 2)
            {
                _canDraw = true;
            }
            if(_displayHealth.CubeHealth >= 20 && lineCount == 1)
            {
                _canDraw = true;
            }
            if(_displayHealth.CubeHealth >= 0 && lineCount == 0)
            {
                _canDraw = true;
            }       
        }

        private void HasLineController()
        {
            if(lineCount > 0)
            {
                hasLine = true;
            }
            else
            {
                hasLine = false;
            }
        }

    }    
}
