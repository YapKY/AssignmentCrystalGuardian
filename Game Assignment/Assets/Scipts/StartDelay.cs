//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;
//using UnityEngine.UIElements;

//public class StartDelay : MonoBehaviour
//{
//    public GameObject countDown;
//    private float pauseTime;
//    // Start is called before the first frame update
//    void Start()
//    {
//        StartCoroutine("StartDelayCount");
//    }

//    IEnumerator StartDelayCount()
//    {
//        Time.timeScale = 0;
//        pauseTime = Time.realtimeSinceStartup + 3f;
//        while (Time.realtimeSinceStartup < pauseTime) 
//            yield return 0;
//            countDown.gameObject.SetActive(true);
//        Time.timeScale = 1;
//    }
//}
