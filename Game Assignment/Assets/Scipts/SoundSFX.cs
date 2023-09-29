using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSFX : MonoBehaviour
{
    public void PlaySoundEffect()
    {
        AudioManager.Instance.PlaySFX("Click Menu");
    }
    public void PlayPurchasedSound()
    {
        AudioManager.Instance.PlaySFX("Cash Sound");
    }
}
