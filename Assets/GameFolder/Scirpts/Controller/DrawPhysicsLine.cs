using UnityEngine;
using System.Collections;


namespace ConquerTheCity.Controllers
{
    public class DrawPhysicsLine : MonoBehaviour 
    {
        private LineRenderer line;
        // [SerializeField] int cubeLineCount = 0;


      

        // Following method creates line runtime using Line Renderer component
        public void createLine(GameObject parent, Vector3 startpos, Vector3 endPos)
        {
            line = new GameObject("Line").AddComponent<LineRenderer>();
            line.transform.parent = parent.transform;
            //line.material =  new Material(Shader.Find("Line"));
            line.positionCount = 2;
            line.startColor = Color.green;
            line.endColor = Color.green;
            line.useWorldSpace = true;
            line.SetWidth(0.2f,0.2f);
            line.SetPosition(0, startpos);
            line.SetPosition(1, endPos);
        }       

        // Following method adds collider to created line
        public void addColliderToLine(Vector3 startPos, Vector3 endPos, int count)
        {
            BoxCollider2D col = new GameObject("Collider " + count).AddComponent<BoxCollider2D> ();
            col.transform.parent = line.transform; // Collider is added as child object of line
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
        }
    }    
}