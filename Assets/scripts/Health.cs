using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int curHealth;
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
            GetComponent<Rigidbody2D>().isKinematic = true;
            GetComponent<movement>().dontMove();
            this.GetComponent<attack>().enabled = false;
        }
        else
        {
            this.GetComponent<enemyAttack>().enabled = false;
        }
        this.enabled = false;
    }
}