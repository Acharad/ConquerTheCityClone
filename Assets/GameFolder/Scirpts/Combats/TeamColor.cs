using System.Collections;
using System.Collections.Generic;
using ConquerTheCity.Controllers;
using UnityEngine;

namespace ConquerTheCity.Combats
{
    public class TeamColor : MonoBehaviour
    {
        [SerializeField] bool isGreen;
        [SerializeField] bool isRed;

        SquareController _squareController;


        Color objectColor;

        // public Color ObjectColor => objectColor;

        public Color ObjectColor { get ; set; }

        private void Awake()
        {
            FindColor();
            ObjectColor = objectColor;
            _squareController = GetComponent<SquareController>(); 
        }

        public void SetColor()
        {
            _squareController.SquareMainObject.GetComponent<MeshRenderer>().material.color = ObjectColor;
        }

        public void ChangeColor(Color enemyColor)
        {
            _squareController.SquareMainObject.GetComponent<MeshRenderer>().material.color = enemyColor;
            _squareController.MainObjectColor = enemyColor;
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
