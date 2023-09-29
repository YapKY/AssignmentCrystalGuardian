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
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<MenuSoundManager>();
        isGameOver = false;
        gameOverScreenObject.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isGameOver)
        {
            audioManager.PlaySFX(audioManager.gameOver);
            gameOverScreenObject.gameObject.SetActive(true);
        }
    }

    public void RestartButton()
    {
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
