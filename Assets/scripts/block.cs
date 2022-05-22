using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    [SerializeField] private GameObject shieldUp;
    [SerializeField] private GameObject shieldDown;

    private bool shieldUpOn = false;
    private bool shieldDownOn = false;

    private void Start()
    {
        shieldUp.SetActive(false);
        shieldDown.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            shieldUp.SetActive(true);
            shieldUpOn = true;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            shieldDown.SetActive(true);
            shieldDownOn = true;
        }
    }
}