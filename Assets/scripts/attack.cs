using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    [SerializeField] private AudioSource hitSound;
    [SerializeField] private AudioSource airCut;

    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private int attackDamage;

    [SerializeField] private float attackRate;

    [SerializeField] private GameObject blood;
    [SerializeField] private Transform bloodLocation;

    private float nextAttTime;

    private Animator anim;
    private block block;

    private void Start()
    {
        anim = GetComponent<Animator>();
        block = GetComponent<block>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && block.blockDown == false && block.blockUp == false)
        {
            if (Time.time >= nextAttTime)
            {
                anim.SetTrigger("Attack");
                airCut.Play();
                nextAttTime = Time.time + attackRate;
            }
        }
    }

    private void OnDrawGizmos()
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
            Instantiate(blood, bloodLocation);
            hitSound.Play();
        }
    }
}