using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private int attackDamage;

    [SerializeField] private float attackRate;
    private float nextAttTime;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Time.time >= nextAttTime)
        {
            if (Input.GetMouseButtonDown(0))  // attack
            {
                anim.SetTrigger("Attack");
                Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
                foreach (Collider2D enemy in hitEnemy)
                {
                    enemy.GetComponent<Health>().TakeDamage(attackDamage);
                }
                nextAttTime = Time.time + attackRate;
            }
        }
    }

    private void OnDrawGizmos()  //attack range gizmos
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}