using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Victory : MonoBehaviour
{

    public static bool isVictory;
    public GameObject gameOverScreenObject;


    public void Awake()
    {
        isVictory = false;
        gameOverScreenObject.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isVictory)
        {
            gameOverScreenObject.gameObject.SetActive(true);
        }
    }
}
