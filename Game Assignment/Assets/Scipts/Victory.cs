using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Victory : MonoBehaviour
{

    public static bool isVictory;
    public GameObject gameOverScreenObject;
    MenuSoundManager audioManager;

    public void Awake()
    {
        Time.timeScale = 1;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<MenuSoundManager>();
        isVictory = false;
        gameOverScreenObject.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isVictory)
        {
            Time.timeScale = 0;
            audioManager.PlaySFX(audioManager.victory);
            gameOverScreenObject.gameObject.SetActive(true);
        }
    }
}
