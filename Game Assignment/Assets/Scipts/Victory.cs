using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Victory : MonoBehaviour
{
    public static bool isVictory;
    public GameObject gameOverScreenObject;
    MenuSoundManager audioManager;
    private bool coinsAdded = false;

    public void Awake()
    {
        Time.timeScale = 1;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<MenuSoundManager>();
        isVictory = false;
        gameOverScreenObject.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isVictory && !coinsAdded)
        {
            Time.timeScale = 0;
            audioManager.PlaySFX(audioManager.victory);
            gameOverScreenObject.gameObject.SetActive(true);
            isVictory = true;
            PlayerPrefs.SetInt("NumberOfCoins", PlayerPrefs.GetInt("NumberOfCoins") + 100);
            // Set the flag to indicate that coins have been added.
            coinsAdded = true;
        }
    }
}
