using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScenes : MonoBehaviour
{
    public static NextScenes next;
    AudioManager manager;
    public void PlaySoundMusic()
    {
        manager.musicSource.Play();
    }
}
