using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    [System.NonSerialized] public bool attackMode = false;
    [SerializeField] private LayerMask PlayerLayer;
    [SerializeField] private float speed;
    private GameObject Player;
    private Vector2 playerPos; private Vector2 offset;
    private Vector2 thisPos;

    [SerializeField] private Transform attackPointUp;
    [SerializeField] private float attackDistance;
    [SerializeField] private float attackStand;
    [SerializeField] private float attackRange;
    [SerializeField] private int attackDamage;
    [SerializeField] private float attackRate;
    private float nextAttTime;

    [SerializeField] private GameObject detector;

    private float Yposition;

    [SerializeField] private AudioSource swordBlock;
    [SerializeField] private AudioSource hurt;
    private Animator anim;
    private block block;

    private int blockPoint = 0;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        Yposition = transform.position.y;
        block = Player.GetComponent<block>();
    }

    private void Update()
    {
        if (attackMode)
        {
            playerPos = new Vector2(Player.transform.position.x, Yposition);
            offset = new Vector2(attackStand, 0);
            thisPos = new Vector2(transform.position.x, Yposition);

            if (Vector2.Distance(transform.position, playerPos) > attackStand)
            {
                transform.position = Vector2.MoveTowards(thisPos, playerPos + offset, speed * Time.deltaTime);
            }
            anim.SetInteger("AnimState", 2);

            if (Player.GetComponent<Health>().curHealth <= 0)
            {
                anim.SetInteger("AnimState", 0);
                nextAttTime *= 2;
            }
            else if (Vector2.Distance(transform.position, playerPos) < attackDistance)
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
        if (hitPlayer != null && block.blockUp == false)
        {
            hitPlayer.GetComponent<Health>().TakeDamage(attackDamage);
            hurt.Play();
        }
        else if (hitPlayer != null && block.blockUp == true) //successful block up
        {
            swordBlock.Play();
            blockPoint++;
            anim.SetInteger("BlockPoint", blockPoint);
            Player.GetComponent<Animator>().SetTrigger("impactUp");
        }
        else if (hitPlayer != null && block.blockUp == true) //successful block down
        {
            swordBlock.Play();
            blockPoint++;
            anim.SetInteger("BlockPoint", blockPoint);
            Player.GetComponent<Animator>().SetTrigger("impactDown");
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

    private void resetPoints()
    {
        blockPoint = 0;
    }

    private void toggleThis()
    {
        this.enabled = !this.enabled;
    }
}