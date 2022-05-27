using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTransition : MonoBehaviour
{
    public GameObject[] musicObj;

    private void Awake()
    {
        musicObj = GameObject.FindGameObjectsWithTag("IntroMusic");
        if (musicObj.Length == 1)
        {
            Destroy(musicObj[0]);
        }
        else if (musicObj.Length > 1)
        {
            DontDestroyOnLoad(musicObj[0]);

            for (int i = 1; i < musicObj.Length; i++)
            {
                Destroy(musicObj[i]);
            }
        }
    }
}