using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerControl : MonoBehaviour
{
    public Text StartText;

    public GameObject GameOverPanel;
    public GameObject FinishPanel;

    void Start()
    {
        Time.timeScale = 1;
    }

    

    public void StartGame() 
    {
        StartText.gameObject.SetActive(false);

    }
    public void Finish()
    {
        Time.timeScale = 0;
        FinishPanel.gameObject.SetActive(true);
        
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverPanel.gameObject.SetActive(true);
        
    }

    public void NextLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
