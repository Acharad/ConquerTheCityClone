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
        bool hasLine = false;
        [SerializeField] bool _canDraw = false;
        DrawPhysicsLine _drawPhysicsLine;


        [SerializeField] GameObject _circle;

        public GameObject Circle => _circle;
        public bool HasLine => hasLine;

        [SerializeField] List<GameObject> Lines;
        LineRenderer _deletedObjectLr;


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
            DeleteLine();
        }

        public void DrawLine(GameObject startObject, Vector3 startPos, Vector3 endPos, GameObject endObject)
        {
            if(_canDraw)
            {
                lineCount += 1;
                _drawPhysicsLine.createLine(startObject, startPos, endPos, lineCount);
                _drawPhysicsLine.addColliderToLine(startPos, endPos, lineCount, endObject);
                _drawPhysicsLine.addSpawnerToLine(startObject, endPos ,endObject);
                _canDraw = false;
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

        private void DeleteLine()
        {
            if(_displayHealth.CubeHealth < 30 && lineCount == 3)
            {
                Destroy(Lines[2]);
                Lines.RemoveAt(2);
                lineCount -= 1;
            }
            if(_displayHealth.CubeHealth < 20 && lineCount == 2)
            {
                Destroy(Lines[1]);
                Lines.RemoveAt(1);
                lineCount -= 1;
            }
            if(_displayHealth.CubeHealth <= 0 && lineCount == 1 )
            {
                Destroy(Lines[0]);
                Lines.RemoveAt(0);
                lineCount -= 1;
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

        public void AddLinesToList(GameObject addedObject)
        {
            Lines.Add(addedObject);
        }

        public void DeleteLinesToList(GameObject deletedObject)
        {
            Lines.Remove(deletedObject);
        }

    }    
}
