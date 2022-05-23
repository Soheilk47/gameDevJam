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
    private movement move;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time >= nextAttTime)
            {
                anim.SetTrigger("Attack");
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

    private void Attack()
    {
        Collider2D hitEnemy = Physics2D.OverlapCircle(attackPoint.position, attackRange, enemyLayer);
        if (hitEnemy != null)
        {
            hitEnemy.GetComponent<Health>().TakeDamage(attackDamage);
        }
    }
}