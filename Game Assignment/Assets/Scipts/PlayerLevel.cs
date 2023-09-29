using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLevel : MonoBehaviour
{
    [Header("Hero Sprite")]
    public GameObject avatar1;
    public GameObject avatar2;
    public GameObject avatar3;
    private int currentLevel = 1;

    // Start is called before the first frame update
    void Start()
    {
        avatar1.gameObject.SetActive(true);
        avatar2.gameObject.SetActive(false);
        avatar3.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ExpBar.level > currentLevel)
        {
            currentLevel++;
            switchAvatar(currentLevel);
        }

    }

    public void switchAvatar(int level)
    {
        switch (level)
        {
            case 2:
                {
                    avatar1.gameObject.SetActive(false);
                    avatar2.gameObject.SetActive(true);
                    avatar3.gameObject.SetActive(false);
                    Bullet.bullletDamageUp();
                    PlayerMovement.moveSpeed += 2;
                    avatar2.transform.position = avatar1.transform.position;
                }
                break;
            case 3:
                {
                    avatar1.gameObject.SetActive(false);
                    avatar2.gameObject.SetActive(false);
                    avatar3.gameObject.SetActive(true);
                    Bullet.bullletDamageUp();
                    PlayerMovement.moveSpeed += 2;
                    avatar3.transform.position = avatar2.transform.position;
                }
                break;
        }

    }

}