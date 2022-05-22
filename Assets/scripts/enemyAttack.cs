using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    private GameObject Player;
    private Vector2 playerPos;
    [SerializeField] private float speed;
    [SerializeField] private float attackDistance;
    public bool attackMode = false;
    private Animator anim;

    [SerializeField] private Transform attackPointUp;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask PlayerLayer;
    [SerializeField] private int attackDamage;

    [SerializeField] private float attackRate;
    private float nextAttTime;

    [SerializeField] private GameObject detector;

    private float Yposition;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        Yposition = transform.position.y;
    }

    private void Update()
    {
        if (attackMode)
        {
            playerPos = Player.transform.position;
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, Yposition), new Vector2(playerPos.x, 0) + new Vector2(0.6f, 0), speed * Time.deltaTime);
            anim.SetInteger("AnimState", 2);

            if (Vector2.Distance(transform.position, playerPos) < attackDistance)
            {
                anim.SetInteger("AnimState", 0);
                AttackUp();
            }
        }
    }

    private void AttackUp()
    {
        if (Time.time >= nextAttTime)
        {
            anim.SetTrigger("AttackUp");
            Collider2D hitEnemy = Physics2D.OverlapCircle(attackPointUp.position, attackRange, PlayerLayer);

            nextAttTime = Time.time + attackRate;
        }
    }

    private void OnDrawGizmos()  //attack range gizmos
    {
        if (attackPointUp == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPointUp.position, attackRange);
    }
}