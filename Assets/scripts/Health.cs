using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int curHealth;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        curHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        curHealth -= damage;
        anim.SetTrigger("hurt");
        if (curHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetBool("isDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        this.GetComponent<enemyAttack>().enabled = false;
    }
}