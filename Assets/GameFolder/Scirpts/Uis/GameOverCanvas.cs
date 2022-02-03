using System.Collections;
using System.Collections.Generic;
using ConquerTheCity.Managers;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace ConquerTheCity.Uis
{
    public class GameOverCanvas : MonoBehaviour
    {
        public void RestartButtonClick()
        {
            GameManager.Instance.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }

        public void ExitButtonClick()
        {
            Debug.Log("Quit Game Triggered");
            Application.Quit();
        }
    }    
}
