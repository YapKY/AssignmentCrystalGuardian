using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CrystalHealthBar : MonoBehaviour
{
    public float crystalHp;
    public float crystalmaxHp = 100f;
    public float chipSpeed = 2f;
    private float lerpTimer;
    public Image crystalfrontHp;
    public Image crystalBackHp;
    public TextMeshProUGUI hpText;

    // Start is called before the first frame update
    private void Start()
    {
        crystalHp = crystalmaxHp;
        hpText.text = crystalHp + "/" + crystalmaxHp;
        if (crystalHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        crystalHp = Mathf.Clamp(crystalHp, 0, crystalmaxHp); //to makesure the Crystal Hp is from 0 to 100 only
        UpdateCrystalHPBar();
        if (crystalHp <= 0)
        {
            hpText.color = Color.red;
            Destroy(gameObject, 5f);
            GameOver.isGameOver = true;
        }

        if(TimerCounter.timeLimit == 0 && crystalHp != 0)
        {
            Victory.isVictory = true;
        }
    }

    public void UpdateCrystalHPBar()
    {
        float fillFront = crystalfrontHp.fillAmount;
        float fillBack = crystalBackHp.fillAmount;
        float hpFraction = crystalHp / crystalmaxHp;
        hpText.text = crystalHp + "/" + crystalmaxHp;
        if (fillBack > hpFraction)
        {
            crystalfrontHp.fillAmount = hpFraction;
            crystalBackHp.color = Color.magenta;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            crystalBackHp.fillAmount = Mathf.Lerp(fillBack, hpFraction, percentComplete);
        }

    }

    public void CrystalTakeDamage(float damage)
    {
        crystalHp -= damage;
        lerpTimer = 0f;
    }

}
