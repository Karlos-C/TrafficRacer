using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject MsgGameOver;
 
  public void ShowGameOver()
    {
        MsgGameOver.SetActive(true);
    }

    private void Update()
    {
        if (MsgGameOver.activeInHierarchy) 
        { 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Game");
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}