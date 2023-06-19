using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public AudioClip hit;
    public AudioSource Sfx;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public Animator animator;

    public float attackRange = 0.5f;
    public int attackDamage = 40;
    public float attackRate = 2f;

    float attackNext = 0f;
    private void Start()
    {
        Input.GetJoystickNames();
    }
    void Update()
    {
        if(Time.time >= attackNext)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetButtonUp("Fire3"))
            {
                
                animator.SetTrigger("Attacking");
                attackNext = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
       Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
                Sfx.clip = hit;
                Sfx.Play();
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
