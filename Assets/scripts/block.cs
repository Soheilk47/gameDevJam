using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    [SerializeField] private GameObject shieldUp;
    [SerializeField] private GameObject shieldDown;

    public bool blockUp = false;
    public bool blockDown = false;

    private movement move;

    private void Start()
    {
        shieldUp.SetActive(false);
        shieldDown.SetActive(false);

        move = GetComponent<movement>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.E))
        {
            blockUp = false; blockDown = false;
            move.okMove();
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            shieldUp.SetActive(true);
            blockUp = true; blockDown = false;
            move.dontMove();
        }
        else if (Input.GetKey(KeyCode.E))
        {
            shieldDown.SetActive(true);
            blockDown = true; blockUp = false;
            move.dontMove();
        }
    }
}