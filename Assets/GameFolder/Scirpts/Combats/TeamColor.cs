using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConquerTheCity.Combats
{
    public class TeamColor : MonoBehaviour
    {
        [SerializeField] bool isGreen;
        [SerializeField] bool isRed;

        Color objectColor;

        public Color ObjectColor => objectColor;

        private void Awake()
        {
            FindColor();
        }

        public void SetColor(GameObject Square)
        {

            Square.GetComponent<MeshRenderer>().material.color = objectColor;

        }

        private void FindColor()
        {
            if(isGreen)
            {
                objectColor = Color.green;
            }
            else if(isRed)
            {
                objectColor = Color.red;
            }
            else
            {
                objectColor = Color.white;
            }
        }
    }    
}
