using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGhost : MonoBehaviour
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
        PlayerMovement.moveSpeed = 6f;
        Attack.attackspeed = 1;
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
                    Bullet.UpdateDamage();
                    PlayerMovement.moveSpeed += 3f;
                    Attack.attackspeed += 0.5f;
                    avatar2.transform.position = avatar1.transform.position;
                }
                break;
            case 3:
                {
                    avatar1.gameObject.SetActive(false);
                    avatar2.gameObject.SetActive(false);
                    avatar3.gameObject.SetActive(true);
                    Bullet.UpdateDamage();
                    PlayerMovement.moveSpeed += 3f;
                    Attack.attackspeed += 0.5f;
                    avatar3.transform.position = avatar2.transform.position;
                }
                break;
        }

    }
}
