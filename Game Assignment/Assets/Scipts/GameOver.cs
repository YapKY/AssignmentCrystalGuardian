using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreenObject;
    MenuSoundManager audioManager;

    public void Awake()
    {
        Time.timeScale = 1;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<MenuSoundManager>();
        isGameOver = false;
        gameOverScreenObject.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isGameOver)
        {
            Time.timeScale = 0;
            audioManager.PlaySFX(audioManager.gameOver);
            gameOverScreenObject.gameObject.SetActive(true);
        }
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        ExpBar.level = 1;
        TimerCounter.timeLimit = 300;
        EnemyKillCount.countKill = 0;
        SceneManager.LoadScene("NewGame");
    }

    public void ExitButton()
    {
        ExpBar.level = 1;
        TimerCounter.timeLimit = 300;
        EnemyKillCount.countKill = 0;
        SceneManager.LoadScene("Main Menu");
    }
}
