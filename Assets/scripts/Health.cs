using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [System.NonSerialized] public int curHealth;
    private Animator anim;
    private movement move;

    private void Start()
    {
        anim = GetComponent<Animator>();
        curHealth = maxHealth;
        move = GetComponent<movement>();
    }

    public void TakeDamage(int damage)
    {
        if (this.gameObject.name == "Player")
        {
            move.okMove();
        }
        curHealth -= damage;
        anim.SetTrigger("Hurt");
        if (curHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetBool("isDead", true);
        GetComponent<Collider2D>().enabled = false;

        if (this.gameObject.name == "Player")
        {
            GetComponent<movement>().enabled = false;
            GetComponent<movement>().rb.velocity = new Vector2(0, 0); //to stop even while running
            GetComponent<Rigidbody2D>().isKinematic = true; //to disable gravity
            this.GetComponent<attack>().enabled = false;
        }
        else
        {
            this.GetComponent<enemyAttack>().enabled = false;
        }
        this.enabled = false;
    }
}