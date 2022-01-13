using System.Collections;
using System.Collections.Generic;
using ConquerTheCity.Inputs;
using UnityEngine;

namespace ConquerTheCity.Combats
{
    public class CreateLine : MonoBehaviour
    {
        public Color c1 = Color.yellow;
        public Color c2 = Color.red;

        GetInputs _getInput;

        LineRenderer lr;
        Camera cam;

        private void Awake()
        {
            lr = GetComponent<LineRenderer>();
            _getInput = GetComponent<GetInputs>();
        }

        private void Start()
        {
            lr.enabled = true;
            cam = Camera.main;
        }

        public void MakeLine(Vector3 startpos)
        {
            lr.SetPosition(0, startpos);
        }
    }
}

