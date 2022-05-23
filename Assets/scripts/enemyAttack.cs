using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    [SerializeField] private LayerMask PlayerLayer;
    [SerializeField] private float speed;
    private GameObject Player;
    private Vector2 playerPos;
    [System.NonSerialized] public bool attackMode = false;
    private Animator anim;

    [SerializeField] private Transform attackPointUp;
    [SerializeField] private float attackDistance;
    [SerializeField] private float attackStand;
    [SerializeField] private float attackRange;
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
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, Yposition), new Vector2(playerPos.x, 0) + new Vector2(attackStand, 0), speed * Time.deltaTime);
            anim.SetInteger("AnimState", 2);

            if (Vector2.Distance(transform.position, playerPos) < attackDistance)
            {
                anim.SetInteger("AnimState", 0);
                if (Time.time >= nextAttTime)
                {
                    anim.SetTrigger("AttackUp");
                    nextAttTime = Time.time + attackRate;
                }
            }
        }
    }

    private void AttackUp()
    {
        Collider2D hitPlayer = Physics2D.OverlapCircle(attackPointUp.position, attackRange, PlayerLayer);
        if (hitPlayer != null)
        {
            hitPlayer.GetComponent<Health>().TakeDamage(attackDamage);
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