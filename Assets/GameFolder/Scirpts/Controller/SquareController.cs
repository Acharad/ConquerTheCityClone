using System.Collections;
using System.Collections.Generic;
using ConquerTheCity.Combats;
using UnityEngine;

namespace ConquerTheCity.Controllers
{
    public class SquareController : MonoBehaviour
    {
        TeamColor _teamColor;

        private GameObject _squareMainObject;

        public GameObject SquareMainObject => _squareMainObject;

        private void Awake()
        {
            _teamColor = GetComponent<TeamColor>();
            _squareMainObject = this.gameObject;
        }

        private void Update()
        {
            _teamColor.SetColor(this.gameObject);
        }
    }    
}
