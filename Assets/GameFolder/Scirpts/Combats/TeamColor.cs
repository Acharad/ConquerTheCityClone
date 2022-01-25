using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConquerTheCity.Combats
{
    public class TeamColor : MonoBehaviour
    {
        [SerializeField] bool isGreen;
        [SerializeField] bool isRed;

        public void SetColor(GameObject Square)
        {
            if (isGreen)
            {
                Square.GetComponent<MeshRenderer>().material.color = Color.green;
            }
            else if (isRed)
            {
                Square.GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }


        // private void CheckColor(GameObject Square)
        // {
        //     if(isGreen)
        //     {

        //     }
        // }
    }    
}
