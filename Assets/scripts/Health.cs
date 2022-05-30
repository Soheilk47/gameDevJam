using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth;
    [System.NonSerialized] public int curHealth;
    private Animator anim;
    private movement move;
    private detector detector;

    public Slider healthbar;

    [SerializeField] private GameObject deathSprite;

    [SerializeField] private GameObject sceneMngr;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        move = GetComponent<movement>();
        detector = GetComponentInChildren<detector>();
        curHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        curHealth -= damage;
        anim.SetTrigger("Hurt");
        if (curHealth <= 0)
        {
            Die();
        }

        if (this.gameObject.tag == "Enemy")
        {
            if (detector != null)
            {
                healthbar.value = detector.enemyhealth.curHealth;
            }
        }

        if (this.gameObject.name == "Player")
        {
            move.okMove();
            healthbar.value = curHealth;
        }
    }

    private void Die()
    {
        anim.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;

        if (this.gameObject.name == "Player")
        {
            GetComponent<block>().enabled = false;
            GetComponent<movement>().enabled = false;
            GetComponent<movement>().rb.velocity = new Vector2(0, 0); //to stop even while running
            GetComponent<Rigidbody2D>().isKinematic = true; //to disable gravity
            this.GetComponent<attack>().enabled = false;
            Invoke("loadDieScene", 3f);
        }
        else
        {
            this.GetComponent<enemyAttack>().enabled = false;
            if (deathSprite != null)
            {
                GameObject death = Instantiate(deathSprite, gameObject.transform);
                death.transform.parent = null;
                Destroy(gameObject);
            }
        }
        this.enabled = false;
    }

    private void loadDieScene()
    {
        sceneMngr.GetComponent<SceneMngr>().MenuScene();
    }
}