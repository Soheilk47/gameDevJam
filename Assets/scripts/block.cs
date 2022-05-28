using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    [System.NonSerialized] public bool blockUp = false;
    [System.NonSerialized] public bool blockDown = false;

    private Animator anim;
    private movement move;

    private void Start()
    {
        anim = GetComponent<Animator>();
        move = GetComponent<movement>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.E))
        {
            anim.Play("Idle");
            blockUp = false; blockDown = false;
            move.okMove();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.Play("Block up");
            blockUp = true; blockDown = false;
            move.dontMove();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            anim.Play("Block down");
            blockDown = true; blockUp = false;
            move.dontMove();
        }
    }
}