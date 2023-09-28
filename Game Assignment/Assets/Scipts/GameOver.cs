using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreenObject;


    public void Awake()
    {
        isGameOver = false;
        gameOverScreenObject.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isGameOver)
        {
            gameOverScreenObject.gameObject.SetActive(true);
        }
    }

    public void RestartButton()
    {
        TimerCounter.timeLimit = 300;
        EnemyKillCount.countKill = 0;
        SceneManager.LoadScene("NewGame");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
