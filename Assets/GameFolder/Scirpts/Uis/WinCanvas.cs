using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using ConquerTheCity.Managers;
using UnityEngine;

namespace ConquerTheCity.Uis
{
    public class WinCanvas : MonoBehaviour
    {
        public void NextLevelButtonClick()
        {
            GameManager.Instance.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Time.timeScale = 1f;
        }

        public void ExitButtonClick()
        {
            Debug.Log("Quit Game Triggered");
            Application.Quit();
        }
    }    
}