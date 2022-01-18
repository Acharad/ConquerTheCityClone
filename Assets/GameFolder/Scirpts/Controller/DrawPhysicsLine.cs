﻿using UnityEngine;
using System.Collections;


namespace ConquerTheCity.Controllers
{
    public class DrawPhysicsLine : MonoBehaviour 
    {
        // Following method adds collider to created line
        public void addColliderToLine(GameObject line, Vector3 startPos, Vector3 endPos, int count)
        {
            BoxCollider2D col = new GameObject("Collider" + count).AddComponent<BoxCollider2D> ();
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