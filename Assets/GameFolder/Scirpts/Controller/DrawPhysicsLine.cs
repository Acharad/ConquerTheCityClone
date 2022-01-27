using UnityEngine;
using ConquerTheCity.Spawners;
using ConquerTheCity.Controllers;
using System.Collections;


namespace ConquerTheCity.Controllers
{
    public class DrawPhysicsLine : MonoBehaviour 
    {
        private LineRenderer line;
        Rigidbody2D _rigidBody;

        private GameObject LineObject;

        CircleSpawner _circleSpawner;
        LineController _lineController;
        LineColliderController _lineColliderController;

        private void Awake()
        {
            _lineController = GetComponent<LineController>();
        }

        public void createLine(GameObject parentObject, Vector3 startpos, Vector3 endPos, int count)
        {
            LineObject = new GameObject("Line" + count);
            LineObject.transform.parent = parentObject.transform;
            line = new GameObject("LineRenderer").AddComponent<LineRenderer>();
            line.transform.parent = LineObject.transform;
            line.tag = "Line";
            line.material =  new Material(Shader.Find("Diffuse"));
            line.positionCount = 2;
            line.startColor = Color.green;
            line.endColor = Color.green;
            line.useWorldSpace = true;
            // line.SetWidth(0.2f,0.2f);
            line.startWidth = 0.2f;
            line.endWidth = 0.2f;
            line.SetPosition(0, startpos);
            line.SetPosition(1, endPos);
            _lineController.AddLinesToList(LineObject);
        }       

        // Following method adds collider to created line
        public void addColliderToLine(Vector3 startPos, Vector3 endPos, int count, GameObject endObject)
        {
            BoxCollider2D col = new GameObject("Collider " + count).AddComponent<BoxCollider2D> ();
            col.transform.parent = LineObject.transform; // Collider is added as child object of line
            col.isTrigger = true;
            col.tag = "LineCollider";
            float lineLength = Vector3.Distance (startPos, endPos); // length of line
            col.size = new Vector3 (lineLength, 0.2f, 1f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement
            Vector3 midPoint = (startPos + endPos)/2;
            col.transform.position = midPoint; // setting position of collider object
            // Following lines calculate the angle between startPos and endPos
            float angle = (Mathf.Abs (startPos.y - endPos.y) / Mathf.Abs (startPos.x - endPos.x));
            if((startPos.y<endPos.y && startPos.x>endPos.x) || (endPos.y<startPos.y && endPos.x>startPos.x))
            {
                angle*=-1;
            }
            angle = Mathf.Rad2Deg * Mathf.Atan (angle);
            col.transform.Rotate (0, 0, angle);

            _lineColliderController = col.gameObject.AddComponent<LineColliderController>();
            _lineColliderController.FindEnemyObject(endObject);
            _rigidBody = col.gameObject.AddComponent<Rigidbody2D>();
            _rigidBody.bodyType = RigidbodyType2D.Kinematic;
        }

        public void addSpawnerToLine(GameObject parentObject,Vector3 endPos, GameObject targetObject)
        {
            _circleSpawner = new GameObject("CircleSpawner").AddComponent<CircleSpawner>();
            _circleSpawner.transform.parent = LineObject.transform;
            _circleSpawner.transform.position = parentObject.transform.position;
            _circleSpawner.CircleEndPos(endPos);
            _circleSpawner.TargetObject(targetObject);
        }
    }    
}