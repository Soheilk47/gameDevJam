using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rb;
    private Animator anim;
    private bool faceRight = true;
    private float moveInput;

    private bool canMove = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (canMove)
        {
            moveInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }

        if (faceRight == false && moveInput > 0 || faceRight == true && moveInput < 0) //flip
        {
            flip();
        }

        if (Mathf.Abs(moveInput) > Mathf.Epsilon)  //run animation
            anim.SetInteger("AnimState", 2);
        else
            anim.SetInteger("AnimState", 0);
    }

    private void flip()  //flip func
    {
        faceRight = !faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    public void dontMove()
    {
        canMove = false;
    }

    public void okMove()
    {
        canMove = true;
    }
}