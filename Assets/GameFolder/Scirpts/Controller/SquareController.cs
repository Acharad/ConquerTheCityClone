using System.Collections;
using System.Collections.Generic;
using ConquerTheCity.Combats;
using UnityEngine;

namespace ConquerTheCity.Controllers
{
    public class SquareController : MonoBehaviour
    {
        private GameObject _squareMainObject;
        public GameObject SquareMainObject => _squareMainObject;
        [SerializeField] Color mainObjectColor;

        public Color MainObjectColor => mainObjectColor;

        TeamColor _teamColor;


        private void Awake()
        {
            _teamColor = GetComponent<TeamColor>();
            mainObjectColor = _teamColor.ObjectColor;
            _squareMainObject = this.gameObject;
        }

        private void Update()
        {
            _teamColor.SetColor(this.gameObject);
        }
    }    
}
