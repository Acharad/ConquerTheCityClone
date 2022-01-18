using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConquerTheCity.Controllers
{
    public class DeleteLine : MonoBehaviour
    {
        public void DestroyLine(GameObject destroyObject)
        {
            Destroy(destroyObject);
        }
    }    
}
