using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    public bool blockUp = false;
    public bool blockDown = false;

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
            anim.SetInteger("blockState", 0);
            blockUp = false; blockDown = false;
            move.okMove();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetInteger("blockState", 1);
            blockUp = true; blockDown = false;
            move.dontMove();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetInteger("blockState", 2);
            blockDown = true; blockUp = false;
            move.dontMove();
        }
    }
}