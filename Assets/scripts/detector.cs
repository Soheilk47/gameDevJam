using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detector : MonoBehaviour
{
    [System.NonSerialized] public Health enemyhealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponentInParent<enemyAttack>().attackMode = true;
            enemyhealth = gameObject.GetComponentInParent<Health>();

            enemyhealth.healthbar.transform.gameObject.SetActive(true);
            enemyhealth.healthbar.maxValue = enemyhealth.maxHealth;
            enemyhealth.healthbar.value = enemyhealth.curHealth;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyhealth.healthbar.transform.gameObject.SetActive(false);
        }
    }
}