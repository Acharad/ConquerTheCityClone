using System.Collections;
using System.Collections.Generic;
using ConquerTheCity.Controllers;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace ConquerTheCity.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set;}

        void Awake()
        {
            SingeltonThisGameObject();
        }

        private void SingeltonThisGameObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void SetActiveCanvas(Canvas ActiveCanvas)
        {
            Time.timeScale = 0f;
            ActiveCanvas.gameObject.SetActive(true);
        }

        public void LoadScene(int sceneNumber)
        {
            SceneManager.LoadScene(sceneNumber);
        }
    }
}
