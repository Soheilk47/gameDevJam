using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public Transform[] backGrounds;
    [Range(0, 2)] [SerializeField] private float[] speeds;

    private float[] StartPos;

    private void Start()
    {
        StartPos = new float[backGrounds.Length];
        for (int i = 0; i < backGrounds.Length; i++)
        {
            StartPos[i] = backGrounds[i].position.x;
        }
    }

    private void Update()
    {
        for (int i = 0; i < backGrounds.Length; i++)
        {
            float distance = Camera.main.transform.position.x * speeds[i];
            backGrounds[i].transform.position = new Vector3(StartPos[i] + distance, backGrounds[i].transform.position.y, backGrounds[i].transform.position.z);
        }
    }
}